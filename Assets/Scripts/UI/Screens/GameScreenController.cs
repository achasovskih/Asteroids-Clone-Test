using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GameScreenController : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI _score, _healthCount;

    public void ChangePlayerHealth(int currentHealth)
    {
        _healthCount.text = currentHealth.ToString();
    }
}
