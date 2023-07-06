using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InfectTracker : Tracker
{

    public override void Reset()
    {
        base.trackedVal = 0;
        UpdateDisplay();
    }

    protected override void UpdateDisplay()
    {
        base._display.text = base.trackedVal + "";

        base._addButton.SetActive(true);
        base._subtractButton.SetActive(true);

        base._display.color = Color.white;

        if(base.trackedVal == 10)
        {
            base._addButton.SetActive(false);
            base._display.color = Color.red;
        }

        if(base.trackedVal == 0)
        {
            base._subtractButton.SetActive(false);
        }
    }
}
