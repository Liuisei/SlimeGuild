using UnityEngine;
using UnityEngine.Events;
using UnityEngine.EventSystems;

public abstract class MyButton : MonoBehaviour,
    IPointerDownHandler,
    IPointerUpHandler,
    IPointerEnterHandler,
    IPointerExitHandler
{
    public UnityEvent onButtonDown;
    public UnityEvent onButtonUp;
    public UnityEvent onButtonEnter;
    public UnityEvent onButtonExit;

    public void OnPointerDown(PointerEventData eventData)
    {
        onButtonDown?.Invoke();
    }

    public void OnPointerUp(PointerEventData eventData)
    {
        onButtonUp?.Invoke();
        OnButtonUp();
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        onButtonEnter?.Invoke();
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        onButtonExit?.Invoke();
    }

    protected abstract void OnButtonUp();
}