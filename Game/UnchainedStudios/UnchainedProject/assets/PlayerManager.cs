using UnityEngine;
using System.Collections;

public enum PlayerState
{
    blanketTrow = 1,
    flashlight = 2,
    stair = 3

}
public class PlayerManager : MonoBehaviour {

    public PlayerState playerState = PlayerState.flashlight;
    public bool changePlayer = false;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {

        if (changePlayer == true)
        {
            SetPlayerState();
        }

    }

    public void SetPlayerState()
    {
        switch (playerState)
        {
            case PlayerState.blanketTrow:
                Debug.Log("I am Trowing");
                break;
            case PlayerState.flashlight:
                Debug.Log("I am using flashlight");
                break;
            case PlayerState.stair:
                Debug.Log("I am going up stairs");

                break;

        }
    }
}
