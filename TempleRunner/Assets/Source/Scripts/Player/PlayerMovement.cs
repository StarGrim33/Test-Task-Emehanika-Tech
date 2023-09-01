using UnityEngine;

[RequireComponent(typeof(SwipeMovement))]
public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private float _speedIncreaseRate = 0.1f;

    private float _maxSpeed = 40f;
    private SwipeMovement _swipeMovement;
    private CharacterController _controller;
    private Vector3 _direction;
    private float _speed = 10f;
    private int _lineToMove = 1;
    private float _jumpForce = 10f;
    private float _gravity = -20f;

    public float LineDistance => 4;

    private void Start()
    {
        _controller = GetComponent<CharacterController>();
        _swipeMovement = GetComponent<SwipeMovement>();
    }

    private void Update()
    {
        if (GameStateHandler.Instance.CurrentGameState == GameState.Pause)
            return;

        if (_swipeMovement.SwipeRight)
            if (_lineToMove < 2)
                _lineToMove++;

        if (_swipeMovement.SwipeLeft)
            if (_lineToMove > 0)
                _lineToMove--;

        if (_swipeMovement.SwipeUp)
            if (_controller.isGrounded)
                Jump();

        if (_speed < _maxSpeed)
            _speed += _speedIncreaseRate * Time.deltaTime;

        Vector3 targetPosition = transform.position.z * transform.forward + transform.position.y * transform.up;

        if (_lineToMove == 0)
            targetPosition += Vector3.left * LineDistance;
        else if (_lineToMove == 2)
            targetPosition += Vector3.right * LineDistance;

        transform.position = targetPosition;
    }

    private void Jump()
    {
        _direction.y = _jumpForce;
    }

    private void FixedUpdate()
    {
        if (GameStateHandler.Instance.CurrentGameState == GameState.Pause)
            return;

        _direction.z = _speed;
        _direction.y += _gravity * Time.fixedDeltaTime;
        _controller.Move(_direction * Time.fixedDeltaTime);
    }
}
