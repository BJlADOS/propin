using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.EventSystems;

[System.Serializable]
public class PointerEvent : UnityEvent<GameObject>
{
}

public class Clickable : MonoBehaviour, IPointerClickHandler, IPointerEnterHandler, IPointerExitHandler
{
    public PointerEvent LeftClick;
    public PointerEvent MiddleClick;
    public PointerEvent RightClick;
    public PointerEvent Enter;
    public PointerEvent Exit;

    public void OnPointerClick(PointerEventData eventData)
    {
        switch (eventData.button)
        {
            case PointerEventData.InputButton.Left:
                LeftClick?.Invoke(gameObject);
                break;
            case PointerEventData.InputButton.Middle:
                MiddleClick?.Invoke(gameObject);
                break;
            case PointerEventData.InputButton.Right:
                RightClick?.Invoke(gameObject);
                break;
        }
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        Enter?.Invoke(gameObject);
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        Exit?.Invoke(gameObject);
    }
}
