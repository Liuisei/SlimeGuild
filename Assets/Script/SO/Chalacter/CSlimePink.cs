using UnityEngine;

[CreateAssetMenu(fileName = "Pink", menuName = "Character/CSlimePink")]
public class CSlimePink : GameCharacter
{
    public override string Description
    {
        get => "ピンクは、回復が得意なキャラクターです。";
    }

    public override void ActivateAbility()
    {
    }
}