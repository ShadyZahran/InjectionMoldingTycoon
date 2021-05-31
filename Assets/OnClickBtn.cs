using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.EventSystems;

public class OnClickBtn : MonoBehaviour, IPointerClickHandler
{
    public UnityEvent myEvent;

    public void OnPointerClick(PointerEventData eventData)
    {
        Debug.Log("inject clicked");
        myEvent.Invoke();
    }

    
}
