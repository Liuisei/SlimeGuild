using UnityEngine;
using UnityEngine.UI;
/// <summary>
/// このスクリプトは viewIdから表示するUIを指定し、
/// UpdateGraphic()は表示するUIを更新するメソッドです、更新したいときに呼び出してください。
/// </summary>
/// <typeparam name="T">Graphic型またはその派生型 Text,RawImage,TMP</typeparam>
public abstract class UpdatableGraphic<T> : MonoBehaviour where T : Graphic
{
    [SerializeField]
    private T graphicComponent;
    
    private int viewId;

    public int ViewId
    {
        get => viewId;
        set
        {
            viewId = value;
            UpdateGraphic();
        }
    }

    public T GraphicComponent
    {
        get => graphicComponent;
        set => graphicComponent = value;
    }

    protected virtual void Awake()
    {
        if (graphicComponent == null)
        {
            Debug.LogError("Graphic component is not assigned in " + gameObject.name);
            enabled = false;
        }
    }
    public abstract void UpdateGraphic();
}