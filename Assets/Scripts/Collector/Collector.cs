using UnityEngine;

public class Collector : MonoBehaviour
{
    public virtual void TryCollect(RessourceInteracable ressourceInteracable, RessourceData data)
    {

    }
    public virtual void Collect(GameObject target, RessourceData data)
    {

    }
    public virtual void TryInteract(ResourceType resourceType)
    {}

}

