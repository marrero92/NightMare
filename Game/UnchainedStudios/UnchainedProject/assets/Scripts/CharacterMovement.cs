using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class CharacterMovement : MonoBehaviour
{

    public float speed = 20f;
    public Rigidbody2D rb;
    public bool isFacingRight = true;
    public GameObject playerObject;
    public int battery = 1;
    public GameObject flashLight;
    private Animator anim;
    private Collider2D bodyColl;
    public int lives = 2;
    public float velX;
    public bool isFlashing = false;

    public bool isCaptured = false;
    public bool isCompleted= false;
    public bool onLadder;

    public float climbSpeed;
    private float climbVel;
    private float gravityStore;

    public Vector3 targetPos;

    public GameObject ankor;
    public bool canGrapple;


    // Use this for initialization
    void Start()
    {
        anim = GetComponent<Animator>();
        rb = GetComponent<Rigidbody2D>();
        bodyColl = GetComponent<Collider2D>();

        gravityStore = rb.gravityScale;

    }

  
    void Update()
    {

        //for escaping purposes
        if (Input.GetKey("escape")) { 
            Application.Quit();

         }

        //Movement
        if (Input.GetAxisRaw("Horizontal") == 1 && isFlashing == false)
        {

            velX = speed;

            rb.velocity = new Vector2(velX, rb.velocity.y);
            gameObject.transform.localScale = new Vector2(-1, transform.localScale.y);
            anim.SetInteger("AnimState", 1);

            isFacingRight = true;
            //Debug.Log("Is facing right.");


        }
        else if (Input.GetAxisRaw("Horizontal") == -1 && isFlashing == false)
        {
            velX = speed;

            rb.velocity = new Vector2(-velX, rb.velocity.y);
            gameObject.transform.localScale = new Vector2(1, transform.localScale.y);
            anim.SetInteger("AnimState", 1);

            isFacingRight = false;

           // Debug.Log("Is facing left.");
        }
        else
        {
            rb.velocity = new Vector2(0, rb.velocity.y);
            if (isFlashing == false)
            {
                anim.SetInteger("AnimState", 0);
            }
            
        }

        //Battery Attack in
        if (Input.GetKeyDown(KeyCode.E) && battery > 0)
        {
            isFlashing = true;
            anim.SetInteger("AnimState", 2);
            flashLight.SetActive(true);
            

            StartCoroutine(FlashLightTimer());

        }
        //Battery Attack in out
        if (Input.GetKeyUp(KeyCode.E) && battery > 0)
        {
            isFlashing = false;
            flashLight.SetActive(false);
            anim.SetInteger("AnimState", 0);
            

            battery--;
        }

        // On ladder
        if (onLadder)
        {
            rb.gravityScale = 0f;
            bodyColl.enabled = false;
            climbVel = climbSpeed * Input.GetAxisRaw("Vertical");

            rb.velocity = new Vector2(rb.velocity.x, climbVel);
            

        }
        if (onLadder)
        {
            bodyColl.enabled = true;
            rb.gravityScale = gravityStore;
            
        }

        

    }

    void OnCollisionEnter2D(Collision2D coll)
        {

        if (coll.gameObject.tag == "Enemy")
        {

            if (lives > 0)
                StartCoroutine(waitlives());

            if (lives == 0)
            {
                isCaptured = true;

                Debug.Log("You have been captured");
                StartCoroutine(Captured());
            }

        }
        if (coll.gameObject.tag == "DeathFloddor")
        {

                Debug.Log("Have fallen");
                Destroy(gameObject);
                SceneManager.LoadScene(0);

        }
         
    }

    IEnumerator FlashLightTimer()
    {
        yield return new WaitForSeconds(3f);
        flashLight.SetActive(false);

    }

    IEnumerator Captured()
    {
        //death anim here
        //rb.isKinematic = true;
        //bodyColl.enabled = false;
        
        yield return new WaitForSeconds(2f);
        
        SceneManager.LoadScene(0);
    }
   

    IEnumerator waitlives()
    {
        lives--;
        yield return new WaitForSeconds(2f);
        
    }

    void OnTriggerEnter2D(Collider2D other)
    {

        if (other.tag == "Ledge")
            {
            canGrapple = true;
            targetPos = new Vector3(other.transform.position.x, other.transform.position.y, 0);
                ankor = other.gameObject;
                Debug.Log("TouchingRight");
            }
        if (other.tag == "Battery")
        {
            Debug.Log("+1 Battery!");
            battery++;
            Destroy(other.gameObject);

        }


    }
    void OnTriggerExit2D(Collider2D other)
    {

        if (other.tag == "Ledge")
        {
            canGrapple = false;
        }

    }
}
