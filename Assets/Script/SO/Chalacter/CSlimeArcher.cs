using UnityEngine;

[CreateAssetMenu(fileName = "Archer", menuName = "Character/CSlimeArcher")]
public class CSlimeArcher : GameCharacter
{
    public override string Description
    {
        get => "アーチャーは、遠距離攻撃が得意なキャラクターです。";
    }

    public override void ActivateAbility()
    {
    }
}