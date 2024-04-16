using UnityEngine;

[CreateAssetMenu(fileName = "Paladin", menuName = "Character/CSlimePaladin")]
public class CSlimePaladin : GameCharacter
{
    public override string Description
    {
        get => "パラディンは、防御力が高く、味方を守ることが得意なキャラクターです。";
    }

    public override void ActivateAbility()
    {
    }
}