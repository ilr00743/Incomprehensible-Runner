using System;
using UnityEngine;
using UnityEngine.EventSystems;

public class TapToStartView : MonoBehaviour, IPointerClickHandler
{
    public event Action Clicked;

    public void OnPointerClick(PointerEventData eventData)
    {
        Clicked?.Invoke();
    }
}
