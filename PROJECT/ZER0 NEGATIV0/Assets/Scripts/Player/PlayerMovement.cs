using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] public float speed;
    
    private Rigidbody2D _rigidbody;
    private Animator _playerAnim;
    private static readonly int Walk = Animator.StringToHash("Walk");
    private static readonly int Idle = Animator.StringToHash("Idle");

    private void Awake()
    {
        _rigidbody = GetComponent<Rigidbody2D>();
        _playerAnim = GetComponent<Animator>();
    }

    private void Update()
    {
        OnMovement();
        OnJump();
    }

    private void OnMovement()
    {
        var horizontalInput = Input.GetAxis("Horizontal");

        if (horizontalInput != 0)
        {
            _playerAnim.SetTrigger(Walk);
        }
        else
        {
            _playerAnim.SetTrigger(Idle);
        }

        _rigidbody.velocity = new Vector2(horizontalInput * speed, _rigidbody.velocity.y);
        
    }

    private void OnJump()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            _playerAnim.SetTrigger("Jump");
            _rigidbody.velocity = new Vector2(_rigidbody.velocity.x, speed * 2);
        }
    }
}
