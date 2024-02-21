using System;
using UnityEngine;
using Random = UnityEngine.Random;

public class Building : MonoBehaviour
{
    [SerializeField]
    private BuildingsData buildingData;

    [SerializeField]
    private ResourceType coolingResourceType; 

    private SpriteRenderer sprite;
    private bool isGenerating;
    private CircleCollider2D outerCollider;
    [SerializeField]
    private CircleCollider2D innerCollider;

    private OverheatCanvas overheatCanvas;
    [SerializeField]
    private float currentHeat = 0;
    private OverheatImage overheatImage;
    public bool isOverheated { get; private set; }

    void Start()
    {
        sprite = GetComponent<SpriteRenderer>();
        outerCollider = GetComponent<CircleCollider2D>();
        innerCollider = GetComponentInChildren<CircleCollider2D>();
        overheatCanvas = GetComponentInChildren<OverheatCanvas>();
        overheatImage = GetComponentInChildren<OverheatImage>();
        isOverheated = false;
        switch (buildingData.BuildingType)
        {
            case ResourceType.TRIANGLE:
            sprite.color = buildingData.TriangleBuildingColor;
            TickSystem(buildingData.Ticks);
            break;
            case ResourceType.SQUARE:
            sprite.color = buildingData.SquareBuildingColor;
            TickSystem(buildingData.Ticks);
            break;
            case ResourceType.DIAMOND:
            sprite.color = buildingData.DiamondBuildingColor;
            TickSystem(buildingData.Ticks);
            break;
            default:
            case ResourceType.NONE:
            sprite.color = Color.magenta;
            throw new NotImplementedException("none BuildingData Assigned");

        }

        AddBuildingsToList();
        
    }
    private void Update() 
    {
        currentHeat = overheatCanvas.GetOverHeatAmount();
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        var player = other.gameObject.GetComponent<Player>();
        if(player == null){return;}
        
        float itemCoolingValue = player.GetResourceDataAmountFromBackPack();
        if (itemCoolingValue > 0f && player.GetCoolingRessourceType() == coolingResourceType)
        {
            Debug.LogWarning("reduced overheating");
            ReduceOverHeating(itemCoolingValue); 
            player.TryInteract(coolingResourceType);
        }
    }

    private void ReduceOverHeating(float coolingValue)
    {
         overheatCanvas.DecreaseOverheating(coolingValue);
    }

    private void TickSystem(int ticksToGenerate)
    {
        TimeTickSystem.OnTick += TimeTickSystem_OnTick;
        buildingData.GenTick = 0;
        buildingData.GenTickMax = ticksToGenerate;
        isGenerating = true;
    }

    private void TimeTickSystem_OnTick(object sender, TimeTickSystem.OnTickEventArgs e)
    {
        if(isGenerating)
        {
            buildingData.GenTick += 1;
            var result = ResourceResult(buildingData.AmountToGenerate);
            var instatiatedPrefab = 0;
            for(int i = 0; i < result; i++)
            {
                InstantiateResourcePrefab();
                instatiatedPrefab += buildingData.GenTick;
                OverHeating();
            }
            if(currentHeat >= 1)
            {
                isGenerating = false;
                isOverheated = true;
            }

        }
        if (isOverheated == true && currentHeat < 1)
        {
            isGenerating = true;
            isOverheated = false;
        }
    }


    private void AddBuildingsToList()
    {
        Game.Instance.buildings.Add(this);
    }

    private void OverHeating()
    {
        overheatCanvas.IncreaseOverheating(buildingData.OverHeatingPerTick);
    }

    private void InstantiateResourcePrefab()
    {
        Instantiate(buildingData.ItemPrefab, GenerateRandomPosition(), Quaternion.identity);
    }

    private int ResourceResult(int amount)
    {
       int result = amount;
       return result;
    }

    private Vector3 GenerateRandomPosition()
    {
        float minRadius = innerCollider.radius;
        float maxRadius = outerCollider.radius;
        float randomAngle = Random.Range(0f,360f);
        float randomRadius = Random.Range(minRadius,maxRadius);
        Vector3 resultVector = new Vector3(Mathf.Cos(randomAngle)*randomRadius+transform.position.x,Mathf.Sin(randomAngle)*randomRadius+transform.position.y,0f);
        return resultVector;
    }
}
