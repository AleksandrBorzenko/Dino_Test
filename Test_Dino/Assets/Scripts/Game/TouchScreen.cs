using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.EventSystems;

public class TouchScreen : MonoBehaviour,IPointerClickHandler
{
    /// <summary>
    /// The game started event
    /// </summary>
    [HideInInspector] public UnityEvent GameStarted = new UnityEvent();

    public void OnPointerClick(PointerEventData eventData)
    {
        GameStarted?.Invoke();
        transform.parent.gameObject.SetActive(false);
    }

}
