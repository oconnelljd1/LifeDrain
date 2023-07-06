using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Tracker : MonoBehaviour
{
    [SerializeField] protected TMP_Text _display;
    [SerializeField] protected GameObject _addButton;
    [SerializeField] protected GameObject _subtractButton;

    protected int trackedVal;

    public virtual void Start()
    {
        Reset();
    }

    public virtual void Reset()
    {
        UpdateDisplay();
    }

    public virtual void Add()
    {
        trackedVal++;

        UpdateDisplay();
    }

    public virtual void Subtract()
    {
        trackedVal--;

        UpdateDisplay();
    }

    protected virtual void UpdateDisplay()
    {
        _display.text = trackedVal + "";

        Debug.Log(trackedVal);
    }
}
