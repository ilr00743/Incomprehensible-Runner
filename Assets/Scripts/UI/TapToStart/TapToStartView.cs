using System;
using UnityEngine;
using UnityEngine.EventSystems;

namespace Runner.UI.TapToStart
{
    public class TapToStartView : MonoBehaviour, IPointerClickHandler
    {
        public event Action Clicked;

        public void OnPointerClick(PointerEventData eventData)
        {
            Clicked?.Invoke();
        }
    }
}
