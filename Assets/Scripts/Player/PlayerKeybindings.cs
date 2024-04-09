using UnityEngine;
using UnityEngine.InputSystem;
using static UnityEngine.InputSystem.InputAction;

public class PlayerKeybindings : MonoBehaviour
{
    private PlayerControls playerInputActions;

    private InputAction moving;

    private Player player;

    private void Awake()
    {
        playerInputActions = new PlayerControls();

        moving = playerInputActions.Keyboard.Moving;

        player = GetComponent<Player>();
    }

    private void OnEnable()
    {
        moving.Enable();
    }

    private void OnDisable()
    {
        moving.Disable();
    }


    public void UpdateMoveInput(CallbackContext context)
    {
        if(moving.enabled)
        {
            Vector2 moveVector = context.ReadValue<Vector2>().normalized;
            Debug.Log("moveVector: " + moveVector);
            player.UpdateMoveInput(moveVector);
        }
    }
}
