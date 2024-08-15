using UnityEngine;

[CreateAssetMenu( fileName = "New Resource Data", menuName = "BuildingObjects/Resource Data ", order = 2 )]
public class RessourceData : ScriptableObject
{
	[SerializeField]
	private ResourceType resourceType;

	[SerializeField]
	private float amount;

	public ResourceType Type { get { return resourceType; } }
	public float Amount { get { return amount; } }
}
