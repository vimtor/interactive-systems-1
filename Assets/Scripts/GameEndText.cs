using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameEndText : MonoBehaviour
{
    public float speed = 1f;
    public string winMessage = "You Win!";
    public Color winColor = Color.green;
    public string loseMessage = "You Lost!";
    public Color loseColor = Color.red;

    private float _t = 0;
    private bool _visible = false;
    private Text _text;

    void Start()
    {
        _text = GetComponent<Text>();

        SetOpacity(0.0f);

        EventManager.GameWinned.AddListener(HandleGameWinned);
        EventManager.GameLost.AddListener(HandleGameLost);
    }

    void Update()
    {
        if (_visible)
        {
            _t += Time.deltaTime * speed;
            SetOpacity(Mathf.PingPong(_t, 1f));
        }
    }

    void HandleGameWinned()
    {
        _visible = true;
        SetText(winMessage, winColor);
    }

    void HandleGameLost()
    {
        _visible = true;
        SetText(loseMessage, loseColor);
    }

    void SetText(string text, Color color)
    {
        _text.text = text;
        _text.color = color;
    }

    void SetOpacity(float alpha)
    {
        Color color = _text.color;
        color.a = alpha;
        _text.color = color;
    }
}
