using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterMovement : MonoBehaviour
{
    [SerializeField]
    private float velocity;
    private Rigidbody2D _rigidBody2D;
    private Vector2 _input;
    private Vector2 _movementDirection;

    public Vector2 movementDirection => _movementDirection;
    public bool isMoving => _movementDirection.magnitude > 0;

    private void Awake()
    {
        _rigidBody2D = GetComponent<Rigidbody2D>();
    }

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        _input = new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical"));

        //X
        if (_input.x > 0.1f)
        {
            _movementDirection.x = 1f;
        } else if (_input.x < -0)
        {
            _movementDirection.x = -1f;
        } else
        {
            _movementDirection.x = 0f;
        }

        //Y
        if (_input.y > 0.1f)
        {
            _movementDirection.y = 1f;
        } else if (_input.y < -0)
        {
            _movementDirection.y = -1f;
        } else
        {
            _movementDirection.y = 0f;
        }
    }

    private void FixedUpdate()
    {
        _rigidBody2D.MovePosition(_rigidBody2D.position + _movementDirection * velocity * Time.fixedDeltaTime);
    }
}
