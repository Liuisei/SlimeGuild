
using UnityEngine;

[CreateAssetMenu(fileName = "Cat", menuName = "Character/CSlimeCat")]
public class CSlimeCat : GameCharacter
{
    public override string Description
    {
        get => "猫は、Supporterでクールタイムを1+level*0.1短くします";
    }

    public override int ActivateAbility(int level)
    {
        //猫は、Supporterでクールタイムを1+level*0.1短くします
        return 100 + level * 1 ;
    }
}

