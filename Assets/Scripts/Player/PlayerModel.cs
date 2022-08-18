using UnityEngine;
using System;

public class PlayerModel : MonoBehaviour
{
    public int PlayerHp = 3;

    public Action<int> OnGetDamage;

    public Action OnDeath;

    public void GetDamage(int damage)
    {
        PlayerHp -= damage;

        if (PlayerHp < 0)
        {
            OnDeath?.Invoke();
            Destroy(gameObject);
        }
        else
            OnGetDamage?.Invoke(PlayerHp);
    }
}