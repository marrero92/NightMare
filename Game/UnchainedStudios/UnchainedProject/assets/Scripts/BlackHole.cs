using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class BlackHole : MonoBehaviour {

    private CharacterMovement playerComplete;
    private bool isCompleted;

	// Use this for initialization
	void Start () {
        playerComplete = FindObjectOfType<CharacterMovement>();
	}
	
	// Update is called once per frame
	void Update () {
        isCompleted = playerComplete.isCompleted;
	}

    void OnTriggerEnter2D(Collider2D coll)
    {
        if (coll.tag == "Win")
        {
            isCompleted = true;
            Debug.Log("Next Level!");
            StartCoroutine(NextLevel());


        }

    }
    IEnumerator NextLevel()
    {
        //next anim here
        //rb.isKinematic = true;
        //bodyColl.enabled = false;

        yield return new WaitForSeconds(3f);

        SceneManager.LoadScene(0);
    }



}
