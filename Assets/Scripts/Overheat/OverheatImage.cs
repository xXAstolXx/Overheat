using UnityEngine;
using UnityEngine.UI;

public class OverheatImage : MonoBehaviour
{
    private Image image;

    public float OverHeatAmount{get{return image.fillAmount;}}

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
        if(amount == 0)
        {
            return;
        }
        image.fillAmount -= amount;
    }
}
