using UnityEngine;
using UnityEngine.Events;
using UnityEngine.EventSystems;

public abstract class MyButton : MonoBehaviour,
    IPointerDownHandler,
    IPointerUpHandler,
    IPointerEnterHandler,
    IPointerExitHandler
{
    public UnityAction onButtonDown;
    public UnityAction onButtonUp;
    public UnityAction onButtonEnter;
    public UnityAction onButtonExit;

    public void OnPointerDown(PointerEventData eventData)
    {
        Debug.Log("Down");
        onButtonDown?.Invoke();
    }

    public void OnPointerUp(PointerEventData eventData)
    {
        Debug.Log("up");
        onButtonUp?.Invoke();
        OnButtonUp();
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        Debug.Log("enter");
        onButtonEnter?.Invoke();
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        Debug.Log("exit");
        onButtonExit?.Invoke();
    }

    protected abstract void OnButtonUp();
}