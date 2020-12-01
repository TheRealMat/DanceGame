using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class PlayerOffsetCounter : MonoBehaviour
{
    Conductor conductor;
    float songBeat;
    float playerBeat;
    Queue beatDifferences;
    float playerOffset;


    private void Start()
    {
        beatDifferences = new Queue();


        conductor = GameObject.FindObjectOfType<Conductor>();
    }


    void Update()
    {
        PlayerTapped();
    }


    private void PlayerTapped()
    {
        if (Input.anyKeyDown)
        {
            // time that the player thinks is the beat
            playerBeat = conductor.GetTime();

            // time that the game thinks is the beat (use previous beat to see if player hits too early for some reason?)
            songBeat = conductor.currentBeatTime;

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
