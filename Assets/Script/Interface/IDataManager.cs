using System.Collections.Generic;

public interface IDataManager
{
    int Money { get; set; }
 
    List<int> HaveCharacterList { get; set; }
    List<int> GetCharacterList { get; set; }
    CharacterDatabase CharacterDatabase { get; }
    
}
