using UnityEngine;

[CreateAssetMenu(fileName = "Peasant", menuName = "Character/CSlimePeasant")]
public class CSlimePeasant : GameCharacter
{
    public override string Description
    {
        get => "農家は、農作物を育てることが得意なキャラクターです。";
    }

    public override int ActivateAbility(int level)
    {
        return 100 + level * 1 ;
    }
}
