using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class PlayerOffsetCounter : MonoBehaviour
{
    GameManager gameManager;
    float songBeat;
    float playerBeat;
    Queue beatDifferences;
    float playerOffset;


    private void Start()
    {
        gameManager = GameObject.FindObjectOfType<GameManager>();

        beatDifferences = new Queue();
    }


    void Update()
    {
        PlayerTapped();
    }


    // this should accept a time and then be called by the player controller or something
    private void PlayerTapped()
    {
        if (Input.anyKeyDown)
        {
            // time that the player thinks is the beat
            playerBeat = gameManager.conductor.GetTime();

            // time that the game thinks is the beat (use previous beat to see if player hits too early for some reason?)
            songBeat = gameManager.conductor.currentBeatTime;

            float beatDifference = playerBeat - songBeat;

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
