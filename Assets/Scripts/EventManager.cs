using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public static class EventManager
{
    public static readonly UnityEvent PickedUp = new UnityEvent();
    public static readonly UnityEvent GameWinned = new UnityEvent();
    public static readonly UnityEvent GameLost = new UnityEvent();
    public static readonly UnityEvent CountdownFinished = new UnityEvent();
}