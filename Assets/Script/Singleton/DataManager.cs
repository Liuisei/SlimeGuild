using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.Serialization;

[DefaultExecutionOrder(-1)]
public class DataManager : Singleton<DataManager>
{
    [SerializeField]
    private CharacterDatabase characterDatabase; // CharacterDatabaseの参照

    [SerializeField]
    private int money;

    [SerializeField]
    public List<PlayerCharacterData> playerCharacters = new List<PlayerCharacterData>();

    [FormerlySerializedAs("drawCharacterResultList")]
    [SerializeField]
    private List<int> drawCharacterResultResultList = new List<int>();

    [SerializeField]
    private List<int> partyList = new List<int>();

    [SerializeField]
    private int nowPower;

    [SerializeField]
    private int selectPartyCountMax = 5;

    private float _cooltime = 1.0f;


    public Action       OnMoneyChanged;
    public Action       OnHaveCharacterListChanged;
    public Action       OnGetCharacterListChanged;
    public Action       OnNowPowerChanged;
    public event Action OnPartyChanged;

    public override void AwakeFunction()
    {
        for (var i = 0; i < characterDatabase.characters.Count; i++)
        {
            var newCharacter = new PlayerCharacterData
            {
                characterId = i, // 新しいキャラクターのIDをリストの現在の長さに設定
                quantity = 0,
                level = 1 // レベルは初期値として1を設定
            };

            playerCharacters.Add(newCharacter);
        }
    }

    public bool IsPartyIndexMax()
    {
        return partyList.Where(e => e != -1).Count() >= selectPartyCountMax;
    }

    //コルーチンを使って一秒に一回メソッドを呼び出す
    public void Start()
    {
        StartCoroutine(UpdatePower());
    }

    IEnumerator UpdatePower()
    {
        yield return new WaitForSeconds(_cooltime);
        Money += NowPower;
        StartCoroutine(UpdatePower());
    }


    public int NowPower
    {
        get => nowPower;
        set
        {
            nowPower = value;
            OnNowPowerChanged?.Invoke();
        }
    }

    public int Money
    {
        get => money;
        set
        {
            money = value;
            OnMoneyChanged?.Invoke();
        }
    }

    public List<PlayerCharacterData> PlayerCharacterDaraList
    {
        get => playerCharacters;
        set
        {
            playerCharacters = value;
            OnHaveCharacterListChanged?.Invoke();
        }
    }

    public List<int> DrawCharacterResultList
    {
        get => drawCharacterResultResultList;
        set
        {
            drawCharacterResultResultList = value;
            OnGetCharacterListChanged?.Invoke();
        }
    }

    public CharacterDatabase CharacterDatabase => characterDatabase;

    public List<int> PartyList
    {
        get => partyList;
        set => partyList = value;
    }

    /// <summary>
    /// CharacterDatabaseのcharactersリストのIDが一致するキャラクターの所持数を返す
    /// </summary>
    /// <param name="id"></param>
    /// <returns></returns>
    public bool HasCharacter(int id)
    {
        return playerCharacters.Find(e => e.characterId == id).quantity > 0;
    }


    public Texture GetCharacterIconByIndex(int id)
    {
        return characterDatabase.characters[id].textureSlime;
    }

    public int GetCharacterQuantity(int id)
    {
        return playerCharacters.Find(e => e.characterId == id).quantity;
    }

    public int GetCharacterLevel(int id)
    {
        return playerCharacters.Find(e => e.characterId == id).level;
    }

    public void AddPlayerCharacter(int quantity, int level)
    {
        var newCharacter = new PlayerCharacterData
        {
            characterId = playerCharacters.Count, // 新しいキャラクターのIDをリストの現在の長さに設定
            quantity = quantity,
            level = level
        };

        playerCharacters.Add(newCharacter);
    }

    public int AddSelectPartyList(int characterId)
    {
        for (var i = 0; i < partyList.Count; i++)
        {
            if (partyList[i] == -1)
            {
                partyList[i] = characterId;
                OnPartyChanged?.Invoke();

                return i + 1;
            }
        }

        return -2;
    }

    public void RemoveSelectPartyList(int characterId)
    {
        for (var i = 0; i < partyList.Count; i++)
        {
            if (partyList[i] == characterId)
            {
                partyList[i] = -1;
                OnPartyChanged?.Invoke();

                break;
            }
        }
    }

    /// <summary>
    /// gacha結果をリストに追加
    /// </summary>
    /// <param name="characterId"></param>
    public void AddCharacter(int characterId)
    {
        Debug.Log("characterId: " + characterId);
        // playerCharacters でIDが一致するキャラクターを取得
        var character = playerCharacters.Find(e => e.characterId == characterId);
        character.quantity++;
        DrawCharacterResultList.Add(characterId);
    }

    /// <summary>
    ///  ガチャ結果ゼロ番を取得して削除
    /// </summary>
    /// <returns></returns>
    public int ViewGachaResult()
    {
        var firstGet = DrawCharacterResultList[0];
        DrawCharacterResultList.RemoveAt(0);
        return firstGet;
    }

    public void PartySetUp()
    {
        var party = PartyList.Where(e => e!=-1).Select(e => characterDatabase
            .characters.Find(GC => GC.characterId == e)).ToList(); //パーティーリストのキャラクターIDを元にキャラクターデータを取得
        party.ForEach(e => e.power = e.PowerFunction(GetCharacterLevel(e.characterId))); //パワーの設定

        var partyBuffer   = party.Where(e => e.skillType == SkillType.Buffer).ToList();   //バッファーのキャラクターを取得
        var partyAttacker = party.Where(e => e.skillType == SkillType.Attacker).ToList(); //アタッカーのキャラクターを取得

        partyBuffer.ForEach(e => e.Buff(partyAttacker));
        
        NowPower = partyAttacker.Sum(e => e.power);
    }
}

[Serializable]
public class PlayerCharacterData
{
    public int characterId; //キャラクターID
    public int quantity;    //所持数
    public int level;       //レベル
}