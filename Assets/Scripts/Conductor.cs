using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Conductor : MonoBehaviour
{
    private GameManager gameManager;

    //The number of seconds for each song beat
    public float secPerBeat;

    //Current song position, in seconds
    public float songPosition;

    //Current song position, in beats
    public float songPositionInBeats;

    //How many seconds have passed since the song started
    public float dspSongTime;

    public float lastBeatTime;

    public float currentBeatTime;

    public int songPositionInBeatsOld;
    void Start()
    {
        gameManager = FindObjectOfType<GameManager>();

        //Calculate the number of seconds in each beat
        secPerBeat = 60f / gameManager.levelMusic.BPM;

        //Record the time when the music starts
        dspSongTime = GetTime();

        //Start the music
        gameManager.musicSource.Play();
    }

    void Update()
    {
        songPositionInBeatsOld = (int)songPositionInBeats;

        //determine how many seconds since the song started
        songPosition = (GetTime() - dspSongTime - gameManager.levelMusic.firstBeatOffset);

        //determine how many beats since the song started
        songPositionInBeats = songPosition / secPerBeat;

        //beat incremented by one
        if ((int)songPositionInBeats - songPositionInBeatsOld >= 1)
        {
            // store last beat time
            lastBeatTime = currentBeatTime;
            // get time for new beat
            currentBeatTime = GetTime();

            songPositionInBeatsOld = (int)songPositionInBeats;

            // fire BeatHappened event
            gameManager.events.BeatHappened();
        }

    }

    public float GetTime()
    {
        return (float)AudioSettings.dspTime;
    }


    public void Pause()
    {
        AudioListener.pause = true;
    }

    public void Continue()
    {
        AudioListener.pause = false;
    }
}
