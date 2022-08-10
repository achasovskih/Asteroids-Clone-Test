using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour
{
    [Header("Prefabs")]
    [SerializeField] private GameObject _startScreenPrefab;
    [SerializeField] private GameObject _gameScreenPrefab;

    [Header("Models")]
    [SerializeField] private ViewModel _viewModel;
    [SerializeField] private PlayerModel _playerModel;
    [SerializeField] private EnemyModel _enemyModel;

    [SerializeField] private GameObject _spawnedPlayer;

    [Header("Canvas")]
    [SerializeField] private Canvas _targetCanvas;

    private GameObject _startScreenObject, _gameScreenObject;

    private void Start()
    {
        _startScreenObject = _viewModel.SetScreen(_startScreenPrefab, _targetCanvas.transform);
        _startScreenObject.GetComponent<StartScreenController>().OnDestroyStart += ChangeScreen;
        _startScreenObject.GetComponent<StartScreenController>().OnDestroyEnd += SetUpPlayer;
        _startScreenObject.GetComponent<StartScreenController>().OnDestroyEnd += _enemyModel.StartEnemySpawn;
    }

    private void ChangeScreen()
    {
        _gameScreenObject = _viewModel.SetScreen(_gameScreenPrefab, _targetCanvas.transform);
        _gameScreenObject.transform.SetAsFirstSibling();
        _startScreenObject.GetComponent<StartScreenController>().OnDestroyStart -= ChangeScreen;
    }

    private void SetUpPlayer()
    {
        _spawnedPlayer = _playerModel.SpawnPlayer(transform);
        _enemyModel.player = _spawnedPlayer;
    }
}
