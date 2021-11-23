using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class Stats
{
    private static int _level = 1;
    private static int _countLogs;
    private static int _maxLogs = 10;
    public static int Level { get => _level; set => _level = value; }
    public static int CountLogs { get => _countLogs; set => _countLogs = value; }
    public static int MaxLogs { get => _maxLogs; set => _maxLogs = value; }
}
