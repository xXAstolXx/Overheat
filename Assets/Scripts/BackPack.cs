using System;
using System.Collections;
using System.Collections.Generic;
using System.Reflection;
using Unity.VisualScripting;
using UnityEngine;

public class BackPack : MonoBehaviour
{   
    public List<RessourceData> ressourceDatas = new List<RessourceData>();

    public void DestroyItemInBackPack()
    {
        Destroy(gameObject.transform.GetChild(0).gameObject);
    }
}

