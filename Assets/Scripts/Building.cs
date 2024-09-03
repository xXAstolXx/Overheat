namespace Overheat.Buildings.Base
{
	using Overheat.Game.TickSystem;
	using Overheat.Player;
	using Overheat.Singletons.Game;
	using Overheat.Ui.WorldUi.OverheatUi;
	using System;
    using System.Collections.Generic;
    using UnityEngine;
	using Random = UnityEngine.Random;

	internal class Building : MonoBehaviour
	{
		[SerializeField]
		private BuildingsData buildingData;

		[SerializeField]
		private ResourceType coolingResourceType;
		[SerializeField]
		private SpriteRenderer sprite;
		private bool isGenerating;

		[SerializeField]
		private CircleCollider2D outerCollider;
		[SerializeField]
		private CircleCollider2D innerCollider;

		[SerializeField]
		private float currentHeat = 0;
		[SerializeField]
		private OverheatCanvas overheatCanvas;
		internal bool isOverheated { get; private set; }

		private Dictionary<ResourceType, Color> buildingColors = new Dictionary<ResourceType, Color>();

        private void Awake()
        {
            AddBuildingColorToDict();
        }

        void Start()
        {
            //sprite = GetComponent<SpriteRenderer>();
            //outerCollider = GetComponent<CircleCollider2D>();
            //innerCollider = GetComponentInChildren<CircleCollider2D>();
            //overheatCanvas = GetComponentInChildren<OverheatCanvas>();
            isOverheated = false;
            switch (buildingData.BuildingType)
            {
                case ResourceType.TRIANGLE:
					sprite.color = buildingColors[ResourceType.TRIANGLE];
                    TickSystem(buildingData.Ticks);
                    break;
                case ResourceType.SQUARE:
					sprite.color = buildingColors[ResourceType.SQUARE];
                    TickSystem(buildingData.Ticks);
                    break;
                case ResourceType.DIAMOND:
					sprite.color = buildingColors[ResourceType.DIAMOND];
                    TickSystem(buildingData.Ticks);
                    break;
                default:
                case ResourceType.NONE:
                    sprite.color = Color.magenta;
                    throw new NotImplementedException("none BuildingData Assigned");

            }

            AddBuildingsToList();

        }

        private void AddBuildingColorToDict()
        {
            buildingColors.Add(ResourceType.TRIANGLE, buildingData.TriangleBuildingColor);
            buildingColors.Add(ResourceType.SQUARE, buildingData.SquareBuildingColor);
            buildingColors.Add(ResourceType.DIAMOND, buildingData.DiamondBuildingColor);
        }

        private void Update()
		{
			currentHeat = overheatCanvas.GetOverHeatAmount();
		}

		private void OnTriggerEnter2D( Collider2D other )
		{
			var player = other.gameObject.GetComponent<Player>();
			if( player == null ) { return; }

			float itemCoolingValue = player.GetResourceDataAmountFromBackPack();
			if( itemCoolingValue > 0f && player.GetCoolingRessourceType() == coolingResourceType )
			{
				Debug.LogWarning( "reduced overheating" );
				ReduceOverHeating( itemCoolingValue );
				player.TryInteract( coolingResourceType );
			}
		}

		private void ReduceOverHeating( float coolingValue )
		{
			overheatCanvas.DecreaseOverheating( coolingValue );
		}

		private void TickSystem( int ticksToGenerate )
		{
			TimeTickSystem.OnTick += OnTick;
			buildingData.GenTick = 0;
			buildingData.GenTickMax = ticksToGenerate;
			isGenerating = true;
		}

		private void OnTick( object sender, TimeTickSystem.OnTickEventArgs e )
		{
			if( isGenerating )
			{
				buildingData.GenTick += 1;
				var result = ResourceResult( buildingData.AmountToGenerate );
				var instatiatedPrefab = 0;
				for( int i = 0; i < result; i++ )
				{
					InstantiateResourcePrefab();
					instatiatedPrefab += buildingData.GenTick;
					OverHeating();
				}
				if( currentHeat >= 1 )
				{
					isGenerating = false;
					isOverheated = true;
				}

			}
			if( isOverheated == true && currentHeat < 1 )
			{
				isGenerating = true;
				isOverheated = false;
			}
		}


		private void AddBuildingsToList()
		{
			Game.Instance.buildings.Add( this );
		}

		private void OverHeating()
		{
			overheatCanvas.IncreaseOverheating( buildingData.OverHeatingPerTick );
		}

		private void InstantiateResourcePrefab()
		{
			Instantiate( buildingData.ItemPrefab, GenerateRandomPosition(), Quaternion.identity );
		}

		private int ResourceResult( int amount )
		{
			int result = amount;
			return result;
		}

		private Vector3 GenerateRandomPosition()
		{
			float minRadius = innerCollider.radius;
			float maxRadius = outerCollider.radius;
			float randomAngle = Random.Range( 0f, 360f );
			float randomRadius = Random.Range( minRadius, maxRadius );
			Vector3 resultVector = new Vector3( Mathf.Cos( randomAngle ) * randomRadius + transform.position.x, Mathf.Sin( randomAngle ) * randomRadius + transform.position.y, 0f );
			return resultVector;
		}

		private void OnDestroy()
		{
			TimeTickSystem.OnTick -= OnTick;
		}
	}
}

