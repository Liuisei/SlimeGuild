using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;

public class DataManager : Singleton<DataManager>
{
    [SerializeField]
    private CharacterDatabase characterDatabase; // CharacterDatabaseの参照

    [SerializeField]
    private int money;

    [SerializeField]
    public List<PlayerCharacterData> PlayerCharacters = new List<PlayerCharacterData>();
    [SerializeField]
    private List<int> darwCharacterResultList = new List<int>();

    [SerializeField]
    private List<int> partyList = new List<int>();

    [SerializeField]
    private List<int> selectPartyList = new List<int>();

    [SerializeField]
    private int nowPower;

    [SerializeField]
    private int selectPartyCountMax = 5;

    [SerializeField]
    private int selectPartyCount = 0;


    public Action OnMoneyChanged;
    public Action OnHaveCharacterListChanged;
    public Action OnGetCharacterListChanged;

    public override void AwakeFunction()
    {
    }

    public bool IsPartyIndexMax()
    {
        return selectPartyCount >= selectPartyCountMax;
    }

    public int SelectPartyIndex
    {
        get => selectPartyCount;
        set => selectPartyCount = value;
    }
    public List<int> SelectPartyList
    {
        get => selectPartyList;
        set => selectPartyList = value;
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
        get => PlayerCharacters;
        set
        {
            PlayerCharacters = value;
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
        return PlayerCharacterDaraList[index].Quantity > 0;
    }
    
    
    public Texture GetCharacterIconByIndex(int index)
    {
        return characterDatabase.characters[index].characterIcon;
    }
    
    public int GetCharacterHaveCount(int index)
    {
        return PlayerCharacterDaraList[index].Quantity;
    }
}
public class PlayerCharacterData
{
    public int CharacterId { get; set; }
    public int Quantity    { get; set; }
    public int Level       { get; set; }
}


