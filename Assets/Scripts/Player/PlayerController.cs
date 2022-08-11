using System.Collections;
using System;
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
        OnGetDamage?.Invoke(playerObject.GetComponent<PlayerModel>().health);
    }

}

public abstract class PlayerModel : MonoBehaviour
{
    public int health = 3;

    public GameObject playerObject;

    public Action<int> OnGetDamage;

    public abstract GameObject SpawnPlayer(Transform parent);

    public abstract void GetDamage(int damage);
}
