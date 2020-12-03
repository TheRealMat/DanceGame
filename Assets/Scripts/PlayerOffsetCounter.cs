using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;
using System;

public class PlayerOffsetCounter : MonoBehaviour
{
    GameManager gameManager;
    float songBeat;
    float playerBeat;
    Queue beatDifferences;
    public float playerOffset;

    public void ApplyToSettings()
    {
        gameManager.settings.playerOffset = this.playerOffset;
        gameManager.settings.Save();
    }

    private void OnEnable()
    {
        gameManager = GameObject.FindObjectOfType<GameManager>();
        beatDifferences = new Queue();
        // start triggering on event
        gameManager.events.onPlayerMove += PlayerTapped;
    }
    private void OnDisable()
    {
        // stop triggering on event
        gameManager.events.onPlayerMove -= PlayerTapped;
    }


    // maybe this should accept a time and then be called by the player controller or something
    private void PlayerTapped(int x, int y)
    {
        // player pressed a horizontal key
        if (x != 0)
        {
            // time that the player thinks is the beat
            playerBeat = gameManager.conductor.songPosition;

            // time that the game thinks is the beat
            songBeat = gameManager.conductor.currentBeatTime;

            float lastBeatDifference = playerBeat - songBeat;
            float nextBeatDifference = Mathf.Abs(playerBeat - gameManager.conductor.nextBeatTime);


            float beatDifference = Mathf.Min(lastBeatDifference, nextBeatDifference);

            AddToQueue(beatDifference);
            playerOffset = GetAverageOffset();
        }

    }

    private void AddToQueue(float beatDifference)
    {
        if (beatDifferences.Count >= 10)
        {
            beatDifferences.Dequeue();
        }
        beatDifferences.Enqueue(beatDifference);
    }

    private float GetAverageOffset()
    {
        float averageOffset = 0;

        foreach (float offset in beatDifferences)
        {
            averageOffset += offset;
        }

        averageOffset /= beatDifferences.Count;
        return averageOffset;
    }
}
