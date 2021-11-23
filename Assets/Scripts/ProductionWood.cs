using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProductionWood : MonoBehaviour
{
    [SerializeField] private GameObject _log;
    [SerializeField] private int _logRespawnTime;
    [SerializeField] private Transform _startPointDropLog;
    [SerializeField] private bool _isAMainTree;
    [SerializeField] private GameObject _exclamation;
    public List<Vector3> _dropPoints;
    [Header ("Размеры склада")]
    [SerializeField] private int _amountLine;//количество линий на складе
    [SerializeField] private int _amountRange;//количество рядов на складе
    [SerializeField] private int _amountHeight;//высота склада
    private float _distanceX = 0.2f, _distanceZ = -0.4f, _distanceY = 0.15f;//расстояние между бревнами на складе

    private void Start()
    {
        Vector3 startPos = _startPointDropLog.position;

        for (int h = 0; h < _amountHeight; h++)
        {
            for (int j = 0; j < _amountRange; j++)
            {
                for (int i = 0; i < _amountLine; i++)
                {
                    _dropPoints.Add(startPos);
                    startPos.x += _distanceX;
                }
                startPos.x = _startPointDropLog.position.x;
                startPos.z += _distanceZ;
            }
            startPos.x = _startPointDropLog.position.x;
            startPos.z = _startPointDropLog.position.z;
            startPos.y += _distanceY;
        }
        if (!_isAMainTree)
        {
            Lumbering();
        }
    }

    public void Lumbering()
    {
        StartCoroutine(ProductionLog());
    }

    IEnumerator ProductionLog()
    {
        while (true)
        {
            yield return new WaitForSeconds(_logRespawnTime);
            if (_dropPoints.Count != 0)
            {
                _log.GetComponent<Log>()._dropPosition = _dropPoints[0];
                _log.GetComponent<Log>()._myProduction = this;
                Instantiate(_log, transform.position, Quaternion.identity);
                _dropPoints.RemoveAt(0);
                _exclamation.SetActive(false);
            }
            else
            {
                _exclamation.SetActive(true);
            }
        }
    }
}
