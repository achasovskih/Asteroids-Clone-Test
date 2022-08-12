using UnityEngine;
using TMPro;
using System;

public class StartScreenController : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI _bestScore;
    [SerializeField] private Animator _animator;

    private string _bestScoreText = "Best score: ";
    public Action OnDestroyStart;
    public Action OnDestroyEnd;

    private void Start()
    {
        if (PlayerPrefs.HasKey("BestScore"))
            _bestScore.text = _bestScoreText + PlayerPrefs.GetInt("BestScore").ToString();
        else
            _bestScore.text = _bestScoreText + "0";
    }

    private void Update()
    {
        if (Input.anyKeyDown)
        {
            _animator.SetTrigger("StartFiller");
            OnDestroyStart?.Invoke();
        }
    }

    private void DestroyStartScreen()
    {
        OnDestroyEnd?.Invoke();
        Destroy(gameObject);
    }
}
