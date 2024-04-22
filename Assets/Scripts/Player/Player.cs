using UnityEngine;

public class Player : Collector
{
    [SerializeField]
    private float moveSpeed = 5f;
    [SerializeField]
    private float rotationSpeed;
    private BackPack backPack;

    private Vector2 moveDirection;

    private Rigidbody2D rb;

    [SerializeField]
    private Bullet[] bullets = new Bullet[3];
    [SerializeField]
    private Transform bulletShootPoint;

    void Start()
    {
        backPack = GetComponentInChildren<BackPack>();
        rb = GetComponent<Rigidbody2D>();
    }
    void FixedUpdate()
    {
        Move();
        RotateInDirectionOfInput();
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
        rb.velocity = moveVector * moveSpeed * Time.fixedDeltaTime;
    }

    private void RotateInDirectionOfInput()
    {
        if(moveDirection != Vector2.zero)
        {
            Quaternion targetRoatation = Quaternion.LookRotation(transform.forward, moveDirection);
            Quaternion rotation = Quaternion.RotateTowards(transform.rotation, targetRoatation, rotationSpeed * Time.fixedDeltaTime);
            rb.MoveRotation(rotation);
        }
    }

    //Shoot Function in diffrent Function seperaten 
    public void OnShootPressed() 
    {
        if(backPack.ressourceDatas.Count >= backPack.MaxCapacity)
        {
            switch (backPack.ressourceDatas[0].Type)
            {
                case ResourceType.TRIANGLE:
                    Debug.Log("Triangle Munition");
                    Instantiate(bullets[0].gameObject, bulletShootPoint.position, Quaternion.identity);
                    RemoveItemfromBackPack();
                    break;
                case ResourceType.SQUARE:
                    Debug.Log("Square Munition");
                    Instantiate(bullets[1].gameObject, bulletShootPoint.position, Quaternion.identity);
                    RemoveItemfromBackPack();
                    break;
                case ResourceType.DIAMOND:
                    Debug.Log("Diamond Munition");
                    Instantiate(bullets[2].gameObject, bulletShootPoint.position, Quaternion.identity);
                    RemoveItemfromBackPack();
                    break;
                case ResourceType.NONE:
                    Debug.Log("NONE MUN");
                    break;
            }
        }

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
        if(backPack.ressourceDatas.Count == backPack.MaxCapacity && backPack.ressourceDatas[backPack.MaxCapacity - 1].Type == coolingResourceType)
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
        if(backPack.ressourceDatas.Count >= backPack.MaxCapacity)
        {
            return backPack.ressourceDatas[0].Amount;
        }
        return 0f;
    }

    #endregion




}
