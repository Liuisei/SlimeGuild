using UnityEngine;

[CreateAssetMenu(fileName = "Police", menuName = "Character/CSlimePolice")]
public class CSlimePolice : GameCharacter
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
