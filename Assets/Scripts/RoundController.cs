using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class RoundController : MonoBehaviour
{
    [SerializeField] private List<GameObject> _buyZone;
    [SerializeField] private GameObject _panelReloadScene;
    private int _countBuyZone;
    public bool test;

    public void ReloadRound()
    {
        _panelReloadScene.SetActive(true);
        _panelReloadScene.GetComponent<Animation>().Play();
        Stats.Level++;
        _countBuyZone = 0;
        Invoke("StartRound", 1.1f);
    }

    private void StartRound()
    {
        SceneManager.LoadScene(0);
    }

    public void NewBuyZone()
    {
        if (_countBuyZone < _buyZone.Count)
        {
            _buyZone[_countBuyZone].SetActive(true);
            _countBuyZone++;
        }
    }
}
