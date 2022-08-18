using System.Collections;
using System.Collections.Generic;
using UnityEngine;


/// <summary>
///  ласс, отвечающий за логику игры и внедр€щий зависимости обособленным друг от друга компонентам
/// </summary>
public class GameController : MonoBehaviour
{
    [Header("Prefabs")]
    [SerializeField] private GameObject _startScreenPrefab;
    [SerializeField] private GameObject _gameScreenPrefab;

    [Header("Reference scripts")]
    [SerializeField] private ViewModel _viewModel;
    [SerializeField] private PlayerController _playerController;
    [SerializeField] private EnemySpawner _enemySpawner;

    [SerializeField] private PlayerModel _player;

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
        _enemySpawner.GameScreenController = _gameScreenObject;

        _gameScreenObject.OnScreenDestroy += Lose;
        _startScreenObject.OnDestroyStart -= SetGameScreen;
    }

    private void SetUpPlayer()
    {
        _playerController.GameScreen = _gameScreenObject;
        _playerController.SpawnPlayer();
        _enemySpawner.Player = _playerController.SpawnedPlayer.gameObject;

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
