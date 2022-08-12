using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Asteroid : BaseEnemy
{
    private float _maxSize = 1f;
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

    protected override void GetDamage()
    {
        if (transform.localScale.x >= _maxSize)
        {
            CreateSplit();
            CreateSplit();
        }

        Destroy(gameObject);
    }

    private void CreateSplit()
    {
        Vector2 position = transform.position;
        position += Random.insideUnitCircle * 0.5f;

        Asteroid half = Instantiate(gameObject, position, transform.rotation).GetComponent<Asteroid>();
        half.gameObject.transform.localScale = gameObject.transform.localScale * 0.5f;
        half.gameObject.GetComponent<Rigidbody2D>().AddForce(Vector2.one * 100f, ForceMode2D.Impulse);
    }
}
