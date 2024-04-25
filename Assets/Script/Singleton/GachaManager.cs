using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class GachaManager : Singleton<GachaManager>
{
    // 各レアリティのキャラクターが出現する確率

    public Dictionary<Rarity, float> rarityProbabilities = new Dictionary<Rarity, float>()
    {
        { Rarity.C, 50.0f },  // コモン
        { Rarity.N, 25.0f },  // ノーマル
        { Rarity.R, 3.89f },  // レア
        { Rarity.SR, 1f },    // スーパーレア
        { Rarity.SSR, 0.1f }, // スーパースーパーレア
        { Rarity.UR, 0.01f }  // ウルトラレア
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
        Debug.Log(drawnRarity);

        List<GameCharacter> charactersOfDrawnRarity = gachaCharacters
            .Where(e => e.rarity == drawnRarity).ToList(); // 決定したレアリティのキャラクターのリストを取得

        int id = Random.Range(0, charactersOfDrawnRarity.Count); // レアリティのキャラクターのリストからランダムに1つ選択

        // 選択したキャラクターをプレイヤーのキャラクターリストに追加
        DataManager.Instance.AddCharacter(charactersOfDrawnRarity[id].characterId);
    }

    private Rarity DetermineRarity()
    {
        ;
        float randomValue = Random.Range(0.001f, 100.0f);
        Debug.Log(randomValue);
        if (randomValue <= rarityProbabilities[Rarity.UR]) return Rarity.UR;
        if (randomValue <= rarityProbabilities[Rarity.SSR]) return Rarity.SSR;
        if (randomValue <= rarityProbabilities[Rarity.SR]) return Rarity.SR;
        if (randomValue <= rarityProbabilities[Rarity.R]) return Rarity.R;
        if (randomValue <= rarityProbabilities[Rarity.N]) return Rarity.N;
        return Rarity.C;
    }
}