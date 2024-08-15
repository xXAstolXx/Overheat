namespace Overheat.Player.InputKeybindings
{
	using UnityEngine;
	using UnityEngine.InputSystem;
	using static UnityEngine.InputSystem.InputAction;

	public class PlayerKeybindings : MonoBehaviour
	{
		private PlayerControls playerInputActions; //Seperate the Input maps for future CoOP feature

		private InputAction moving;
		private InputAction shoot;

		private Player player;

		private void Awake()
		{
			playerInputActions = new PlayerControls();
			moving = playerInputActions.Keyboard.Moving;
			shoot = playerInputActions.Keyboard.Shoot;

			player = GetComponent<Player>();
		}

		private void OnEnable()
		{
			moving.Enable();
			shoot.Enable();
		}

		private void OnDisable()
		{
			moving.Disable();
			shoot.Disable();
		}

		public void Shoot( CallbackContext context )
		{
			if( shoot.enabled )
			{
				player.OnShootPressed();
			}
		}

		public void MoveInput( CallbackContext context )
		{
			if( moving.enabled )
			{
				Vector2 moveVector = context.ReadValue<Vector2>().normalized;
				player.UpdateMoveInput( moveVector );
			}
		}
	}
}

