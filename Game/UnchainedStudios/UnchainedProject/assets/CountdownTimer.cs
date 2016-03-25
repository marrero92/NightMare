using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class CountdownTimer : MonoBehaviour {
	
	private Text theText;
	float timeRemaining = 100;

	void Start(){
		theText = GetComponent<Text> ();

	}
	void Update () {
		timeRemaining -= Time.deltaTime;
	
		if(timeRemaining > 0){
			theText.text = "" + (int)timeRemaining;
		}
		else{
			theText.text = "Time's Up";
            SceneManager.LoadScene(0);
        }
	}
}