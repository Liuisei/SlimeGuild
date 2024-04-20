using UnityEngine;
using UnityEngine.UI;

public class GachaResult : MonoBehaviour
{
    [SerializeField]
    public CharacterView GraphicComponent;

    private void Start()
    {
        GraphicComponent.CharacterId = DataManager.Instance.ViewGachaResult();
    }
}