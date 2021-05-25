using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cshPlayerController : MonoBehaviour
{
    private Animator sheep_animator;
    // public GameObject Map;
    Rigidbody rigid;
    public float jumppower;
    private bool isjump = false;
    private bool dead = false;
    private RaycastHit hit1;
    private RaycastHit hit2;
    // Start is called before the first frame update
    private void Awake()
    {
        rigid = GetComponent<Rigidbody>();
        sheep_animator = GetComponent<Animator>();


    }
    // Update is called once per frame
    void Update()
    {

        if (Input.GetKey(KeyCode.LeftArrow))
        {
            transform.rotation = Quaternion.Euler(0.0f, 90.0f, 0.0f);
            this.transform.Translate(0.0f, 0.0f, 0.03f);
            sheep_animator.SetBool("walk", true);
        }
        else if (Input.GetKey(KeyCode.RightArrow))
        {
            transform.rotation = Quaternion.Euler(0.0f, -90.0f, 0.0f);
            this.transform.Translate(0.0f, 0.0f, 0.03f);         
            sheep_animator.SetBool("walk", true);
        }
        else
        {
            sheep_animator.SetBool("walk", false);
        }


        if (Input.GetKeyDown(KeyCode.Space) && !isjump /*!sheep_animator.GetBool("jump")*/)
        {
            rigid.AddForce(Vector3.up * jumppower,ForceMode.Impulse);
            isjump = true;
          
        }

    }

   /* private void FixedUpdate()
    {
        Vector3 uppoint = new Vector3(transform.position.x, transform.position.y + 2.0f, transform.position.z);
        //Debug.DrawRay(rigid.position, Vector3.down* 1.0f, new Color(0, 1, 0));
        Debug.DrawRay(uppoint, Vector3.up *1.0f, new Color(1, 0 , 0));

        //RaycastHit2D rayHitup = Physics2D.Raycast(rigid.position, Vector3.up, 1.8f);
        //RaycastHit2D rayHitdown = Physics2D.Raycast(rigid.position, Vector3.down, 0.3f);
        RaycastHit2D rayHitdown = Physics2D.Raycast(rigid.position, Vector3.down, 1.0f);
        if (Physics.Raycast(transform.position, -transform.up, out hit1,0.01f))
        {
           
            if(rayHitdown.distance < 0.05f)
            {
                sheep_animator.SetBool("jump", false);
            }
        }
    }*/

    private void OnCollisionEnter(Collision collision)
    {
        //collision
        
        //Debug.Log("콜리션 들어감");
        if(collision.gameObject.tag == "Map" && (transform.position.y >collision.gameObject.transform.position.y ))
        {
            //Debug.Log("아래로 충돌");
            isjump = false;
        }
    }


    public bool isdead()
    { 
        return dead;
    }

    public void setdead(bool d)
    {
        dead = d;
    }
}
