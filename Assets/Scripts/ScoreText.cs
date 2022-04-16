using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreText : MonoBehaviour
{
    private int _count;
    private Text _text;

    void Start()
    {
        _text = GetComponent<Text>();
        _count = 0;

        UpdateText();

        EventManager.PickedUp.AddListener(HandlePickup);
    }

    private void HandlePickup()
    {
        IncrementScore();
        UpdateText();
    }

    private void IncrementScore()
    {
        _count = _count + 1;
    }

    private void UpdateText()
    {
        _text.text = "Score: " + _count.ToString();
    }
}
