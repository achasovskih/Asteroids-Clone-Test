using System.Collections;
using System;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Класс, отвечающий за основные функции игрока
/// </summary>
public class PlayerController : MonoBehaviour
{
    [SerializeField] private GameObject _playerPrefab;
    public PlayerModel SpawnedPlayer;
    public GameScreenController GameScreen;

    public void SpawnPlayer()
    {
        SpawnedPlayer = Instantiate(_playerPrefab).GetComponent<PlayerModel>();
        GameScreen.ChangePlayerHealth(SpawnedPlayer.PlayerHp);

        SpawnedPlayer.OnGetDamage += GameScreen.ChangePlayerHealth;
        SpawnedPlayer.OnDeath += GameScreen.StartLoseAnimation;

    }
}
