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
        int currentHealth = playerObject.GetComponent<PlayerModel>().health -= damage;

        if (currentHealth < 0)
        {
            OnDeath?.Invoke();
            Destroy(playerObject);
        }
        else
            OnGetDamage?.Invoke(currentHealth);
    }

}

public abstract class PlayerModel : MonoBehaviour
{
    public int maxPlayerHp = 3;

    public int health = 0;

    public GameObject playerObject;

    public Action<int> OnGetDamage;

    public Action OnDeath;

    public abstract GameObject SpawnPlayer(Transform parent);

    public abstract void GetDamage(int damage);
}
