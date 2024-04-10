using System.Collections.Generic;
using UnityEngine;

public class BackPack : MonoBehaviour
{   
    public List<RessourceData> ressourceDatas = new List<RessourceData>();
    [SerializeField]
    private int maxCapacity = 1;

    public int MaxCapacity { get => maxCapacity; }

    public void DestroyItemInBackPack()
    {
        Destroy(gameObject.transform.GetChild(0).gameObject);
    }
}

