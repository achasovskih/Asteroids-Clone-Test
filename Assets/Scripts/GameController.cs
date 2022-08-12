using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour
{
    [Header("Prefabs")]
    [SerializeField] private GameObject _startScreenPrefab;
    [SerializeField] private GameObject _gameScreenPrefab;

    [Header("Reference scripts")]
    [SerializeField] private ViewModel _viewModel;
    [SerializeField] private PlayerModel _playerModel;
    [SerializeField] private EnemySpawner _enemySpawner;

    [SerializeField] private GameObject _spawnedPlayer;

    [Header("Canvas")]
    [SerializeField] private Canvas _targetCanvas;

    private StartScreenController _startScreenObject;
    private GameScreenController _gameScreenObject;

    private void Start()
    {
        SetStartScreen();
    }

    private void SetStartScreen()
    {
        _startScreenObject = _viewModel.SetScreen(_startScreenPrefab, _targetCanvas.transform).GetComponent<StartScreenController>();
        StartScreenSubsribingMethod();
    }

    private void SetGameScreen()
    {
        _gameScreenObject = _viewModel.SetScreen(_gameScreenPrefab, _targetCanvas.transform).GetComponent<GameScreenController>();
        _gameScreenObject.transform.SetAsFirstSibling();
        _gameScreenObject.ChangePlayerHealth(_playerModel.maxPlayerHp);
        _enemySpawner.GameScreenController = _gameScreenObject;

        _gameScreenObject.OnScreenDestroy += Lose;
        _startScreenObject.OnDestroyStart -= SetGameScreen;
    }

    private void SetUpPlayer()
    {
        _spawnedPlayer = _playerModel.SpawnPlayer(transform);
        _spawnedPlayer.GetComponent<PlayerModel>().health = _playerModel.maxPlayerHp;
        _enemySpawner.Player = _spawnedPlayer;
        _spawnedPlayer.GetComponent<PlayerModel>().OnGetDamage += _gameScreenObject.ChangePlayerHealth;
        _spawnedPlayer.GetComponent<PlayerModel>().OnDeath += _gameScreenObject.StartLoseAnimation;
    }

    private void StartScreenSubsribingMethod()
    {
        _startScreenObject.OnDestroyStart += SetGameScreen;
        _startScreenObject.OnDestroyEnd += SetUpPlayer;
        _startScreenObject.OnDestroyEnd += _enemySpawner.StartEnemySpawn;
    }

    private void Lose()
    {
        if (_startScreenObject == null)
        {
            SetStartScreen();
        }
    }
}
