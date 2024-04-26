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
    private CharacterDatabase _characterDatabaseSiriSF; // CharacterDatabaseの参照

    [SerializeField]
    private int _moneySiriSF;

    [SerializeField]
    public List<PlayerCharacterData> _playerCharactersSiriSF = new List<PlayerCharacterData>();

    [SerializeField]
    private List<int> _drawCharacterResultResultListSiriSF = new List<int>();

    [SerializeField]
    private List<int> _partyListSiriSF = new List<int>();

    [SerializeField]
    private int _nowPowerSiriSF;

    [SerializeField]
    private int _selectPartyCountMaxSiriSF = 5;

    [SerializeField]
    GameObject _detilSF;

    [SerializeField]
    GameObject _tipsSF;

    private float _cooltime = 1.0f;


    public Action       OnMoneyChanged;
    public Action       OnPlayerCharacterListChanged;
    public Action       OnNowPowerChanged;
    public Action       OnClicked;
    public event Action OnPartyChanged;

    public override void AwakeFunction()
    {
        for (var i = 0; i < _characterDatabaseSiriSF.characters.Count; i++)
        {
            var newCharacter = new PlayerCharacterData
            {
                _characterIdSiriSF = i, // 新しいキャラクターのIDをリストの現在の長さに設定
                _quantitySiriSF    = 0,
                _levelSiriSF       = 1 // レベルは初期値として1を設定
            };

            _playerCharactersSiriSF.Add(newCharacter);
        }

        AddCharacter(1);
    }

    public bool IsPartyIndexMax()
    {
        return _partyListSiriSF.Where(e => e != -1).Count() >= _selectPartyCountMaxSiriSF;
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
        get => _nowPowerSiriSF;
        set
        {
            _nowPowerSiriSF = value;
            OnNowPowerChanged?.Invoke();
        }
    }

    public int Money
    {
        get => _moneySiriSF;
        set
        {
            _moneySiriSF = value;
            OnMoneyChanged?.Invoke();
        }
    }

    public List<PlayerCharacterData> PlayerCharacterDaraList
    {
        get => _playerCharactersSiriSF;
        set { _playerCharactersSiriSF = value; }
    }

    public List<int> DrawCharacterResultList
    {
        get => _drawCharacterResultResultListSiriSF;
        set { _drawCharacterResultResultListSiriSF = value; }
    }

    public CharacterDatabase CharacterDatabase => _characterDatabaseSiriSF;

    public List<int> PartyList
    {
        get => _partyListSiriSF;
        set => _partyListSiriSF = value;
    }

    /// <summary>
    /// CharacterDatabaseのcharactersリストのIDが一致するキャラクターの所持数を返す
    /// </summary>
    /// <param name="id"></param>
    /// <returns></returns>
    public bool HasCharacter(int id)
    {
        return _playerCharactersSiriSF.Find(e => e._characterIdSiriSF == id)._quantitySiriSF > 0;
    }


    public Texture GetCharacterIconByIndex(int id)
    {
        return _characterDatabaseSiriSF.characters[id].textureSlime;
    }

    public int GetCharacterQuantity(int id)
    {
        return _playerCharactersSiriSF.Find(e => e._characterIdSiriSF == id)._quantitySiriSF;
    }

    public int GetCharacterLevel(int id)
    {
        return _playerCharactersSiriSF.Find(e => e._characterIdSiriSF == id)._levelSiriSF;
    }

    public string GetCharacterDetails(int id)
    {
        return _characterDatabaseSiriSF.characters.Find(e => e.characterId == id).Description;
    }

    public string GetCharacterTip(int id)
    {
        return _characterDatabaseSiriSF.characters.Find(e => e.characterId == id).Tip;
    }

    public void AddPlayerCharacter(int quantity, int level)
    {
        var newCharacter = new PlayerCharacterData
        {
            _characterIdSiriSF = _playerCharactersSiriSF.Count, // 新しいキャラクターのIDをリストの現在の長さに設定
            _quantitySiriSF    = quantity,
            _levelSiriSF       = level
        };

        _playerCharactersSiriSF.Add(newCharacter);
    }

    public int AddSelectPartyList(int characterId)
    {
        for (var i = 0; i < _partyListSiriSF.Count; i++)
        {
            if (_partyListSiriSF[i] == -1)
            {
                _partyListSiriSF[i] = characterId;
                OnPartyChanged?.Invoke();

                return i + 1;
            }
        }

        return -2;
    }


    public void RemoveSelectPartyList(int characterId)
    {
        for (var i = 0; i < _partyListSiriSF.Count; i++)
        {
            if (_partyListSiriSF[i] == characterId)
            {
                _partyListSiriSF[i] = -1;
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
        var character = _playerCharactersSiriSF.Find(e => e._characterIdSiriSF == characterId);
        character._quantitySiriSF++;
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

    public void LevelUp(int id)
    {
        var character = PlayerCharacterDaraList.Find(e => e._characterIdSiriSF == id);
        character._quantitySiriSF -= character._levelSiriSF * 100;
        character._levelSiriSF++;
        OnPlayerCharacterListChanged?.Invoke();
    }

    public void DetialSPawn(int id)
    {
        GameObject newdetail = Instantiate(_detilSF, new Vector3(0, 0, 0), Quaternion.identity);
        newdetail.GetComponentInChildren<DetailsView>().ID = id;
    }

    public void TipSpawn(int id)
    {
        GameObject newtips = Instantiate(_tipsSF, new Vector3(0, 0, 0), Quaternion.identity);
        newtips.GetComponentInChildren<TipView>().ID = id;
    }

    public void PartySetUp()
    {
        var party = PartyList.Where(e => e != -1).Select(e => _characterDatabaseSiriSF
            .characters.Find(gc => gc.characterId == e)).ToList(); //パーティーリストのキャラクターIDを元にキャラクターデータを取得

        var partyBuffer   = party.Where(e => e.skillType == SkillType.Buffer).ToList();   //バッファーのキャラクターを取得
        var partyAttacker = party.Where(e => e.skillType == SkillType.Attacker).ToList(); //アタッカーのキャラクターを取得
        party.ForEach(e => e.ResetPower());                                               //パワーをリセット

        partyBuffer.ForEach(e => e.Buff(partyAttacker)); //バッファーのスキルを発動

        NowPower = partyAttacker.Sum(e => e.power);
    }

    public void ClickAddMoney()
    {
        Money += NowPower;
        OnClicked?.Invoke();
    }
}

[Serializable]
public class PlayerCharacterData
{
    public int _characterIdSiriSF; //キャラクターID
    public int _quantitySiriSF;    //所持数
    public int _levelSiriSF;       //レベル
}