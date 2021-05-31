using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;
    public GameObject moldHousing, productHousing;
    public InteractableSO[] myOrders;
    public int currentOrderIndex = -1;
    public InteractableSO currentOrder;
    public Mold currentMold;
    public GameObject dialogUI;
    public Text dialogText;
    public Animator injectBtnAnimator, coolBtnAnimator, customerAnimator;
    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else if (instance != this)
        {
            Destroy(gameObject);
        }
    }

    private void Start()
    {
        //LoadOrder(0);
        //ShowDialog();
        customerAnimator.SetTrigger("Enter");
    }
    public void UpdateMachine(Mold targetMold)
    {
        if (currentOrder.product_ID == targetMold.mySO.product_ID)
        {
            //the right mold
            currentMold = targetMold;
            injectBtnAnimator.SetTrigger("Blink");
        }
        else
        {
            //the wrong mold
            targetMold.ReturnToOrigin();
        }
    }

    public void OnInjectButton()
    {
        Debug.Log("inject btn");
        injectBtnAnimator.SetTrigger("Stop");
        coolBtnAnimator.SetTrigger("Blink");
    }

    public void OnInjectFinish()
    {

    }

    public void OnCoolingButton()
    {
        Debug.Log("cooling btn");
        coolBtnAnimator.SetTrigger("Stop");
        SpawnProduct();
    }

    public void OnCoolingFinish()
    {

    }

    public void SpawnProduct()
    {
        Instantiate(currentMold.ProductPrefab, productHousing.transform.position, Quaternion.identity);
    }

    public void ShowDialog()
    {
        string tempStr = "";
        switch (currentOrder.OrderThrough)
        {
            case InteractableSO.OrderBy.name:
                tempStr = "I want the part: ";
                break;
            case InteractableSO.OrderBy.specs:
                tempStr = "I want the part with these specs: ";
                break;
            case InteractableSO.OrderBy.description:
                tempStr = "I have a ";
                break;
            default:
                break;
        }
        dialogText.text = tempStr + currentOrder.GetRequest();
        dialogUI.SetActive(true);
    }

    public void HideDialog()
    {
        dialogUI.SetActive(false);
    }

    public void OnDelivery()
    {
        //reset machine
        //reset mold positon
        currentMold.ReturnToOrigin();
        //end dialog
        dialogUI.SetActive(false);
        //customer exit animation
        customerAnimator.SetTrigger("Exit");
    }

    private void LoadOrder(int orderIndex)
    {
        if (orderIndex > myOrders.Length - 1)
        {
            currentOrderIndex = 0;
        }
        else
        {
            currentOrderIndex = orderIndex;
        }
        currentOrder = myOrders[currentOrderIndex];
    }

    public void InitiateOrder()
    {
        LoadOrder(currentOrderIndex + 1);
        ShowDialog();
    }

    public void NextCustomer()
    {
        customerAnimator.SetTrigger("Enter");
    }

    public void ExitGame()
    {
        Application.Quit();
    }
}
