using System;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.EventSystems;
using UnityEngine.Serialization;
using UnityEngine.UI;

public abstract class MyButton : MonoBehaviour,
    IPointerDownHandler,
    IPointerUpHandler,
    IPointerEnterHandler,
    IPointerExitHandler,
    IPointerClickHandler
{
    [SerializeField]
    Texture _normalTexture;

    [SerializeField]
    Texture _dawnTexture;

    [FormerlySerializedAs("onButtonDown")]
    public UnityEvent _onButtonDown;

    [FormerlySerializedAs("onButtonUp")]
    public UnityEvent _onButtonUp;

    [FormerlySerializedAs("onButtonEnter")]
    public UnityEvent _onButtonEnter;

    [FormerlySerializedAs("onButtonExit")]
    public UnityEvent _onButtonExit;

    [FormerlySerializedAs("onButtonClick")]
    public UnityEvent _onButtonClick;

    RawImage _rawImage;

    void Start()
    { 
        _rawImage = GetComponent<RawImage>();
    }

    public void OnPointerDown(PointerEventData eventData)
    {
        _onButtonDown?.Invoke();

    }

    public void OnPointerUp(PointerEventData eventData)
    {
        _onButtonUp?.Invoke();
        OnButtonUp();
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        _onButtonEnter?.Invoke();
        SoundManager.Instance.PlaySE(SeSoundData.Se.Onmouse);
        MouseDownChangeTexture();
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        _onButtonExit?.Invoke();
        TextureReset();

    }

    public void OnPointerClick(PointerEventData eventData)
    {
        _onButtonClick?.Invoke();
    }

    public void MouseDownChangeTexture()
    {
        if (_rawImage == null)
        {
            Debug.Log(  "RawImageをアタッチしてください。");
            return;
        }

        if (_dawnTexture != null) _rawImage.texture  = _dawnTexture;
        else Debug.Log("DawnTextureをアタッチしてください。");
    }

    public void TextureReset()
    {
        if (_rawImage == null)
        {
            Debug.Log(  "RawImageをアタッチしてください。");
            return;
        }
        if (_dawnTexture != null) _rawImage.texture = _normalTexture;
        else Debug.Log("NormalTextureをアタッチしてください。");
    }

    protected abstract void OnButtonUp();
}