using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlateKitchenObject : KitchenObject
{
    [SerializeField] private List<KitchenObjectSO> validKitchenObjectSOList;

    private List<KitchenObjectSO> kitchenObjectSOList;

    private void Awake()
    {
        kitchenObjectSOList = new();
    }
    public bool TryAddIngredient(KitchenObjectSO kitchenObjectSO)
    {
        if (validKitchenObjectSOList.Contains(kitchenObjectSO))
        {
            if (kitchenObjectSOList.Contains(kitchenObjectSO))
            {
                return false;
            }
            else
            {
                kitchenObjectSOList.Add(kitchenObjectSO);
                return true;
            }
        }
        else
        {
            return false;
        }

    }
}
