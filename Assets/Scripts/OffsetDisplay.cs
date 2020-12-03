using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System;

public class OffsetDisplay : MonoBehaviour
{
    TextMeshProUGUI text;
    private GameManager gameManager;
    public PlayerOffsetCounter counter;
    public HeartBeatTrigger heart;

    private void Start()
    {
        text = this.GetComponent<TextMeshProUGUI>();
    }
    public void PlayerTapped(int x, int y)
    {
        // player pressed a horizontal key
        if (x != 0)
        {
            heart.HeartBeat();
        }
    }
    private void OnEnable()
    {
        gameManager = FindObjectOfType<GameManager>();
        // start triggering on event
        gameManager.events.onPlayerMove += PlayerTapped;
    }
    private void OnDisable()
    {
        // stop triggering on event
        gameManager.events.onPlayerMove -= PlayerTapped;
    }
    private void Update()
    {
        // show only 2 first decimal
        text.text = String.Format("{0:0.00}", counter.playerOffset);
    }
}
