namespace Overheat.Player
{
    using Overheat.Extensions.ListExtensions;
    using Overheat.Interaction.Interactable;
	using Overheat.Player.InteractionSystem.Collect;
	using Overheat.Player.InventorySystem;
	using Overheat.Weapon.Bullet;
	using UnityEngine;

	internal class Player : Collector
	{
		[SerializeField]
		private float moveSpeed = 5f;
		[SerializeField]
		private float rotationSpeed;
		private BackPack backPack;

		private Vector2 moveDirection;
		private Vector2 rotationDirection;

		private Rigidbody2D rb;

		[SerializeField]
		private Bullet[] bullets = new Bullet[3];
		[SerializeField]
		private Transform bulletShootPoint;

		private void Start()
		{
			backPack = GetComponentInChildren<BackPack>();
			rb = GetComponent<Rigidbody2D>();

		}

		private void Update()
		{
			Move();
			RotateInDirectionOfInput();
		}

		internal void UpdateMoveInput( Vector2 movementVector )
		{
			if( movementVector.magnitude != 0 )
			{
				moveDirection = movementVector;
			}
			else
			{
				moveDirection = Vector2.zero;
			}
		}

		private void Move()
		{
			Vector2 moveVector = moveDirection;
			rb.velocity = moveVector * moveSpeed * Time.fixedDeltaTime;
			rotationDirection = moveVector;
		}

		private void RotateInDirectionOfInput()
		{
			if( moveDirection != Vector2.zero )
			{
				Quaternion targetRoatation = Quaternion.LookRotation( transform.forward, moveDirection );
				Quaternion rotation = Quaternion.RotateTowards( transform.rotation, targetRoatation, rotationSpeed * Time.fixedDeltaTime );
				rb.MoveRotation( rotation );
			}
		}

		//Shoot Function in diffrent Function seperaten 
		internal void OnShootPressed()
		{
			if( backPack.ressourceDatas.Count >= backPack.MaxCapacity )
			{
				var firstItemInBackpack = backPack.ressourceDatas.GetFirstOrDefault();
				switch( firstItemInBackpack.Type )
				{
					case ResourceType.TRIANGLE:
					case ResourceType.SQUARE:
					case ResourceType.DIAMOND:
						HandleResource(firstItemInBackpack.Type);
						RemoveItemfromBackPack();
						break;
					case ResourceType.NONE:
						Debug.Log( "NONE MUN" );
						break;
				}
			}

		}

		private void HandleResource( ResourceType resourceType )
		{
			int bulletIndex = resourceType switch
            {
                ResourceType.TRIANGLE => 0,
                ResourceType.SQUARE => 1,
                ResourceType.DIAMOND => 2,
                _ => -1,
            };

			if(bulletIndex >= 0 && bulletIndex < bullets.Length)
			{
                Debug.Log($"Munition Type: {resourceType}");
                Instantiate( bullets[bulletIndex].gameObject, bulletShootPoint.position, bulletShootPoint.rotation);
			}
		}

		#region Collect Resource
		internal override void TryCollect( RessourceInteracable ressourceInteracable, RessourceData ressourceData )
		{
			Debug.Log( $"Collided with {ressourceInteracable.name}" );

			if( backPack.ressourceDatas.Count >= 1 )
			{
				return;
			}

			Collect( ressourceInteracable.gameObject, ressourceData );

		}

		protected override void Collect( GameObject target, RessourceData data )
		{
			backPack.ressourceDatas.Add( data );
			TransformTarget( target );
		}

		private void TransformTarget( GameObject target )
		{
			target.transform.localPosition = new Vector3( 0, 0, 0 );
			target.transform.SetParent( backPack.gameObject.transform, false );
			target.gameObject.transform.localScale = new Vector3( 0.5f, 0.5f, 1 );
		}

		#endregion

		#region Interact with Building
		public override void TryInteract( ResourceType coolingResourceType )
		{
			if( backPack.ressourceDatas.Count == backPack.MaxCapacity && backPack.ressourceDatas[backPack.MaxCapacity - 1].Type == coolingResourceType )
			{
				RemoveItemfromBackPack();
			}
			return;
		}

		private void RemoveItemfromBackPack()
		{
			backPack.ressourceDatas.RemoveAt( 0 );
			backPack.DestroyItemInBackPack();
		}

		public ResourceType GetCoolingRessourceType()
		{
			return backPack.ressourceDatas[0].Type;
		}

		public float GetResourceDataAmountFromBackPack()
		{
			if( backPack.ressourceDatas.Count >= backPack.MaxCapacity )
			{
				return backPack.ressourceDatas[0].Amount;
			}
			return 0f;
		}

		#endregion
	}
}

