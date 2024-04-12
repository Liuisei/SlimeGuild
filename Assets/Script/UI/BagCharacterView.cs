using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class BagCharacterView : MonoBehaviour
{
    [SerializeField]
    RawImage rawImageCharacter;

    [SerializeField]
    TextMeshProUGUI tmpCharacterNumber;


    public void SetrawImage(Texture texture)
    {
        rawImageCharacter.texture = texture;
    }

    public void SetText(int characterNumber)
    {
        tmpCharacterNumber.text = characterNumber.ToString();
    }
}