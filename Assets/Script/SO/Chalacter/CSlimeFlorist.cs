using UnityEngine;

[CreateAssetMenu(fileName = "Florist", menuName = "Character/CSlimeFlorist")]
public class CSlimeFlorist : GameCharacter
{
    public override string Description
    {
        get => "花屋はバッファーで、属性Slimeconturyのキャラクターの攻撃力を上げることが得意なキャラクターです。";
    }

    public override int ActivateAbility(int level)
    {
        //slimeconturyのキャラクターの攻撃力を20+level*0.3上げる
        return 20 + level * 3;
    }
}
