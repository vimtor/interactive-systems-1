using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CountdownTimer: MonoBehaviour
{
    public int duration;

    private float _remaining = 30.0f;
    private bool _running;

    void Start()
    {
        _remaining = Convert.ToSingle(duration);
        _running = true;
    }

    void Update()
    {
        if (_running)
        {
            _remaining -= Time.deltaTime;

            if (Finished())
            {
                Stop();
            }
        }
    }

    public int GetMinutes()
    {
        return Mathf.FloorToInt(_remaining / 60);
    }

    public int GetSeconds()
    {
        return Mathf.FloorToInt(_remaining % 60);
    }

    public bool Running() {
        return _running;
    }

    public bool Finished() {
        return _remaining <= 0;
    }

    public void Stop() {
        _running = false;
    }
}
