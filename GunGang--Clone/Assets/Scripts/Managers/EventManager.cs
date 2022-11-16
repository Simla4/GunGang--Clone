using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class EventManager
{
    public static Action OnGameStart;
    public static Action OnPlayerFire;
    public static Action<bool>OnBulletCollison;
}
