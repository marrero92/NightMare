using UnityEngine;
using System.Collections;

public class GrapplingHook : MonoBehaviour
{
    public LineRenderer line;
    DistanceJoint2D joint;
    Vector3 targetPos;
    RaycastHit2D hit;
    public float distance = 10f;
    public LayerMask mask;
    CharacterMovement player;

    public float step = .1f;
    // Use this for initialization

    void Start()
    {

        joint = GetComponent<DistanceJoint2D>();
        player = GetComponent<CharacterMovement>();
        joint.enabled = false;
        line.enabled = false;

    }

    // Update is called once per frame
    void Update()
    {
            if (joint.distance > 1f)
            {
                joint.distance -= step;
            }
            else
            {
                line.enabled = false;
                joint.enabled = false;

            }

            targetPos = player.targetPos;

            Debug.Log(targetPos);

        if (Input.GetKeyDown(KeyCode.Space) && player.canGrapple == true)
        {
            // targetPos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            //targetPos.z = 0;

            

             hit = Physics2D.Raycast(transform.position, targetPos-transform.position, distance, mask);

            

            if (player.ankor != null && player.ankor.GetComponent<Rigidbody2D>() != null) /*hit.collider != null && hit.collider.gameObject.GetComponent<Rigidbody2D>() != null)*/
            {
                
                joint.enabled = true;
                joint.connectedBody = player.ankor.GetComponent<Rigidbody2D>(); //hit.collider.gameObject.GetComponent<Rigidbody2D>();
                if (player.isFacingRight == true)
                {
                    joint.connectedAnchor = new Vector2(/*player.ankor.transform.position.x * 0, player.ankor.transform.position.y * 0*/ -8, -8);//hit.point - new Vector2(hit.collider.transform.position.x, hit.collider.transform.position.y);
                }
                else if (player.isFacingRight == false)
                {
                    joint.connectedAnchor = new Vector2(8, -8);
                }
                joint.distance = Vector2.Distance(transform.position, player.ankor.transform.position);

                line.enabled = true;
                line.SetPosition(0, transform.position);
                line.SetPosition(1, player.ankor.transform.position);

                

            }
        }

        if (Input.GetKey(KeyCode.Space))
        {
            line.SetPosition(0, transform.position);

        }

        if (Input.GetKeyUp(KeyCode.E)){
                joint.enabled = false;
                line.enabled = false;
               
        }
            
       }


     //   StartCoroutine(count());
    IEnumerator count()
    {
        yield return new WaitForSeconds(1.5f);
        
    }

   
}






