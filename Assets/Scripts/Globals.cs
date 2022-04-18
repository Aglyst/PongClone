using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class Globals
{
    public static GameMode gameMode = GameMode.None;
    public static int scoreToWin;
}

public enum GameMode
{
    None,
    Computer,
    Local,
    Online
}