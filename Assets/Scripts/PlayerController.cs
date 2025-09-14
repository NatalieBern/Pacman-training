using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    private PlayerInput PlayerIn_;
    private InputAction PlayerMove_;

    private Transform PlayerTrans_;
    private Animator PlayerAnim_;
    private Rigidbody2D PlayerRb_;

    [SerializeField] private float PlayerSpeed_;
    private Vector3 PlayerSize_;

    private Vector2 moveInput;

    void Start()
    {
        PlayerTrans_ = transform;
        PlayerIn_ = GetComponent<PlayerInput>();
        PlayerMove_ = PlayerIn_.actions["Move"];

        PlayerAnim_ = GetComponent<Animator>();
        PlayerSize_ = PlayerTrans_.localScale;

        PlayerRb_ = GetComponent<Rigidbody2D>();


    }

    void Update()
    {
        moveInput = PlayerMove_.ReadValue<Vector2>();

        if(moveInput.x > 0)
        {
            PlayerAnim_.SetBool("isRightLeft", true);
            PlayerTrans_.localScale = new Vector3(PlayerSize_.x, PlayerSize_.y, PlayerSize_.z);

        }
        else if(moveInput.x < 0) 
        {
            PlayerAnim_.SetBool("isRightLeft", true);
            PlayerTrans_.localScale = new Vector3(-PlayerSize_.x, PlayerSize_.y, PlayerSize_.z);
        }
        else if (moveInput.y < 0)
        {
            PlayerAnim_.SetBool("isDown", true);
        }
        else if (moveInput.y > 0)
        {
            PlayerAnim_.SetBool("isUp", true);
        }
        else
        {
            PlayerAnim_.SetBool("isRightLeft", false);
            PlayerAnim_.SetBool("isDown", false);
            PlayerAnim_.SetBool("isUp", false);
        }
    }
    void FixedUpdate()
    {
        PlayerRb_.linearVelocity = moveInput * PlayerSpeed_;
    }
}
