using UnityEngine;
using UnityEngine.UI;

public class OverheatImage : MonoBehaviour
{
    private Image image;


    private void Start() 
    {
        image = GetComponent<Image>();
    }

    public void IncreaseOverheating(float amount)
    {
        image.fillAmount += amount;
    }

    public void DecreaseOverheating(float amount)
    {
        image.fillAmount -= amount;
    }
}
