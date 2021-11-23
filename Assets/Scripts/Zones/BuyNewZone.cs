using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuyNewZone : ShopZone
{
    [SerializeField] private GameObject _buyObject;

    public override void UpdatePrice()
    {
        base.UpdatePrice();
        if (CurrentPrice == 0)
        {
            _buyObject.SetActive(true);
            gameObject.SetActive(false);
            _roundController.NewBuyZone();
        }
    }
}
