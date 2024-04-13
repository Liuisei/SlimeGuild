using System;
using UnityEngine;
using UnityEngine.UI;
/// <summary>
/// このメソッドは常時更新されるUIを管理するための基底クラスです。
/// UpdateGraphic()はevent OnValueChangedが呼ばれたときに呼び出されます。
/// GetAction()はOnValueChangedに登録するメソッドを返します。
/// DaraManagerのイベントを登録することで、データが変更されたときに更新されるようにします。
/// </summary>
/// <typeparam name="T">Graphic型またはその派生型 Text,RawImage,TMP</typeparam>
public abstract class AutoUpdateGraphic<T> : MonoBehaviour where T : Graphic
{
    [SerializeField]
    private T graphicComponent;

    public T GraphicComponent
    {
        get => graphicComponent;
        set => graphicComponent = value;
    }

    public event Action OnValueChanged;

    protected virtual void Awake()
    {
        if (graphicComponent == null)
        {
            Debug.LogError("Graphic component is not assigned in " + gameObject.name);
            enabled = false;
        }

        OnValueChanged = GetAction();
    }

    protected virtual void OnEnable()
    {
        OnValueChanged += UpdateGraphic;
        UpdateGraphic();
    }

    protected virtual void OnDisable()
    {
        OnValueChanged -= UpdateGraphic;
    }

    protected abstract Action GetAction();

    protected abstract void UpdateGraphic();
}