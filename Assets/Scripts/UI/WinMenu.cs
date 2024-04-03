using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class WinMenu : Screen
{
    private Textlabel earningText;

    private void Awake()
    {
        earningText = GetComponentInChildren<Textlabel>();
    }

    public override void ShowScreen()
    {
        base.ShowScreen();
        SetEarningText(ScoreManager.Instance.Income);
    }

    private void SetEarningText(int value)
    {
        earningText.SetText($"You got: {value}");
    }


}
