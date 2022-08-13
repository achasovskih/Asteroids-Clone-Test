using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Класс, отвечающий за обработку столкновений объектов с границами экрана
/// </summary>
public class Wall : MonoBehaviour
{
    private static bool _canTeleport = true;

    // С помощью этих переменных определяется, в какую именно "стену" врезался игрок
    private float _posX, _posY;
    private bool _xWall, _yWall;

    private void Start()
    {
        _posX = transform.position.x;
        _posY = transform.position.y;

        _xWall = _posY > -1 && _posY < 1;
        _yWall = _posX < 1 && _posX > -1;
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            GameObject player = collision.gameObject;
            Rigidbody2D rb = player.GetComponent<Rigidbody2D>();

            if (_yWall && _canTeleport)
            {
                float playerDirection = rb.velocity.y;

                // Здесь проверяется, прошел ли игрок сквозь стену полностью
                if (_posY > 0 && playerDirection < 0)
                    return;
                else if (_posY < 0 && playerDirection > 0)
                    return;

                _canTeleport = false;
                StartCoroutine(CantTeleport());
                float playerNewYPos = -_posY;
                player.transform.position = new Vector3(player.transform.position.x, playerNewYPos, player.transform.position.z);
            }

            if (_xWall && _canTeleport)
            {
                float playerDirection = rb.velocity.x;

                if (_posX > 0 && playerDirection < 0)
                    return;
                else if (_posX < 0 && playerDirection > 0)
                    return;

                _canTeleport = false;
                StartCoroutine(CantTeleport());
                float playerNewXPos = -_posX;
                player.transform.position = new Vector3(playerNewXPos, player.transform.position.y, player.transform.position.z);
            }
        }

        if (collision.gameObject.tag == "Bullet")
            Destroy(collision.gameObject);
    }

    private IEnumerator CantTeleport()
    {
        yield return new WaitForSeconds(1.5f);
        _canTeleport = true;
    }
}
