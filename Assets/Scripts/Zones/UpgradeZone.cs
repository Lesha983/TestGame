using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class UpgradeZone : ShopZone
{
    public UnityEvent UpgradeAction;

    public override void UpdatePrice()
    {
        base.UpdatePrice();
        if (CurrentPrice == 0)
        {
            gameObject.GetComponent<BoxCollider>().enabled = false;
            UpgradeAction?.Invoke();
        }
    }
}
