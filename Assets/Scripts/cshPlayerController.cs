using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cshPlayerController : MonoBehaviour
{
    private Animator sheep_animator;
    // public GameObject Map;
    Rigidbody rigid;
    public float jumppower;


    // Start is called before the first frame update
    private void Awake()
    {
        rigid = GetComponent<Rigidbody>();
        sheep_animator = GetComponent<Animator>();


    }
    void Start()
    {
        
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


        if (Input.GetKeyDown(KeyCode.Space))
        {
            //sheep_animator.SetBool("jump", true);
            rigid.AddForce(Vector3.up * jumppower,ForceMode.Impulse);
        }
        
        
    }

 
}
