using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIController : MonoBehaviour
{
    [SerializeField] private Text _scorelable;
    [SerializeField] private SettingPopup _setting;
    public int _score;

    private void Awake()
    {
        Messenger.AddListener(GameEvent.ENEMY_HIT, OnEemyHit);
    }

    private void OnDestroy()
    {
        Messenger.RemoveListener(GameEvent.ENEMY_HIT, OnEemyHit);
    }
    private void OnEemyHit()
    {
        _score += 1;
        _scorelable.text = _score.ToString();
    }

    private void Start()
    {
        _setting.Close();
        _score = 0;
        _scorelable.text = _score.ToString();
    }

    public void OpenSettings()
    {
        _setting.Open();
    }
}
