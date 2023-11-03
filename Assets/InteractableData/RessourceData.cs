using System.Data;
using UnityEngine;

[CreateAssetMenu(fileName = "New Resource Data", menuName = "BuildingObjects/Resource Data ", order = 2)]
public class RessourceData : ScriptableObject
{
    [SerializeField]
    private ResourceType resourceType;

    [SerializeField,Range(0,10)]
    private int amount;

    public ResourceType Type{get{return resourceType;}}
    public int Amount{get{return amount;}}
}
