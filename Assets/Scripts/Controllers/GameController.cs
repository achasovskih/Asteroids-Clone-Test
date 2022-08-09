using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour
{
    [Header("Prefabs")]
    [SerializeField] private GameObject _startScreenPrefab;
    [SerializeField] private GameObject _gameScreenPrefab;
    [SerializeField] private ViewModel _viewModel;

    [Header("Canvas")]
    [SerializeField] private Canvas _targetCanvas;

    private GameObject _startScreenObject, _gameScreenObject;

    private void Start()
    {
        _startScreenObject = _viewModel.SetScreen(_startScreenPrefab, _targetCanvas.transform);
        _startScreenObject.GetComponent<StartScreenController>().OnStartScreenDestroy += ChangeScreen;
    }

    private void ChangeScreen()
    {
        _gameScreenObject = _viewModel.SetScreen(_gameScreenPrefab, _targetCanvas.transform);
    }
}
