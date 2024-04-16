using UnityEngine;

[CreateAssetMenu(fileName = "Mage", menuName = "Character/CSlimeMage")]
public class CSlimeMage : GameCharacter
{
    public override string Description
    {
        get => "メイジは、魔法攻撃が得意なキャラクターです。+10";
    }

    public override int ActivateAbility(int value)
    {
        return value + 10;
    }
}