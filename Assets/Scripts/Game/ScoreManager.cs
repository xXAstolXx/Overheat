using UnityEngine;

public class ScoreManager : MonoBehaviour
{
    #region Singleton
    private static ScoreManager instance;
    public static ScoreManager Instance
    {
        get
        {
            return instance;
        }
    }
    #endregion

    private void Awake()
    {
        instance = this;
    }

    [SerializeField]
    private int incomeModifer;
    [SerializeField]
    private int incomeModiferIncrease = 1;
    [SerializeField]
    private int baseIncome = 500;
    private int income;
    public int Income { get => income; set => income = value; }

    private void Start()
    {
        income = 0;
        Game.Instance.OnGameWon.AddListener(CalculateScore);
    }

    private void CalculateScore()
    {
        income = baseIncome;
        income += incomeModifer;
    }

    public void IncreaseIncomeModifer()
    {
        incomeModifer += incomeModiferIncrease / 10;
        
    }


}
