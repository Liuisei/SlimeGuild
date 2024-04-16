using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class DataManager : Singleton<DataManager>
{
    [SerializeField]
    private CharacterDatabase characterDatabase; // CharacterDatabaseの参照

    [SerializeField]
    private int money;

    [SerializeField]
    public List<PlayerCharacterData> playerCharacters = new List<PlayerCharacterData>();

    [SerializeField]
    private List<int> darwCharacterResultList = new List<int>();

    [SerializeField]
    private List<int> partyList = new List<int>();

    [SerializeField]
    private int nowPower;

    [SerializeField]
    private int selectPartyCountMax = 5;


    public  Action OnMoneyChanged;
    public  Action OnHaveCharacterListChanged;
    public  Action OnGetCharacterListChanged;
    public event Action OnPartyChanged;

    public override void AwakeFunction()
    {
        for (int i = 0; i < characterDatabase.characters.Count; i++)
        {
            PlayerCharacterData newCharacter = new PlayerCharacterData
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


    public int NowPower
    {
        get => nowPower;
        set => nowPower = value;
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

    public List<int> GetCharacterList
    {
        get => darwCharacterResultList;
        set
        {
            darwCharacterResultList = value;
            OnGetCharacterListChanged?.Invoke();
        }
    }

    public CharacterDatabase CharacterDatabase => characterDatabase;

    public List<int> PartyList
    {
        get => partyList;
        set => partyList = value;
    }

    public bool HasCharacter(int index)
    {
        return PlayerCharacterDaraList[index].quantity > 0;
    }


    public Texture GetCharacterIconByIndex(int index)
    {
        return characterDatabase.characters[index].characterIcon;
    }

    public int GetCharacterHaveCount(int index)
    {
        return PlayerCharacterDaraList[index].quantity;
    }

    public int GetCharacterLevel(int index)
    {
        return PlayerCharacterDaraList[index].level;
    }

    public void AddPlayerCharacter(int quantity, int level)
    {
        PlayerCharacterData newCharacter = new PlayerCharacterData
        {
            characterId = playerCharacters.Count, // 新しいキャラクターのIDをリストの現在の長さに設定
            quantity = quantity,
            level = level
        };

        playerCharacters.Add(newCharacter);
    }

    public int AddSelectPartyList(int characterId)
    {
        for (int i = 0; i < partyList.Count; i++)
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
        for (int i = 0; i < partyList.Count; i++)
        {
            if (partyList[i] == characterId)
            {
                partyList[i] = -1;
                OnPartyChanged?.Invoke();

                break;
            }
        }
    }

    public void PartySetUp()
    {
        Debug.Log("PartySetUp");
    }
    
}

[Serializable]
public class PlayerCharacterData
{
    public int characterId; //キャラクターID
    public int quantity;    //所持数
    public int level;       //レベル
}