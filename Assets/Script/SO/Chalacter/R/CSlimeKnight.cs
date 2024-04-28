using System.Collections.Generic;
using System.Linq;
using UnityEngine;

[CreateAssetMenu(fileName = "Knight", menuName = "CharacterR/CSlimeKnight")]
public class CSlimeKnight : GameCharacter
{
    public override string Description
    {
        get => $"スライム王国の衛兵。"           +
               $"\n攻撃力：{PowerFunction()}" +
               $"\n加護：スライム王国";
       
    }

    public override string Tip
    {
        get => $"攻撃力：{power}";
    }

    public override void Buff(List<GameCharacter> targetGameCharacters)
    {
        var targetPartys = targetGameCharacters.Where(p =>
            p._characterTypes.Contains(CharacterType.King) || p._characterTypes.Contains(CharacterType.Queen));

        foreach (var targetmenber in targetPartys)
        {
            targetmenber.power += power;
        }
    }

    public override int PowerFunction()
    {
        return 1000 + Getlevel();
    }
}

