using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TimerText : MonoBehaviour
{
    private CountdownTimer _timer;
    private Text _text;
    private bool _gameEnded;

    void Start()
    {
        _text = GetComponent<Text>();
        _timer = GetComponent<CountdownTimer>();
        _gameEnded = false;

        EventManager.GameWinned.AddListener(HandleGameFinished);
        EventManager.GameLost.AddListener(HandleGameFinished);
    }

    void Update()
    {
        if (_gameEnded) return;

        if (_timer.Running())
        {
            DisplayTime(_timer.GetMinutes(), _timer.GetSeconds());
        }
        else
        {
            EventManager.CountdownFinished.Invoke();
        }
    }

    void DisplayTime(int minutes, int seconds)
    {
        string formattedMinutes = minutes.ToString().PadLeft(2, '0');
        string formattedSeconds = seconds.ToString().PadLeft(2, '0');
        _text.text = $"{formattedMinutes}:{formattedSeconds}";
    }

    void HandleGameFinished()
    {
        _timer.Stop();
        _gameEnded = true;
    }
}
