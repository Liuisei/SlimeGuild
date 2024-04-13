
using UnityEngine;
using UnityEngine.UI;

public class UGCharactorIcon : UpdatableGraphic<RawImage>
{
    public override void UpdateGraphic()
    {
        GraphicComponent.texture = DataManager.Instance.CharacterDatabase.characters[ViewId].characterIcon;
        Debug.Log("UpdateIcon: " + ViewId);
    }
}
