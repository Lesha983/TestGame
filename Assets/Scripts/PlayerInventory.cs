using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInventory : MonoBehaviour
{
    [SerializeField] private List<GameObject> _logs;
    [SerializeField] private GameObject _log;
    private float _timeSell = 0.1f;
    private static int _currentLogsCount;
    private static int _maxCountLog = 10;
    private UIStats _ui;
    private bool _sale;

    private void Start()
    {
        _ui = UIStats.Instance;
    }

    public static int CurrentLogsCount
    {
        get
        {
            return _currentLogsCount;
        }
        set
        {
            if (_currentLogsCount <= _maxCountLog)
            {
                _currentLogsCount = value;
                Stats.CountLogs = _currentLogsCount;
            }
        }
    }

    public void InventoryLogsAdd()
    {
        _ui.UpdateStats();
        for (int i = 0; i < CurrentLogsCount; i++)
        {
            _logs[i].SetActive(true);
        }
    }

    public void InventoryReload()
    {
        for (int i = 0; i < CurrentLogsCount; i++)
        {
            _logs[i].SetActive(false);
        }
        CurrentLogsCount = 0;
        _ui.UpdateStats();
    }

    public void InventoryLogsSell(int price, Vector3 dropPosition, ShopZone zone)
    {
        _sale = true;
        StartCoroutine(Sell(price, dropPosition, zone));
    }

    IEnumerator Sell(int price, Vector3 dropPosition, ShopZone zone)
    {
        while (_sale)
        {
            if (CurrentLogsCount != 0 && zone.CurrentPrice != 0)
            {
                yield return new WaitForSeconds(_timeSell);
                _logs[CurrentLogsCount - 1].SetActive(false);
                _log.GetComponent<Log>()._dropPosition = dropPosition;
                var log = Instantiate(_log, _logs[CurrentLogsCount - 1].transform.position, Quaternion.identity);
                log.GetComponent<Log>().Move();
                CurrentLogsCount--;
                _ui.UpdateStats();
                zone.CurrentPrice--;
                zone.UpdatePrice();
            }
            else
            {
                _sale = false;
            }
        }
    }
}
