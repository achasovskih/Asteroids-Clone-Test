using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : PlayerModel
{
    public override GameObject SpawnPlayer(Transform parent)
    {
        return Instantiate(playerObject, parent);
    }

    public override void GetDamage(int damage)
    {
        playerObject.GetComponent<PlayerModel>().health -= damage;
    }

}

public abstract class PlayerModel : MonoBehaviour
{
    public int health = 3;

    public GameObject playerObject;

    public abstract GameObject SpawnPlayer(Transform parent);

    public abstract void GetDamage(int damage);
}
