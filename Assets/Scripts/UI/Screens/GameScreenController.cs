using System.Collections;
using System;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

/// <summary>
/// Класс, отвечающий за игровой экран
/// </summary>
public class GameScreenController : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI _score, _healthCount;
    [SerializeField] private Animator _animator;

    private int _scoreValue = 0;
    public Action OnScreenDestroy;

    private void Start()
    {
        _animator = GetComponent<Animator>();
    }

    public void ChangePlayerHealth(int currentHealth)
    {
        _healthCount.text = currentHealth.ToString();
    }

    public void ChangePlayerScore(int currentScore)
    {
        _scoreValue += currentScore;

        if (_scoreValue > PlayerPrefs.GetInt("BestScore"))
            PlayerPrefs.SetInt("BestScore", _scoreValue);

        _score.text = _scoreValue.ToString();
    }

    public void StartLoseAnimation()
    {
        _animator.SetTrigger("Lose");
    }

    private void DestroyGameScreen()
    {
        OnScreenDestroy?.Invoke();
        Destroy(gameObject);
    }
}
