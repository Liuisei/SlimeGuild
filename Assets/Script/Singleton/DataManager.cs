using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;

public class DataManager : Singleton<DataManager>, IDataManager
{
    [SerializeField]
    private CharacterDatabase characterDatabase; // CharacterDatabaseの参照

    
    [SerializeField]
    private int money;

    [SerializeField]
    private List<int> haveCharacterList = new List<int>();

    [SerializeField]
    private List<int> getCharacterList = new List<int>();

    public Action OnMoneyChanged;
    public Action OnHaveCharacterListChanged;
    public Action OnGetCharacterListChanged;

    public override void AwakeFunction()
    {
    }

    public int Money
    {
        get { return money; }
        set
        {
            money = value;
            OnMoneyChanged?.Invoke();
        }
    }

    public List<int> HaveCharacterList
    {
        get { return haveCharacterList; }
        set
        {
            haveCharacterList = value;
            OnHaveCharacterListChanged?.Invoke();
        }
    }

    public List<int> GetCharacterList
    {
        get { return getCharacterList; }
        set
        {
            getCharacterList = value;
            OnGetCharacterListChanged?.Invoke();
        }
    }

    public CharacterDatabase CharacterDatabase
    {
        get { return characterDatabase; }
    }
}