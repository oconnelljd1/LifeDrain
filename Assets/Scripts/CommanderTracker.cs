using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class CommanderTracker : Tracker
{

    [SerializeField] private Image oppIcon;
    private int opponentId = 0;

    public void Init(int id)
    {
        opponentId = id;
        oppIcon.sprite = AppController.Instance.Sprites[id];

        // hook up to event
        AppController.Events.MatChangedEvent += OnMatChanged;
    }

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

        if(base.trackedVal == 21)
        {
            base._addButton.SetActive(false);
            base._display.color = Color.red;
        }

        if(base.trackedVal == 0)
        {
            base._subtractButton.SetActive(false);
        }
    }

    private void OnMatChanged(int id, int spriteId)
    {
        if(opponentId != id) return;

        oppIcon.sprite = AppController.Instance.Sprites[spriteId];
    }
}
