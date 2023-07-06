using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ColorToggle : MonoBehaviour
{
    [Header("Asset Refs")]
    [SerializeField] private Toggle _toggle;
    [SerializeField] private Image _background;
    [SerializeField] private Image _selected;

    private int index;
    private Player player;

    public bool isOn
    {
        get {return _toggle.isOn;}
        set {_toggle.isOn = value;}
    }


    public void Init(Player p, int i)
    {
        player = p;
        index = i;

        _background.sprite = AppController.Instance.Sprites[i];
        _selected.sprite = AppController.Instance.Sprites[i];
    }

    public void OnToggle()
    {
        Debug.Log("OnToggle");

        if(_toggle.isOn == false) return;
        if(player == null)
        {
            Debug.Log("TEST");
            return;
        }

        player.UpdateMat(index);
    }

    public void SetIsOn(bool on)
    {
        if(_toggle.isOn == on) return;

        _toggle.isOn = on;
        OnToggle();
    }
}
