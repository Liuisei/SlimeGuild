using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Florist", menuName = "Character/CSlimeFlorist")]
public class CSlimeFlorist : GameCharacter
{
    public override string Description
    {
        get =>
            $"皆が大好きな花屋さん、スライム王国のアイドルだ。"                     +
            $"\n{Property.SlimeCuntry}に攻撃力+{PowerFunction()}" +
            $"\n加護：スライム王国";
    }

    public override string Tip
    {
        get => $"攻撃力：{power}";
    }

    public override void Buff(List<GameCharacter> targetGameCharacters)
    {
    }

    public override int PowerFunction()
    {
        return 100 + Getlevel() * 2;
    }
}