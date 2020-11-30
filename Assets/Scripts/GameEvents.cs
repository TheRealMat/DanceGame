using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameEvents : MonoBehaviour
{
    public event Action onBeat;
    public void BeatHappened()
    {
        if (onBeat != null)
        {
            onBeat();
        }
    }
}
