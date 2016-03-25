using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class LifeScript : MonoBehaviour {
    [SerializeField]
    public CharacterMovement character;
    
    public int startingLives;
	private int lifeCounter;

	private Text theText;

	// Use this for initialization
	void Start () {
		theText = GetComponent<Text> ();
        
	}

	// Update is called once per frame
	void Update () {

        startingLives = character.lives;
        Debug.Log("I have lives: " + startingLives);

        lifeCounter = startingLives;
		theText.text = "x " + lifeCounter;
	}

	public void TakeLife() {
		lifeCounter--;

}
}