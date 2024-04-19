using UnityEngine;

[CreateAssetMenu(fileName = "Dog", menuName = "Character/CSlimeDog")]
public class CSlimeDog : GameCharacter
{
    public override string Description
    {
        get => "犬は、属性勇者パーティーとスライム王国に属してます。";
    }

    public override int ActivateAbility(int level)
    {
        return 100 + level * 1 ;
    }
}

