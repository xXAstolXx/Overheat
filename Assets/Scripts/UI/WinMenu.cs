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
        SetEarningText(Game.Instance.ScoreValue);
    }

    private void SetEarningText(int value)
    {
        earningText.SetText($"You got: {value}");
    }


}
