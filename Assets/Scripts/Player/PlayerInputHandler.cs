using UnityEngine;

/// <summary>
/// Класс, обрабатывающий пользовательский ввод
/// </summary>
public class PlayerInputHandler : MonoBehaviour
{
    [SerializeField] private ShootController _shootController;
    private float _turnSpeed = 0.5f, _moveSpeed = 6f, _turnDirection = 0f, _moveDirection;

    private Rigidbody2D _rigidBody;

    void Awake()
    {
        _rigidBody = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        _moveDirection = Input.GetAxis("Vertical");
        _turnDirection = Input.GetAxis("Horizontal");

        if (Input.GetKeyDown(KeyCode.Space) || Input.GetMouseButtonDown(0))
        {
            Bullet bullet = _shootController.Shoot();
            bullet.Project(transform.up);
        }
    }

    void FixedUpdate()
    {
        if (_moveDirection != 0)
        {
            _rigidBody.AddForce(transform.up * _moveSpeed * _moveDirection);
        }

        if (_turnDirection != 0f)
        {
            _rigidBody.AddTorque(-_turnDirection * _turnSpeed);
        }
    }
}