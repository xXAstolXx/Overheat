using System.Collections.Generic;
using UnityEngine;

public class BackPack : MonoBehaviour
{   
    public List<RessourceData> ressourceDatas = new List<RessourceData>();

    public void DestroyItemInBackPack()
    {
        Destroy(gameObject.transform.GetChild(0).gameObject);
    }
}

