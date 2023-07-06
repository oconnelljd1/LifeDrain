using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LifeTracker : Tracker
{
    
    public override void Reset()
    {
        base.trackedVal = AppController.Instance.MaxLife;
        UpdateDisplay();
    }

    protected override void UpdateDisplay()
    {
        base._display.text = base.trackedVal + "";

        base._addButton.SetActive(true);
        base._subtractButton.SetActive(true);

        base._display.color = Color.white;

        if(base.trackedVal == 0)
        {
            base._subtractButton.SetActive(false);
            base._display.color = Color.red;
        }

        Debug.Log(base._subtractButton.transform.parent.gameObject.name);
        // Debug.Log($"<color=orange>Lifetracker Reset</color>");
    }
}
