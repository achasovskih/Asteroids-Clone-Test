using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShootController : MonoBehaviour
{
    [SerializeField] private GameObject _bullet;
    [SerializeField] private Transform _bulletSpawnPoint;

    public Bullet Shoot()
    {
        Bullet bullet = Instantiate(_bullet, _bulletSpawnPoint.position, _bulletSpawnPoint.parent.rotation).GetComponent<Bullet>();
        return bullet;
    }
}
