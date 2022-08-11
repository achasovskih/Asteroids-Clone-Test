using System.Collections;
using System;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GameScreenController : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI _score, _healthCount;
    [SerializeField] private Animator _animator;

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
        _score.text = currentScore.ToString();
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
