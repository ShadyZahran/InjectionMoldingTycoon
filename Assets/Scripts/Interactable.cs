using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public abstract class Interactable : MonoBehaviour, IPointerDownHandler, IPointerUpHandler, IPointerEnterHandler,IPointerExitHandler
{
    public Vector3 spawnPosition;
    public LayerMask overlapWith;
    private Vector3 initialPos, initialMousePos;
    
    bool isDragging = false;

    private void Start()
    {
        spawnPosition = transform.position;
    }
    public virtual void OnPointerDown(PointerEventData eventData)
    {
        isDragging = true;
        //Debug.Log(name + " is down clicked");
        initialPos = transform.position;
        initialMousePos = Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, Input.mousePosition.z));
        initialMousePos.z = initialPos.z;

        
    }

    public virtual void OnPointerUp(PointerEventData eventData)
    {
        //Debug.Log(name + " is up clicked");
        isDragging = false;
    }

    private void FixedUpdate()
    {
        if (isDragging)
        {
            Vector3 tempPos = Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, Input.mousePosition.z));
            tempPos.z = transform.position.z;
            Vector3 mousePos = tempPos - initialMousePos;
            transform.SetPositionAndRotation(initialPos + mousePos, Quaternion.Euler(0, 0, 0));
        }
        
    }

    public virtual void OnPointerEnter(PointerEventData eventData)
    {
        
    }

    public virtual void OnPointerExit(PointerEventData eventData)
    {
    }

    public virtual void ReturnToOrigin()
    {
        transform.position = spawnPosition;
    }
}
