using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public LevelMusic levelMusic;
    public AudioSource musicSource;
    public GameEvents events;
    public Conductor conductor;
    public Settings settings;
    private bool paused = false;

    string[] levels = new string[] { "MainMenu", "Level1" };
    int currentScene = 0;

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
    public void StartNextScene()
    {
        // !!! check if this gives build errors !!!
        SceneManager.LoadScene(levels[currentScene + 1]);
    }


    void Awake()
    {
        GameManager[] objs = GameObject.FindObjectsOfType<GameManager>();

        if (objs.Length > 1)
        {
            Destroy(this.gameObject);
        }

        DontDestroyOnLoad(this.gameObject);

    }
}
