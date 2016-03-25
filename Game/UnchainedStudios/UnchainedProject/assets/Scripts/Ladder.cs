using UnityEngine;
using System.Collections;

public class Ladder : MonoBehaviour {

    public CharacterMovement player;

	// Use this for initialization
	void Start () {
        player = FindObjectOfType<CharacterMovement>();
    }
	
	// Update is called once per frame
	void Update () {
	
	}

    void OnTriggerEnter2D(Collider2D other)
    {
        if(other.tag == "Player")
        {
            player.onLadder = true;
        }
        Debug.Log("onLadder");
    }
    void OnTriggerExit2D(Collider2D other)
    {
        if(other.tag == "Player")
        {
            player.onLadder = false;
        }
        Debug.Log("offLadder");
    }
}
