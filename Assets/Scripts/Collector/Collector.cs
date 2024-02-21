using UnityEngine;

public abstract class Collector : MonoBehaviour
{
    public virtual void TryCollect(RessourceInteracable ressourceInteracable, RessourceData data)
    {

    }
    protected abstract void Collect(GameObject target, RessourceData data);
    public virtual void TryInteract(ResourceType resourceType)
    {}

}

