using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Conductor : MonoBehaviour
{
    public LevelMusic levelMusic;
    public AudioSource musicSource;
    private GameEvents events;

    //The number of seconds for each song beat
    public float secPerBeat;

    //Current song position, in seconds
    public float songPosition;

    //Current song position, in beats
    public float songPositionInBeats;

    //How many seconds have passed since the song started
    public float dspSongTime;

    public int songPositionInBeatsOld;
    void Start()
    {
        events = GameObject.FindObjectOfType<GameEvents>();

        //Calculate the number of seconds in each beat
        secPerBeat = 60f / levelMusic.BPM;

        //Record the time when the music starts
        dspSongTime = (float)AudioSettings.dspTime;

        //Start the music
        musicSource.Play();
    }

    void Update()
    {
        songPositionInBeatsOld = (int)songPositionInBeats;

        //determine how many seconds since the song started
        songPosition = (float)(AudioSettings.dspTime - dspSongTime - levelMusic.firstBeatOffset);

        //determine how many beats since the song started
        songPositionInBeats = songPosition / secPerBeat;

        if ((int)songPositionInBeats - songPositionInBeatsOld >= 1)
        {
            songPositionInBeatsOld = (int)songPositionInBeats;

            events.BeatHappened();
        }

    }
}
