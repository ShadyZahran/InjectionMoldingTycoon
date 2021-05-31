using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CustomerBehaviour : MonoBehaviour
{
    public void OnCustomerEnterFinish()
    {
        //load order
        //show dialog
        GameManager.instance.InitiateOrder();
        
    }

    public void OnCustomerExitFinish()
    {
        //start next customer
        GameManager.instance.NextCustomer();
    }
}
