using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spaceship : MonoBehaviour
{
    public GameObject player;
    private float _speed = 3f;

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

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject == player.gameObject)
        {
            player.GetComponent<PlayerModel>().GetDamage(1);
            Destroy(gameObject);
        }
    }
}
