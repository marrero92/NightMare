using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class Batteries : MonoBehaviour {

    public CharacterMovement character;

    public int startingBatteries;
    private int batteryCounter;

    private Text theText;

    // Use this for initialization
    void Start()
    {
        theText = GetComponent<Text>();

    }

    // Update is called once per frame
    void Update()
    {

        startingBatteries = character.battery;
        Debug.Log("I have batteries: " + startingBatteries);

        batteryCounter = startingBatteries;
        theText.text = "x " + batteryCounter;
    }

    public void TakeLife()
    {
        batteryCounter--;

    }
}
