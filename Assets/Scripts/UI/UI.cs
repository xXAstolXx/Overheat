using UnityEngine;

public class UI : MonoBehaviour
{
    private WinMenu winMenu;
    private GameOverMenu gameOverMenu;
    private Textlabel earningTxt;
    public WinMenu WinMenu { get => winMenu; }
    public GameOverMenu GameOverMenu { get => gameOverMenu; }
    public Textlabel EarningTxt { get => earningTxt; }

    #region Singleton
    private static UI instance;

    public static UI Instance
    {
        get { return instance; }
    }
    private void Awake()
    {
        if(instance != null && instance != this) 
        {
            Destroy(this);
        }
        else
        {
           instance = this;
        }
        Initialize();
    }
    #endregion

    private void Initialize()
    {
        winMenu = GetComponentInChildren<WinMenu>();
        gameOverMenu = GetComponentInChildren<GameOverMenu>();
        earningTxt = GetComponentInChildren<Textlabel>();
    }
}
