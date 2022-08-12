using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Класс, описывающий сущность врага-астероида
/// </summary>
public class Asteroid : BaseEnemy
{
    private float _maxSize = 1f;
    private int _bigAsteroidPoints = 50, _smallAsteroidPoints = 25;
    private bool _canHit = true;

    protected override void Start()
    {
        base.Start();

        _speed = 1f;
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
            OnGetDamage?.Invoke(_bigAsteroidPoints);
            _canHit = false;
        }

        if (_canHit)
            OnGetDamage?.Invoke(_smallAsteroidPoints);
        Destroy(gameObject);
    }

    private void CreateSplit()
    {
        Vector2 position = transform.position;
        position += Random.insideUnitCircle * 2f;

        Asteroid half = Instantiate(gameObject, position, transform.rotation).GetComponent<Asteroid>();
        half.gameObject.transform.localScale = gameObject.transform.localScale * 0.5f;
        half.gameObject.GetComponent<Rigidbody2D>().AddForce(Vector2.one * 100f, ForceMode2D.Impulse);
    }
}
