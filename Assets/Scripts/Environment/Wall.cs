using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Wall : MonoBehaviour
{
    private static bool _canTeleport = true;
    private float _posX, _posY;

    private void Start()
    {
        _posX = transform.position.x;
        _posY = transform.position.y;
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            GameObject player = collision.gameObject;

            if (_posX < 1 && _posX > -1 && _canTeleport)
            {
                _canTeleport = false;
                float playerNewYPos = -_posY;
                player.transform.position = new Vector3(player.transform.position.x, playerNewYPos, player.transform.position.z);
                StartCoroutine(CantTeleport());
            }

            if (_posY > -1 && _posY < 1 && _canTeleport)
            {
                _canTeleport = false;
                float playerNewXPos = -_posX;
                player.transform.position = new Vector3(playerNewXPos, player.transform.position.y, player.transform.position.z);
                StartCoroutine(CantTeleport());
            }
        }

        if (collision.gameObject.tag == "Bullet")
            Destroy(collision.gameObject);
    }

    private IEnumerator CantTeleport()
    {
        yield return new WaitForSeconds(2f);
        _canTeleport = true;
    }
}
