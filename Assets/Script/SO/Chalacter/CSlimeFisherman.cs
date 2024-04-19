using UnityEngine;

[CreateAssetMenu(fileName = "Fisherman", menuName = "Character/CSlimeFisherman")]
public class CSlimeFisherman : GameCharacter
{
    public override string Description
    {
        get => "警察は、治安を守ることが得意なキャラクターです";
    }

    public override int ActivateAbility(int level)
    {
        return 100 + level * 1 ;
        
    }
}
