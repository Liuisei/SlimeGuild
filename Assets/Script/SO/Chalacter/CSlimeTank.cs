using UnityEngine;

[CreateAssetMenu(fileName = "Tank", menuName = "Character/CSlimeTank")]
public class CSlimeTank : GameCharacter
{
    public override string Description
    {
        get => "タンクは、防御力が高く、敵の攻撃を受け止めることが得意なキャラクターです。";
    }

    public override void ActivateAbility()
    {
    }
}