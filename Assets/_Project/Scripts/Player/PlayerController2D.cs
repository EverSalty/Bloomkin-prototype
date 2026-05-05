using UnityEngine;
using UnityEngine.InputSystem;
using Bloomkin.Core;

namespace Bloomkin.Player
{
    /// <summary>
    /// Top-down 2D movement via new Input System.
    /// PlayerInput Behavior: "Invoke Unity Events"
    /// Wire OnMove, OnSprint, and OnInteract in the Inspector.
    /// </summary>
    [RequireComponent(typeof(Rigidbody2D))]
    [RequireComponent(typeof(PlayerInput))]
    public class PlayerController2D : MonoBehaviour
    {
        [Header("Movement")]
        [SerializeField] private float _moveSpeed   = 5f;
        [SerializeField] private float _sprintSpeed = 9f;

        [Header("References")]
        [SerializeField] private Animator _animator;

        private Vector2 _moveInput;
        private bool    _isSprinting;
        private Rigidbody2D _rb;

        private static readonly int SpeedHash    = Animator.StringToHash("Speed");
        private static readonly int MoveXHash    = Animator.StringToHash("MoveX");
        private static readonly int MoveYHash    = Animator.StringToHash("MoveY");
        private static readonly int IsMovingHash = Animator.StringToHash("IsMoving");

        private void Awake()
        {
            _rb = GetComponent<Rigidbody2D>();
            _rb.gravityScale   = 0f;
            _rb.freezeRotation = true;
        }

        private void FixedUpdate()
        {
            if (GameManager.Instance == null || !GameManager.Instance.IsPlaying)
            {
                _rb.linearVelocity = Vector2.zero;
                return;
            }

            float speed = _isSprinting ? _sprintSpeed : _moveSpeed;
            _rb.linearVelocity = _moveInput * speed;

            UpdateAnimator();
        }

        private void UpdateAnimator()
        {
            if (_animator == null) return;

            float speed = _rb.linearVelocity.magnitude;
            _animator.SetFloat(SpeedHash, speed);
            _animator.SetBool(IsMovingHash, speed > 0.01f);

            if (_moveInput.sqrMagnitude > 0.01f)
            {
                _animator.SetFloat(MoveXHash, _moveInput.x);
                _animator.SetFloat(MoveYHash, _moveInput.y);
            }
        }

        // Called by PlayerInput Unity Events
        public void OnMove(InputAction.CallbackContext context)
        {
            _moveInput = context.ReadValue<Vector2>();
        }

        public void OnSprint(InputAction.CallbackContext context)
        {
            _isSprinting = context.performed;
        }

        public void OnInteract(InputAction.CallbackContext context)
        {
            if (context.performed)
                Debug.Log("[PlayerController2D] Interact triggered.");
        }
    }
}
