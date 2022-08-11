using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Asteroid : BaseEnemy
{
    private void Start()
    {
        _speed = 3f;
        _lifeTime = 10f;

        StartCoroutine(LifeTimeCoroutine(_lifeTime));
        FollowPlayer();
    }

    protected override void OnTriggerEnter2D(Collider2D collision)
    {
        base.OnTriggerEnter2D(collision);
    }
}
