using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerScript : MonoBehaviour
{
    GameManager gameManager;
    private void start()
    {
        gameManager.playerRef = this.gameObject;
    }
}
