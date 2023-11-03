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
        if(!other.gameObject.CompareTag("Player")){return;}
        if(other.gameObject.GetComponentInChildren<BackPack>().ressourceDatas.Count >= 1){return;}
        Interact(other.gameObject);
        Debug.Log($"interacted WhO: {other.gameObject.name}");
    }

    private void Interact(GameObject target)
    {
        gameObject.transform.localPosition = new Vector3(0,0,0); 
        transform.SetParent(target.GetComponentInChildren<BackPack>().gameObject.transform, false);
        target.gameObject.GetComponentInChildren<BackPack>().ressourceDatas.Add(data);
        //target.gameObject.GetComponent<PlayerController>().backPack.item = this.gameObject;
        Debug.Log("!!!inetracted!!!");
    }
}
