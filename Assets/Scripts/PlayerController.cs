using UnityEngine;
using UnityEngine.InputSystem;
public class PlayerController : MonoBehaviour
{
    private PlayerInput PlayerIn_;
    private InputAction PlayerMove_;

    private Transform PlayerTrans_;

    [SerializeField] private float PlayerSpeed_;

    void Start()
    {
        PlayerTrans_ = transform;
        PlayerIn_ = GetComponent<PlayerInput>();
        PlayerMove_ = PlayerIn_.actions["Move"];
    }

    void Update()
    {
        Vector2 moveInput = PlayerMove_.ReadValue<Vector2>();
        Vector3 movement = new Vector3(moveInput.x, moveInput.y, 0) * PlayerSpeed_ * Time.deltaTime;

        // Применяем перемещение
        PlayerTrans_.Translate(movement);
    }
}
