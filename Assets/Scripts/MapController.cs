using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MapController : MonoBehaviour
{
    public GameObject go;
    public GameObject line;
    public GameObject sheep;
    public Rigidbody rigid;
    public GameObject target;

    float Left = 90.0f;
    float Right = -90.0f;
    float length;
    float total = 180.0f;
    public float rotatespeed = 1.0f;
    void Start()
    {
        rigid = sheep.GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        go.transform.rotation = Quaternion.Lerp(go.transform.rotation, target.transform.rotation, Time.deltaTime * rotatespeed);
        if (Input.GetKeyUp(KeyCode.A))
        {
            total += Left;
            target.transform.rotation = Quaternion.Euler(0, total, 0);
            Move();

        }
        if (Input.GetKeyUp(KeyCode.D))
        {
            total += Right;
            target.transform.rotation = Quaternion.Euler(0, total, 0);
            Move();

        }
        if(Input.GetKeyUp(KeyCode.R))
        {
            GameObject.Find("Deadline").GetComponent<Deadline>().ResetMap();
            GameObject.Find("GameManager").GetComponent<UITimer>().Reset_Timer();
        }
    }

    public void Move()
    {
        //가운데 기준 캐릭터 이동  x만 움직임
        rigid.useGravity = false;
        line.transform.position = new Vector3(0, sheep.transform.position.y,sheep.transform.position.z);
        if (sheep.transform.position.x > 0.0f)
        {
            
            if (sheep.transform.position.x > 9.0f || sheep.transform.position.x < -9.0f)
            {
              
                length = 8.0f;
                Vector3 targetVect = new Vector3(-length, line.transform.position.y, line.transform.position.z);
                sheep.transform.position = Vector3.Lerp(sheep.transform.position, targetVect, 1.0f);
            }
            else
            {
               
                length = Vector3.Distance(sheep.transform.position, line.transform.position);
                Vector3 targetVect = new Vector3(-length, line.transform.position.y, line.transform.position.z);
                sheep.transform.position = Vector3.Lerp(sheep.transform.position, targetVect, 1.0f);
            }
            
        }
        else
        {
            if (sheep.transform.position.x > 9.0f || sheep.transform.position.x < -9.0f)
            {
              
                length = 8.0f;
                Vector3 targetVect = new Vector3(length, line.transform.position.y, line.transform.position.z);
                sheep.transform.position = Vector3.Lerp(sheep.transform.position, targetVect, 1.0f);
            }
            else
            {
              
                length = Vector3.Distance(sheep.transform.position, line.transform.position);
                Vector3 targetVect = new Vector3(length, line.transform.position.y, line.transform.position.z);
                sheep.transform.position = Vector3.Lerp(sheep.transform.position, targetVect, 1.0f);
            }
        }
        Invoke("useGravity", 0.3f);
    }

    public void Restart()
    {
        total = 180.0f;
        target.transform.rotation = Quaternion.Euler(0, total, 0);
    }

    public void useGravity()
    {
        rigid.useGravity = true;
    }

  

}
