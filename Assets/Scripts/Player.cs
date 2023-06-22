using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Player : MonoBehaviour
{
    [SerializeField] private Image _mat;
    [SerializeField] private TMPro_Text _display;

    private int health;
    // Start is called before the first frame update
    void Start()
    {
        Reset();
    }

    // Update is called once per frame
    void Reset()
    {
        health = 0;

    }

    private void UpdateDisplay()
    {
        _display.text = health + "";
        if(health < 1)
            _display.color = Color.red;
        else
            _display.color = Color.white;
    }


}
