using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Wall : MonoBehaviour
{
    //[SerializeField] private Collider2D _collider2D;

    //private bool _canTeleport = true;
    //private float _posX, _posY;
    //private const float _offset = 4f;

    //private void Start()
    //{
    //    _collider2D = GetComponent<Collider2D>();

    //    _posX = transform.position.x;
    //    _posY = transform.position.y;

    //    Debug.Log($"{gameObject.name} X: {_posX} || Y: {_posY}");
    //}

    private void OnTriggerExit2D(Collider2D collision)
    {
        //if (collision.gameObject.tag == "Player")
        //{
        //    GameObject player = collision.gameObject;

        //    if (_posX < 1 && _posX > -1 && _canTeleport)
        //    {
        //        float playerNewYPos = -_posY * 2 + _offset;
        //        player.transform.position = new Vector3(player.transform.position.x, playerNewYPos, player.transform.position.z);
        //        StartCoroutine(CantTeleport());
        //    }

        //    if (_posY > -1 && _posY < 1 && _canTeleport)
        //    {
        //        float playerNewXPos = -_posX * 2 + _offset;
        //        player.transform.position = new Vector3(playerNewXPos, player.transform.position.y, player.transform.position.z);
        //        StartCoroutine(CantTeleport());
        //    }
        //}

        if (collision.gameObject.tag == "Bullet")
            Destroy(collision.gameObject);
    }

    //private IEnumerator CantTeleport()
    //{
    //    _canTeleport = false;
    //    yield return new WaitForSeconds(1.5f);
    //    _canTeleport = true;
    //}
}
