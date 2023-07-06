using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System;
using System.Linq;

public class Player : MonoBehaviour
{
    [Header("Object References")]
    [SerializeField] private Image _mat;
    [SerializeField] private Transform _lifeTrackerParent;
    [SerializeField] private GameObject _settings;
    [SerializeField] private Scrollbar _scrollBar;
    [SerializeField] private List<ColorToggle> _toggles;
    [SerializeField] private List<Tracker> _trackers;

    [Header("Asset References")]
    [SerializeField] private GameObject _commanderTrackerPrefab;

    private int playerIndex;

    public void Init(int index)
    {
        playerIndex = index;
        for(int i = 0; i < AppController.Instance.NumPlayers; i++)
        {
            if(i == index) continue;

            GameObject trackerGO = UnityEngine.Object.Instantiate(_commanderTrackerPrefab, _lifeTrackerParent);
            trackerGO.transform.SetSiblingIndex(1);

            CommanderTracker cTracker = trackerGO.GetComponent<CommanderTracker>();
            cTracker.Init(i); // needs to be updated with players mat

            Tracker lTracker = cTracker as Tracker;
            _trackers.Add(lTracker);
        }

        for( int o = 0; o < _toggles.Count; o++)
        {
            _toggles[o].Init(this, o);
        }

        _scrollBar.numberOfSteps = _lifeTrackerParent.childCount;
        _scrollBar.value = 1f;

        _settings.gameObject.SetActive(false);
    }

    public void PostInit()
    {
        _toggles[playerIndex].SetIsOn(true);
    }

    public void Reset()
    {
        foreach(var tracker in _trackers)
        {
            tracker.Reset();
        }
    }

    public void UpdateMat(int spriteId)
    {
        _mat.sprite = AppController.Instance.Sprites[spriteId];

        // call event with id and sprite Id
        AppController.Events.MatChanged(playerIndex, spriteId);
    }

    public void ToggleBackground()
    {
        _settings.SetActive(!_settings.activeInHierarchy);
    }

}
