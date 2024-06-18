using System;
using UnityEngine;

namespace Game.Player
{
    public class PlayerMovement : MonoBehaviour
    {
        private Rigidbody2D _rb2d;
        private Animator _animator;

        private Vector2 _velocity;

        [SerializeField] private float speed = default;
        [SerializeField] private float acceleration = default;
        [SerializeField] private float deceleration = default;
        [SerializeField] private float jumpForce = default;
        [SerializeField] private int jumpLimit = default;
        [SerializeField] private int jumpCount = default;
        private static readonly int Walk = Animator.StringToHash("Walk");
        private static readonly int Jump = Animator.StringToHash("Jump");
        private Joystick _joystick;
        private JoystickButton _joystickButton;
        private bool _isJumping;
        


        private void Start()
        {
            _joystickButton = FindObjectOfType<JoystickButton>();
            _rb2d = GetComponent<Rigidbody2D>();
            _animator = GetComponent<Animator>();
            _joystick = FindObjectOfType<Joystick>();
        }

        private void Update()
        {
#if UNITY_EDITOR
            KeyboardController();
#else
            JoystickController();
#endif
        }

        private void KeyboardController()
        {
            float movementInput = Input.GetAxisRaw("Horizontal");
            Vector2 scale = transform.localScale;

            if (movementInput > 0)
            {
                _velocity.x = Mathf.MoveTowards(_velocity.x, movementInput * speed, acceleration * Time.deltaTime);
                _animator.SetBool(Walk, true);
                scale.x = 0.3f;
            }
            else if(movementInput < 0)
            {
                _velocity.x = Mathf.MoveTowards(_velocity.x, movementInput * speed, acceleration * Time.deltaTime);
                _animator.SetBool(Walk, true);
                scale.x = -0.3f;
            }
            else
            {
                _velocity.x = Mathf.MoveTowards(_velocity.x, 0, deceleration * Time.deltaTime);
                _animator.SetBool(Walk, false);
            }

            transform.localScale = scale;
            transform.Translate(_velocity * Time.deltaTime);

            if (Input.GetKeyDown("space"))
            {
                StartJump();
            }

            if (Input.GetKeyUp("space"))
            {
                StopJump();
            }
        }

        private void JoystickController()
        {
            float movementInput = _joystick.Horizontal;
            Vector2 scale = transform.localScale;

            if (movementInput > 0)
            {
                _velocity.x = Mathf.MoveTowards(_velocity.x, movementInput * speed, acceleration * Time.deltaTime);
                _animator.SetBool(Walk, true);
                scale.x = 0.3f;
            }
            else if (movementInput < 0)
            {
                _velocity.x = Mathf.MoveTowards(_velocity.x, movementInput * speed, acceleration * Time.deltaTime);
                _animator.SetBool(Walk, true);
                scale.x = -0.3f;
            }
            else
            {
                _velocity.x = Mathf.MoveTowards(_velocity.x, 0, deceleration * Time.deltaTime);
                _animator.SetBool(Walk, false);
            }

            transform.localScale = scale;
            transform.Translate(_velocity * Time.deltaTime);

            if (_joystickButton.isPressed == true && _isJumping == false)
            {
                _isJumping = true;
                StartJump();
            }

            if (_joystickButton.isPressed == false && _isJumping == true)
            {
                _isJumping = false;
                StopJump();
            }
        }

        private void StartJump()
        {
            if (jumpCount < jumpLimit)
            {
                _rb2d.AddForce(new Vector2(0, jumpForce), ForceMode2D.Impulse);
                _animator.SetBool(Jump, true);
                FindObjectOfType<JumpSlider>().SliderValue(jumpLimit, jumpCount);
            }
        }

        private void StopJump()
        {
            _animator.SetBool(Jump, false);
            jumpCount++;
            FindObjectOfType<JumpSlider>().SliderValue(jumpLimit, jumpCount);
        }

        public void JumpReset()
        {
            jumpCount = 0; 
            FindObjectOfType<JumpSlider>().SliderValue(jumpLimit, jumpCount);
        }

        private void OnCollisionEnter2D(Collision2D other)
        {
            if (other.gameObject.CompareTag("DeathPoint"))
            {
                FindObjectOfType<GameController>().EndGame();
            }
        }

        public void GameOver()
        {
            Destroy(gameObject);
        }
    }
}
