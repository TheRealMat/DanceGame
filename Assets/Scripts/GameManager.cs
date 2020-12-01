using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public LevelMusic levelMusic;
    public AudioSource musicSource;
    public GameEvents events;
    public Conductor conductor;
    private bool paused = false;


    // should be relative to BPM somehow. i could maybe take the bpm from the song and then calculate like 5 bpm in either direction from player offset
    private float marginOfError;

    public void Pause()
    {
        if (paused == false)
        {
            paused = true;
            conductor.Pause();
        }
        else
        {
            paused = false;
            conductor.Continue();
        }
        
    }
}
