using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MapController : MonoBehaviour
{
    public GameObject go;
    public GameObject target1;
    public GameObject target2;
    public GameObject target3;
    public GameObject target4;

    public GameObject line;
    public GameObject sheep;
    public Rigidbody rigid;

    private Quaternion rot;
    //private Quaternion test;
    Vector3 Lvect = new Vector3(0, 90, 0);
    Vector3 Rvect = new Vector3(0, -90, 0);
    Vector3 Tvect = new Vector3(0, 180, 0);
    float Left = 90.0f;
    float Right = -90.0f;
    float length;
    
    void Start()
    {
        //test = Quaternion.identity;
        rigid = sheep.GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        
        if (Input.GetKeyUp(KeyCode.A))
        {
           
            Rotation(Lvect, Left);
            Move();

        }
        if (Input.GetKeyUp(KeyCode.D))
        {
           
            Rotation(Rvect, Right);
            Move();

        }
    }

    public void Move()
    {
        //가운데 기준 캐릭터 이동  x만 움직임
        line.transform.position = new Vector3(0, sheep.transform.position.y,sheep.transform.position.z);
        if (sheep.transform.position.x > 0.0f)
        {
            
            if (sheep.transform.position.x > 9.0f || sheep.transform.position.x < -9.0f)
            {
                //Debug.Log("거리 조절");
                length = 8.0f;
                Vector3 targetVect = new Vector3(-length, line.transform.position.y, line.transform.position.z);
                sheep.transform.position = Vector3.Lerp(sheep.transform.position, targetVect, 1.0f);
            }
            else
            {
                //Debug.Log("어디여1");
                length = Vector3.Distance(sheep.transform.position, line.transform.position);
                Vector3 targetVect = new Vector3(-length, line.transform.position.y, line.transform.position.z);
                sheep.transform.position = Vector3.Lerp(sheep.transform.position, targetVect, 1.0f);
            }
            
        }
        else
        {
            if (sheep.transform.position.x > 9.0f || sheep.transform.position.x < -9.0f)
            {
                //Debug.Log("거리 조절");
                length = 8.0f;
                Vector3 targetVect = new Vector3(length, line.transform.position.y, line.transform.position.z);
                sheep.transform.position = Vector3.Lerp(sheep.transform.position, targetVect, 1.0f);
            }
            else
            {
                //Debug.Log("어디여2");
                length = Vector3.Distance(sheep.transform.position, line.transform.position);
                Vector3 targetVect = new Vector3(length, line.transform.position.y, line.transform.position.z);
                sheep.transform.position = Vector3.Lerp(sheep.transform.position, targetVect, 1.0f);
            }
        }
    }

    public void Rotation( Vector3 vect, float f)
    {
        StartCoroutine(Rotate(vect, f));
        
    }

    IEnumerator Rotate(Vector3 vect, float number)
    {
        rot = Quaternion.identity;
        Tvect = Tvect+vect;
        if(Tvect.y >180.0f)
        {
            Tvect.y -= 360.0f;
        }
        else if(Tvect.y <- 180.0f)
        {
            Tvect.y += 360.0f;
        }
        Debug.Log(Tvect);
        rot.eulerAngles = Tvect;
        Debug.Log(rot + "rot");
        Debug.Log(rot.eulerAngles + "rot.eulerAngles");
        go.transform.rotation *= rot;
        Debug.Log(go.transform.rotation + "go.transform.rotation");


        rigid.useGravity = false;
        Invoke("useGravity", 0.3f);
        for (float f = 100f; f >= -0.05f; f -= 0.05f)
        {
            if(GameObject.Find("sheep").GetComponent<cshPlayerController>().isdead())
            {
                break;
            }
            go.transform.rotation = Quaternion.Slerp(go.transform.rotation, rot, 5 * Time.deltaTime);
            yield return new WaitForSeconds(0.0005f);
        }

        GameObject.Find("sheep").GetComponent<cshPlayerController>().setdead(false);
    }

    public void useGravity()
    {
        rigid.useGravity = true;
    }

  
}
