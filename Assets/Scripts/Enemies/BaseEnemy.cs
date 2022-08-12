using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class BaseEnemy : MonoBehaviour
{
    public GameObject player;
    protected float _speed;
    protected float _lifeTime;

    protected void FollowPlayer() 
    {
        if (player != null)
        {
            Vector2 playerPos = (player.transform.position - transform.position).normalized;
            GetComponent<Rigidbody2D>().velocity = playerPos * _speed;
        }
    }

    protected IEnumerator LifeTimeCoroutine(float lifeTime)
    {
        yield return new WaitForSeconds(lifeTime);
        Destroy(gameObject);
    }

    protected virtual void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject == player.gameObject)
        {
            player.GetComponent<PlayerModel>().GetDamage(1);
            Destroy(gameObject);
        }

        if (collision.gameObject.tag == "Bullet")
        {
            Destroy(collision.gameObject);
            GetDamage();
        }
    }

    protected abstract void GetDamage();

}
