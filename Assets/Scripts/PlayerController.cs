using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    private PlayerInput PlayerIn_;
    private InputAction PlayerMove_;

    private Transform PlayerTrans_;
    private Animator PlayerAnim_;

    [SerializeField] private float PlayerSpeed_;

    void Start()
    {
        PlayerTrans_ = transform;
        PlayerIn_ = GetComponent<PlayerInput>();
        PlayerMove_ = PlayerIn_.actions["Move"];

        PlayerAnim_ = GetComponent<Animator>();
    }

    void Update()
    {
        Vector2 moveInput = PlayerMove_.ReadValue<Vector2>();
        Vector3 movement = new Vector3(moveInput.x, moveInput.y, 0) * PlayerSpeed_ * Time.deltaTime;

        // Применяем перемещение
        PlayerTrans_.Translate(movement);

        if(moveInput.x > 0)
        {
            PlayerAnim_.SetBool("isRightLeft", true);
            PlayerTrans_.localScale = new Vector3(0.75f, 0.75f, 0.75f);

        }
        else if(moveInput.x < 0) 
        {
            PlayerAnim_.SetBool("isRightLeft", true);
            PlayerTrans_.localScale = new Vector3(-0.75f, 0.75f,0.75f);
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
}
