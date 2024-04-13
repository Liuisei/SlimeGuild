
using TMPro;

public class UGCharactorIndex : UpdatableGraphic<TextMeshProUGUI>
{
    public override void UpdateGraphic()
    {
        GraphicComponent.SetText(DataManager.Instance.HaveCharacterList[ViewId].ToString());
    }
}