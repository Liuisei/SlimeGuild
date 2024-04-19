using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class GachaManager : Singleton<GachaManager>
{
    // 各レアリティのキャラクターが出現する確率
    
    public Dictionary<Rarity, float> rarityProbabilities = new Dictionary<Rarity, float>()
    {
        { Rarity.C, 70.0f },   // コモン
        { Rarity.N, 29.0f },   // ノーマル
        { Rarity.R, 0.889f },  // レア
        { Rarity.SR, 0.1f },   // スーパーレア
        { Rarity.SSR, 0.01f }, // スーパースーパーレア
        { Rarity.UR, 0.001f }  // ウルトラレア
    };
    //このガチャに入るキャラクターのリスト
    public List<GameCharacter> gachaCharacters = new List<GameCharacter>();
    
    

    public override void AwakeFunction()
    {
    }

    public void DrawGacha()
    {
        // レアリティを決定
        Rarity drawnRarity = DetermineRarity();

        // 決定したレアリティのキャラクターのリストを取得
        List<GameCharacter> charactersOfDrawnRarity = gachaCharacters
            .Where(character => character.rarity == drawnRarity)
            .ToList();

        // レアリティのキャラクターのリストからランダムに1つ選択
        int           id             = Random.Range(0, charactersOfDrawnRarity.Count);
        GameCharacter drawnCharacter = charactersOfDrawnRarity[id];

        // 選択したキャラクターをプレイヤーのキャラクターリストに追加
        DataManager.Instance.AddCharacter(drawnCharacter.characterId);

    }

    private Rarity DetermineRarity()
    {
        float randomValue = Random.Range(0.001f, 100.0f);
        if (randomValue <= rarityProbabilities[Rarity.UR]) return Rarity.UR;
        if (randomValue <= rarityProbabilities[Rarity.SSR]) return Rarity.SSR;
        if (randomValue <= rarityProbabilities[Rarity.SR]) return Rarity.SR;
        if (randomValue <= rarityProbabilities[Rarity.R]) return Rarity.R;
        if (randomValue <= rarityProbabilities[Rarity.N]) return Rarity.N;
        return Rarity.C;
    }
}