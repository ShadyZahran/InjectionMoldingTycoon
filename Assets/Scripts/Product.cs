using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class Product : Interactable
{
    public int productID;
    public override void OnPointerUp(PointerEventData eventData)
    {
        base.OnPointerUp(eventData);
        Collider2D collidedWith = Physics2D.OverlapCircle(transform.position, 0.3f, overlapWith);

        if (collidedWith)
        {
            if (collidedWith.tag == "DeliveryArea")
            {
                //snap on the housing
                //update machine status
                Debug.Log("Dropped on delivery area");
                GameManager.instance.OnDelivery();
                Destroy(gameObject);
            }
            else
            {
                Debug.Log("Collided with: " + collidedWith.name);
                ReturnToOrigin();
            }

        }
        else
        {
            //snap back to spawn positin?
            Debug.Log("Dropped on nothing");
            ReturnToOrigin();
        }

    }
    
}
