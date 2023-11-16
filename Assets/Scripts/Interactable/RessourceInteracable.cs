using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RessourceInteracable : MonoBehaviour
{

    [SerializeField]
    private RessourceData data;
    private CircleCollider2D interactableCollider;


    private void Awake()
    {
        interactableCollider = GetComponent<CircleCollider2D>();
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        var collector = other.gameObject.GetComponent<Collector>();
        if(collector != null)
        {
            collector.TryCollect(this, data);
        }
    }

    private void Interact(GameObject target)
    {
        gameObject.transform.localPosition = new Vector3(0,0,0); 
        transform.SetParent(target.GetComponentInChildren<BackPack>().gameObject.transform, false);
        target.gameObject.GetComponentInChildren<BackPack>().ressourceDatas.Add(data);
        gameObject.transform.localScale = new Vector3(0.5f,0.5f,1);
        Debug.Log("!!!inetracted!!!");
    }
}
