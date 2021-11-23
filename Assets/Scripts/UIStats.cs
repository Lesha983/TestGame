using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIStats : MonoBehaviour
{
    public static UIStats Instance;
    [SerializeField] private Text _countLogs;
    [SerializeField] private TextMesh _level;

    public void Awake()
    {
        Instance = this;
    }

    private void Start()
    {
        UpdateStats();
    }

    public void UpdateStats()
    {
        _countLogs.text = $"{Stats.CountLogs}/{Stats.MaxLogs}";
        _level.text = $"Level {Stats.Level + 1}";
    }

    public void ResetLogs()
    {
        Stats.CountLogs = 0;
        UpdateStats();
    }
}
