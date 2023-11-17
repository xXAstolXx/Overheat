using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OverheatCanvas : MonoBehaviour
{
    private OverheatImage overheatImage;

    private void Start() 
    {
        overheatImage = GetComponentInChildren<OverheatImage>();
    }

    public void IncreaseOverheating(float amount)
    {
        overheatImage.IncreaseOverheating(amount);
    }
}
