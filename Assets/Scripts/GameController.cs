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

    private StartScreenController _startScreenObject;
    private GameScreenController _gameScreenObject;

    private void Start()
    {
        _startScreenObject = _viewModel.SetScreen(_startScreenPrefab, _targetCanvas.transform).GetComponent<StartScreenController>();
        StartScreenSubsribingMethod();
    }

    private void ChangeScreen()
    {
        _gameScreenObject = _viewModel.SetScreen(_gameScreenPrefab, _targetCanvas.transform).GetComponent<GameScreenController>();
        _gameScreenObject.transform.SetAsFirstSibling();
        _startScreenObject.OnDestroyStart -= ChangeScreen;
    }

    private void SetUpPlayer()
    {
        _spawnedPlayer = _playerModel.SpawnPlayer(transform);
        _enemyModel.player = _spawnedPlayer;
        _spawnedPlayer.GetComponent<PlayerModel>().OnGetDamage += _gameScreenObject.ChangePlayerHealth;
    }

    private void StartScreenSubsribingMethod()
    {
        _startScreenObject.OnDestroyStart += ChangeScreen;
        _startScreenObject.OnDestroyEnd += SetUpPlayer;
        _startScreenObject.OnDestroyEnd += _enemyModel.StartEnemySpawn;
    }
}
