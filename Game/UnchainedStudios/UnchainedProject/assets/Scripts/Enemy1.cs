using UnityEngine;
using System.Collections;

public class Enemy1 : MonoBehaviour
{

    public Transform[] patrolpoints;
    int currentPoint = 0;
    public float speed = 0.005f;
    public float timeStill = 1f;
    public bool stunned = false;
    Collider2D coll;
    private Rigidbody2D rb;
    private Animator anim;


    // Use this for initialization
    void Start()
    {
        coll = GetComponent<Collider2D>();
        StartCoroutine ("Patrol");
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();

    }

    // Update is called once per frame
    void Update()
    {
        if (stunned == false)
        {
            anim.SetInteger("AnimState", 0);
            if (currentPoint < patrolpoints.Length)
                StartCoroutine("Patrol");
            else
                currentPoint = 0;
        }
        else if(stunned == true)
        {
            anim.SetInteger("AnimState", 1);
            StartCoroutine("Count");
        }
    }

    IEnumerator Patrol()
    {
        
            if(transform.position.x == patrolpoints[currentPoint].position.x)
            {
                currentPoint++;
                yield return new WaitForSeconds(timeStill);

            }
            if (currentPoint >= patrolpoints.Length)
            {
                currentPoint = 0;

            }
           

          if (stunned == false)
                 transform.position = Vector2.MoveTowards(transform.position, new Vector2(patrolpoints[currentPoint].position.x, transform.position.y), speed);
              

            if (transform.position.x > patrolpoints[currentPoint].position.x)
            {
                transform.localScale = new Vector3(-1, 1, 1);
            }
            else if (transform.position.x < patrolpoints[currentPoint].position.x)
                transform.localScale = Vector3.one;

            yield return null;
       
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "FlashLight")
        {
            stunned = true;
            rb.isKinematic = true;
            coll.enabled = false;
            
            
        }
    }
    IEnumerator Count()
    {
        yield return new WaitForSeconds(5f);
        stunned = false;
        rb.isKinematic = false;
        coll.enabled = true;
    }
}
