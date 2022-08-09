using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : PlayerModel
{
    public override GameObject SpawnPlayer(GameObject playerPrefab, Transform parent)
    {
        GameObject player = Instantiate(playerPrefab, parent);
        return player;
    }

}

public abstract class PlayerModel : MonoBehaviour
{
    public abstract GameObject SpawnPlayer(GameObject playerPrefab, Transform parent);
}
