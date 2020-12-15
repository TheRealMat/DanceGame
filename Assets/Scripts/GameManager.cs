using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public AudioSource musicSource;
    public GameEvents events;
    public Conductor conductor;
    public Settings settings;
    private bool paused = false;
    public GameObject playerRef;
    public bool playerMoved;

    // this needs to be exactly the same as the build order. hmm
    public Level[] levels = new Level[] { };
    public int currentScene = 0;

    public List<EnemyScript> gameEntities = new List<EnemyScript>();


    // should be relative to BPM somehow. i could maybe take the bpm from the song and then calculate like 5 bpm in either direction from player offset
    private float marginOfError = 0.1f;

    // there's some copypasta here from the offset counter, oh well!
    // does this really belong in the gamemanager?
    public void HandleTurn(int x, int y)
    {
        float currentTime = conductor.songPosition;
        float lastBeat = conductor.currentBeatTime;
        float nextBeat = conductor.nextBeatTime;
        float closestBeat;
        // which beat is closer
        if ((currentTime - lastBeat) < (Mathf.Abs((currentTime - nextBeat)))){
            closestBeat = lastBeat;
        }
        else{
            closestBeat = nextBeat;
        }

        // the difference between when the player pressed and when they're supposed to
        // is this even right? i'm bad at numbers
        float beatDifference = Mathf.Abs(currentTime - closestBeat + settings.playerOffset);

        // is the input within accepted timeframe?
        // is this right???
        Debug.Log(beatDifference);
        if (beatDifference < marginOfError)
        {
            Debug.Log("success!");
        }
        else
        {
            Debug.Log("fail!");
        }
        playerMoved = true;
    }



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
        // load level as an event?
        currentScene += 1;
        SceneManager.LoadScene(currentScene);
        conductor.PlaySong(levels[currentScene].levelMusic);
    }


    void Awake()
    {
        GameManager[] objs = GameObject.FindObjectsOfType<GameManager>();

        if (objs.Length > 1)
        {
            Destroy(this.gameObject);
        }

        DontDestroyOnLoad(this.gameObject);
        events.onPlayerMove += HandleTurn;

    }
}
