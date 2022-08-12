using UnityEngine;

public class PlayerInputHandler : MonoBehaviour
{
    [SerializeField] private ShootController _shootController;
    [SerializeField] private float _turnSpeed = 0.1f, _moveSpeed = 0.5f, _turnDirection = 0f; 

    private Rigidbody2D _rigidBody;
    private bool _isMoving;

    void Awake()
    {
        _rigidBody = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        _isMoving = Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.UpArrow);

        if (Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.LeftArrow))
            _turnDirection = 1f;
        else if (Input.GetKey(KeyCode.D) || Input.GetKey(KeyCode.RightArrow))
            _turnDirection = -1f;
        else
            _turnDirection = 0f;

        if (Input.GetKeyDown(KeyCode.Space) || Input.GetMouseButtonDown(0))
        {
            Bullet bullet = _shootController.Shoot();
            bullet.Project(transform.up);
        }
    }

    void FixedUpdate()
    {
        if (_isMoving)
        {
            _rigidBody.AddForce(this.transform.up * _moveSpeed);
        }

        if (_turnDirection != 0f)
        {
            _rigidBody.AddTorque(_turnDirection * _turnSpeed);
        }
    }
}