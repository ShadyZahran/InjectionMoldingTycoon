using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
using TMPro;

public class Mold : Interactable
{
    public GameObject myUI;
    public TextMeshProUGUI UI_name, UI_category, UI_specs, UI_description;
    public InteractableSO mySO;
    public GameObject ProductPrefab;
    // Start is called before the first frame update
    public override void OnPointerUp(PointerEventData eventData)
    {
        base.OnPointerUp(eventData);
        Collider2D collidedWith = Physics2D.OverlapCircle(transform.position, 0.3f, overlapWith);

        if (collidedWith)
        {
            if (collidedWith.tag == "MoldHousing")
            {
                //snap on the housing
                //update machine status
                Debug.Log("Dropped on mold housing");
                GameManager.instance.UpdateMachine(this);
            }
            else
            {
                Debug.Log("Collided with: "+ collidedWith.name);
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

    public override void OnPointerEnter(PointerEventData eventData)
    {
        UI_name.SetText(mySO.name);
        UI_category.text = mySO.category;
        UI_specs.text = mySO.specs;
        UI_description.text = mySO.description;
        myUI.SetActive(true);
    }

    public override void OnPointerExit(PointerEventData eventData)
    {
        myUI.SetActive(false);
    }

    
}
