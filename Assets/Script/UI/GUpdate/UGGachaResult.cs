
using UnityEngine.UI;

public class UGGachaResult : UpdatableGraphic<RawImage>
{
    private void Start()
    {
        ViewId = DataManager.Instance.GetCharacterList[0];
        
    }

    public override void UpdateGraphic()
    {
        DataManager.Instance.GetCharacterList.RemoveAt(0);
        GraphicComponent.texture = DataManager.Instance.CharacterDatabase.characters[ViewId].textureSlime;
    }
}
