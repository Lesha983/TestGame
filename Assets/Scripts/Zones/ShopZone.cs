using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class ShopZone : MonoBehaviour
{
    [SerializeField] protected Transform _constructSite;
    [SerializeField] protected int _price;
    [HideInInspector]public int CurrentPrice;
    [SerializeField] private TextMeshPro _pricetxt;
    [SerializeField] protected RoundController _roundController;

    public void Start()
    {
        _price += Stats.Level * 2;
        CurrentPrice = _price;
        UpdatePrice();
    }

    public virtual void UpdatePrice()
    {
        _pricetxt.text = $"{CurrentPrice}";
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            other.GetComponent<PlayerInventory>().InventoryLogsSell(CurrentPrice, _constructSite.position, this);
        }
    }
}
