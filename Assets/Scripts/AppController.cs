using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AppController : MonoBehaviour
{
    [Header("Object References")]
    [SerializeField] private int test;
    [SerializeField] private List<Player> _players = new List<Player>();

    [Header("Asset References")]
    [SerializeField] public List<Sprite> Sprites;
    public int NumPlayers = 5;
    public int MaxLife = 40;

    public static AppController Instance;

    public void Awake()
    {
        if(Instance != null)
            UnityEngine.Object.Destroy(this);

        Instance = this;
    }

    public void Start()
    {
        Application.targetFrameRate = 30;
        StartCoroutine("Startup");
    }

    private IEnumerator Startup()
    {
        Init();
        yield return null;
        PostInit();
        Reset();
    }

    private void Init()
    {
        for(int i = 0; i < _players.Count; i++)
        {
            _players[i].Init(i);
        }
    }

    private void PostInit()
    {
        for(int i = 0; i < _players.Count; i++)
        {
            _players[i].PostInit();
        }
    }

    public void Reset()
    {
        for(int i = 0; i < _players.Count; i++)
        {
            _players[i].Reset();
        }
    }

    //Events Class
    public static class Events
    {
        public static event Action<int, int> MatChangedEvent;
        public static void MatChanged(int playerId, int spriteId) { if (MatChangedEvent != null) MatChangedEvent(playerId, spriteId); }


    }
}
