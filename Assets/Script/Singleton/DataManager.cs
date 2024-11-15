using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using GoogleMobileAds.Api;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Serialization;

[DefaultExecutionOrder(-100)]
public class DataManager : Singleton<DataManager>
{
    [SerializeField]
    private CharacterDatabase _characterDatabaseSiriSF; // CharacterDatabaseの参照

    [SerializeField]
    private int _moneySiriSF;

    [SerializeField]
    private List<PlayerCharacterData> _playerCharactersSiriSF = new List<PlayerCharacterData>();

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
        LoadPlayerData();
        
    }

    public bool IsPartyIndexMax()
    {
        return _partyListSiriSF.Where(e => e != -1).Count() >= _selectPartyCountMaxSiriSF;
    }

    //コルーチンを使って一秒に一回メソッドを呼び出す
    public void Start()
    {
        StartCoroutine(UpdatePower());
        MobileAds.Initialize(initStatus => { });
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
            if (_moneySiriSF > 1000000000) _moneySiriSF = 1000000000;
            OnMoneyChanged?.Invoke();
            SavePlayerData();
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
        if (_playerCharactersSiriSF.Find(e => e._characterId == id)._quantity > 0 ||
            _playerCharactersSiriSF.Find(e => e._characterId == id)._level    > 1) return true;


        return false;
    }


    public Texture GetCharacterIconByIndex(int id)
    {
        return _characterDatabaseSiriSF.characters[id].textureSlime;
    }

    public int GetCharacterQuantity(int id)
    {
        return _playerCharactersSiriSF.Find(e => e._characterId == id)._quantity;
    }

    public int GetCharacterLevel(int id)
    {
        return _playerCharactersSiriSF.Find(e => e._characterId == id)._level;
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
            _characterId = _playerCharactersSiriSF.Count, // 新しいキャラクターのIDをリストの現在の長さに設定
            _quantity    = quantity,
            _level       = level
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
        var character = _playerCharactersSiriSF.Find(e => e._characterId == characterId);
        character._quantity++;
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
        var character = PlayerCharacterDaraList.Find(e => e._characterId == id);
        character._quantity -= character._level * 10;
        character._level++;
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
        SoundManager.Instance.PlaySE(SeSoundData.Se.Clicker);
    }

    PlayerSaveData saveData = new PlayerSaveData();

    public void SavePlayerData()
    {
        saveData = new PlayerSaveData
        {
            _monet                = _moneySiriSF,
            _playerCharacterDatas = _playerCharactersSiriSF,
            _party                = _partyListSiriSF
        };

        string jsonSaveData = JsonUtility.ToJson(saveData);
        PlayerPrefs.SetString("SaveData", jsonSaveData);
        PlayerPrefs.Save();
    }

    public void LoadPlayerData()
    {
        string jsonSaveData = PlayerPrefs.GetString("SaveData", "");
        if (!string.IsNullOrEmpty(jsonSaveData))
        {
            PlayerSaveData loadedData = JsonUtility.FromJson<PlayerSaveData>(jsonSaveData);
            _moneySiriSF            = loadedData._monet;
            _playerCharactersSiriSF = loadedData._playerCharacterDatas;
            _partyListSiriSF        = loadedData._party;
        }
        else
        {
            PlayerCharacterDataSet();
            _moneySiriSF     = 50000;
            _partyListSiriSF = new List<int> { -1, -1, -1, -1, -1 };
        }
        PartySetUp();
    }

    public void ResetPlayerCharacterData()
    {
        PlayerPrefs.DeleteKey("_playerCharactersSiriSF");
        PlayerPrefs.DeleteKey("_moneySiriSF");
        PlayerPrefs.DeleteKey("_partyListSiriSF");
        _playerCharactersSiriSF = new List<PlayerCharacterData>();
        _moneySiriSF            = 0;
        _partyListSiriSF        = new List<int>();
    }

    public void PlayerCharacterDataSet()
    {
        for (var i = 0; i < _characterDatabaseSiriSF.characters.Count; i++)
        {
            var newCharacter = new PlayerCharacterData
            {
                _characterId = i, // 新しいキャラクターのIDをリストの現在の長さに設定
                _quantity    = 0,
                _level       = 1 // レベルは初期値として1を設定
            };

            _playerCharactersSiriSF.Add(newCharacter);
        }
    }
}

[Serializable]
public class PlayerCharacterData
{
    public int _characterId; //キャラクターID
    public int _quantity;    //所持数
    public int _level;       //レベル
}

[Serializable]
public class PlayerSaveData
{
    public int                       _monet;
    public List<PlayerCharacterData> _playerCharacterDatas;
    public List<int>                 _party;
}