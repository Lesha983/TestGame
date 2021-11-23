using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class Log : MonoBehaviour
{
    public Vector3 _dropPosition;
    [HideInInspector] public ProductionWood _myProduction;

    private void Start()
    {
        if (_myProduction != null)
        {
            transform.DOJump(_dropPosition, 0.5f, 1, 0.5f, false);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Player")
        {
            if (PlayerInventory.CurrentLogsCount < 10)
            {
                if (_myProduction != null)
                    _myProduction._dropPoints.Add(_dropPosition);
                _dropPosition = other.transform.position;
                PlayerInventory.CurrentLogsCount++;
                other.GetComponent<PlayerInventory>().InventoryLogsAdd();
                Move();
            }
        }
    }
    public void Move()
    {
        transform.DOMove(_dropPosition, 0.2f, false);
        Destroy(gameObject, 0.2f);
    }
}
