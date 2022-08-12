using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Класс компонента пули игрока
/// </summary>
public class Bullet : MonoBehaviour
{
    [SerializeField] private Rigidbody2D _rb;
    private float _bulletSpeed = 500f;

    void Start()
    {
        _rb = GetComponent<Rigidbody2D>();
    }

    public void Project(Vector2 direction)
    {
        _rb.AddForce(direction * _bulletSpeed);
    }
}
