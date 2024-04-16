using Unity.VisualScripting;
using UnityEngine;

[CreateAssetMenu(fileName = "Warrior", menuName = "Character/CSlimeWarrior")]
public class CSlimeWarrior : GameCharacter
{
    public override string Description
    {
        get => "ウォリアーは、攻撃力が高く、敵を倒すことが得意なキャラクターです。";
    }

    public override int ActivateAbility(int value)
    {
        return value + 5;   
    }
}