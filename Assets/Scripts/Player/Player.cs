using UnityEngine;

public class Player : Collector
{
    [SerializeField]
    private float moveSpeed = 5f;

    private BackPack backPack;

    private Vector2 moveDirection;

    void Start()
    {
        backPack = GetComponentInChildren<BackPack>();
    }

    public void UpdateMoveInput(Vector2 movementVector)
    {
        if(movementVector.magnitude != 0)
        {
            moveDirection = movementVector;
        }
        else
        {
            moveDirection = Vector2.zero;
        }
    }

    private void Move()
    {
        Vector2 moveVector = moveDirection;

        transform.Translate(moveVector * moveSpeed * Time.deltaTime);
    }

    void Update()
    {
        //float horizontalInput = Input.GetAxis("Horizontal");
        //float verticalInput = Input.GetAxis("Vertical");

        //Vector2 movement = new Vector2(horizontalInput, verticalInput);
        //transform.Translate(movement * moveSpeed * Time.deltaTime);
        Move();
    }

#region Collect Resource
    public override void TryCollect(RessourceInteracable ressourceInteracable, RessourceData ressourceData)
    {
        Debug.Log($"Collided with {ressourceInteracable.name}");

        if(backPack.ressourceDatas.Count >= 1)
        {
            return;
        }

        Collect(ressourceInteracable.gameObject, ressourceData);

    }

    protected override void Collect(GameObject target, RessourceData data)
    {
        backPack.ressourceDatas.Add(data);
        TransformTarget(target);
    }

    private void TransformTarget(GameObject target)
    {
        target.transform.localPosition = new Vector3(0,0,0);
        target.transform.SetParent(backPack.gameObject.transform, false);
        target.gameObject.transform.localScale = new Vector3(0.5f, 0.5f, 1);
    }

    #endregion

    #region Interact with Building
    public override void TryInteract(ResourceType coolingResourceType)
    {
        if(backPack.ressourceDatas.Count == 1 && backPack.ressourceDatas[0].Type == coolingResourceType)
        {
            RemoveItemfromBackPack();
        }
        return;
    }

    private void RemoveItemfromBackPack()
    {
        backPack.ressourceDatas.RemoveAt(0);
        backPack.DestroyItemInBackPack();
    }

    public ResourceType GetCoolingRessourceType()
    {
        return backPack.ressourceDatas[0].Type;
    }

    public float GetResourceDataAmountFromBackPack()
    {
        if(backPack.ressourceDatas.Count >= 1)
        {
            return backPack.ressourceDatas[0].Amount;
        }
        return 0f;
    }

    #endregion




}
