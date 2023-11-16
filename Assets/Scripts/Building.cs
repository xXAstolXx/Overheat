using System;
using UnityEditor;
using UnityEngine;
using Random = UnityEngine.Random;

public class Building : MonoBehaviour
{
    [SerializeField]
    private BuildingsData buildingData;

    [SerializeField]
    private ResourceType coolingResourceType;
    [SerializeField]
    private int ticks; 
    private SpriteRenderer sprite;
    private bool isGenerating;
    private CircleCollider2D outerCollider;
    [SerializeField]
    private CircleCollider2D innerCollider;

    private float currentHeat = 0;

    // Start is called before the first frame update
    void Start()
    {
        sprite = GetComponent<SpriteRenderer>();
        outerCollider = GetComponent<CircleCollider2D>();
        innerCollider = GetComponentInChildren<CircleCollider2D>();

        switch (buildingData.BuildingType)
        {
            case BUILDINGTYPE.RESSOURCE:
            sprite.color = buildingData.RessourceBuildingColor;
            TickSystem(ticks);
            break;
            case BUILDINGTYPE.MONUMENT:
            sprite.color = buildingData.MonumentBuildingColor;
            TickSystem(ticks);
            break;
            case BUILDINGTYPE.WARFARE:
            sprite.color = buildingData.WarfareBuildingColor;
            break;
            case BUILDINGTYPE.NONE:
            sprite.color = Color.magenta;
            break;

        }
        
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        var player = other.gameObject.GetComponent<Player>();
        if(player == null){return;}
        int itemCoolingValue = player.GetResourceDataAmountFromBackPack();
        player.TryInteract(coolingResourceType);
        Debug.LogWarning($"itemcoolingValue: {itemCoolingValue.ToString()}");
        ResetOverHeating(itemCoolingValue); 
    }

    private void ResetOverHeating(int coolingValue)
    {
        currentHeat = Mathf.Clamp(coolingValue,0,coolingValue);
    }

    private void TickSystem( int ticksToGenerate)
    {
        buildingData.GenTick = 0;
        buildingData.GenTickMax = ticksToGenerate;
        isGenerating = true;
        TimeTickSystem.OnTick += TimeTickSystem_OnTick;
    }

    private void TimeTickSystem_OnTick(object sender, TimeTickSystem.OnTickEventArgs e)
    {
        if(isGenerating)
        {
            buildingData.GenTick += 1;
            var result = ResourceResult(buildingData.Amount);
            var instatiatedPrefab = 0;
            for(int i = 0; i < result; i++)
            {
                InstantiateResourcePrefab();
                instatiatedPrefab += buildingData.GenTick;
            }
            if(buildingData.GenTick >= buildingData.GenTickMax)
            {
                isGenerating = false;
            }
            
            Debug.Log($"genTick: {buildingData.GenTick}");
            Debug.Log($"Resource Amount Generated: {result}");
            Debug.Log($"instatedPrefab: {instatiatedPrefab}");
        }
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
        Debug.Log($"result Vector: x {resultVector.x} | y {resultVector.y} | z {resultVector.z}");
        return resultVector;
    }
}
