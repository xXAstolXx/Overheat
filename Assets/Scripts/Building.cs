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
        outerCollider = GetComponentInChildren<CircleCollider2D>();
        Debug.Log($"Type of The Building: {buildingData.name}");
        Debug.Log($"Name of The Building: {buildingData.ObjectName}");

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

        // TimeTickSystem.OnTick += delegate (object sender, TimeTickSystem.OnTickEventArgs e)
        // {
        //     Debug.Log($"tick: {e.tick}");
        // };
        
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.gameObject.GetComponent<PlayerController>().backPack.ressourceDatas[0].Type != coolingResourceType)
        {
           return;
        }
        else
        {
            Interact(other);
        }
    }

    private void Interact(Collider2D other)
    {
        float itemCoolingValue = other.gameObject.GetComponent<PlayerController>().backPack.ressourceDatas[0].Amount;
        currentHeat = Mathf.Clamp(itemCoolingValue,0,itemCoolingValue);
        other.gameObject.GetComponent<PlayerController>().backPack.ressourceDatas.RemoveAt(0);
        Destroy(other.gameObject.GetComponent<PlayerController>().backPack.transform.GetChild(0).gameObject);
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
            var test = ResourceResult(buildingData.Amount);
            var instatiatedPrefab = 0;
            for(int i = 0; i < test; i++)
            {
                InstantiateResourcePrefab();
                instatiatedPrefab += buildingData.GenTick;
            }
            if(buildingData.GenTick >= buildingData.GenTickMax)
            {
                isGenerating = false;
            }
            
            Debug.Log($"genTick: {buildingData.GenTick}");
            Debug.Log($"Resource Amount Generated: {test}");
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
        float minRadius = outerCollider.radius;
        float maxRadius = outerCollider.radius;
        Debug.Log("min radius: " + minRadius);
        Debug.Log("max radius: " + maxRadius);
        float randomAngle = Random.Range(0f,360f);
        float randomRadius = Random.Range(minRadius,maxRadius);
        Vector3 resultVector = new Vector3(Mathf.Cos(randomAngle)*randomRadius+transform.position.x,Mathf.Sin(randomAngle)*randomRadius+transform.position.y,0f);
        Debug.Log($"result Vector: x {resultVector.x} | y {resultVector.y} | z {resultVector.z}");
        return resultVector;
    }
}
