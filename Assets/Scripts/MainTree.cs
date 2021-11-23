using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainTree : MonoBehaviour
{
    [SerializeField] private GameObject _log;

    public void Lumbering()
    {
        StartCoroutine(ProductionWood());
    }

    IEnumerator ProductionWood()
    {
        while (true)
        {
            int wait = Random.Range(2, 6);
            yield return new WaitForSeconds(wait);
            Instantiate(_log, transform.position, Quaternion.identity);
        }
    }
}
