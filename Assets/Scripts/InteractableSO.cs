using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[CreateAssetMenu(fileName = "InteractableAsset", menuName = "Interactables/Asset", order = 1)]
public class InteractableSO : ScriptableObject
{
    public string name, category, specs, description;
    public int product_ID;
    public OrderBy OrderThrough;

    public enum OrderBy
    {
        name,
        specs,
        description
    }

    public string GetRequest()
    {
        string result = "";
        switch (OrderThrough)
        {
            case OrderBy.name:
                result = name;
                break;
            case OrderBy.specs:
                result = specs;
                break;
            case OrderBy.description:
                result = description;
                break;
            default:
                break;
        }
        return result;
    }
}
