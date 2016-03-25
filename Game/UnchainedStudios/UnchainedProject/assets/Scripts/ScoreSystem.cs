using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class ScoreSystem : MonoBehaviour {

    private Text theText;
    public CharacterMovement character;

    // Use this for initialization
    void Start () {

        
        theText = GetComponent<Text>();

    }
	
	// Update is called once per frame
	void Update () {
	
        if(character.isCaptured == true)
        {
            theText.text = "You Have Been Captured";
        }
        if (character.isCompleted == true)
        {
            theText.text = "Next Level! Woot!";
        }
    }
}
