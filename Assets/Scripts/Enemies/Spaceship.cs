using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spaceship : MonoBehaviour
{
    public GameObject player;
    private float _speed = 3f;
    private float _lifeTime = 10f;

    private void Start()
    {
        StartCoroutine(LifeTimeCoroutine(_lifeTime));
    }

    private void Update()
    {
        FollowPlayer();
    }

    private void FollowPlayer()
    {
        if (player != null)
        {
            Vector2 playerPos = (player.transform.position - transform.position).normalized;
            GetComponent<Rigidbody2D>().velocity = playerPos * _speed;
        }
    }

    private IEnumerator LifeTimeCoroutine(float lifeTime)
    {
        yield return new WaitForSeconds(lifeTime);
        Destroy(gameObject);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject == player.gameObject)
        {
            player.GetComponent<PlayerModel>().GetDamage(1);
            Destroy(gameObject);
        }
    }

    private void OnDestroy()
    {
        Debug.Log("I`m died");
    }
}
