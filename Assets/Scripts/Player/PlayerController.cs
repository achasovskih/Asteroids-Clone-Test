using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : PlayerModel
{
    private GameObject _playerObject;

    public override GameObject SpawnPlayer(GameObject playerPrefab, Transform parent)
    {
        _playerObject = Instantiate(playerPrefab, parent);
        return _playerObject;
    }

}

public abstract class PlayerModel : MonoBehaviour
{
    public abstract GameObject SpawnPlayer(GameObject playerPrefab, Transform parent);
}
