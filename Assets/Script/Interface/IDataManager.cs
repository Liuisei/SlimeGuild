using System.Collections.Generic;

public interface IDataManager
{
    int               Money             { get; set; }
    List<int>         PlayerCharacterInventory { get; set; }
    List<int>         GetCharacterList  { get; set; }
    CharacterDatabase CharacterDatabase { get; }
    List<int>         PartyList         { get; set; }
    bool              HasCharacter(int index);
}