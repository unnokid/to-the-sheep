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

    
    private Quaternion rot;
    //private Quaternion test;
    Vector3 Lvect = new Vector3(0, 90, 0);
    Vector3 Rvect = new Vector3(0, -90, 0);
    Vector3 Tvect = new Vector3(0, 0, 0);
    float Total;
    float Left = 90.0f;
    float Right = -90.0f;
    float length;
    
    void Start()
    {
        //test = Quaternion.identity;
        
    }

    // Update is called once per frame
    void Update()
    {
        
        if (Input.GetKeyUp(KeyCode.A))
        {
            
            Rotation(Lvect, 90.0f);
            Move();

        }
        if (Input.GetKeyUp(KeyCode.D))
        {

            Rotation(Rvect, -90.0f);
            Move();

        }
    }

    public void Move()
    {
        //��� ���� ĳ���� �̵�  x�� ������
        line.transform.position = new Vector3(0, sheep.transform.position.y,sheep.transform.position.z);
        length = Vector3.Distance(sheep.transform.position,line.transform.position);
        
        if (sheep.transform.position.x > 0.0f)
        {
            Vector3 targetVect = new Vector3(-length,line.transform.position.y,line.transform.position.z );
            sheep.transform.position = Vector3.Lerp(sheep.transform.position, targetVect, 1.0f);
        }
        else
        {
            Vector3 targetVect = new Vector3(length, line.transform.position.y, line.transform.position.z);
            sheep.transform.position = Vector3.Lerp(sheep.transform.position, targetVect, 1.0f);
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
        //Debug.Log(Tvect);
        rot.eulerAngles = Tvect;
        go.transform.rotation *= rot;
            
        //test.eulerAngles += new Vector3(0.0f, number, 0.0f);
        //go.transform.rotation *= test;
        //Debug.Log(test.eulerAngles);
        for (float f = 100f; f >= -0.05f; f -= 0.05f)
        {
            go.transform.rotation = Quaternion.Slerp(go.transform.rotation, rot, 5 * Time.deltaTime);
            yield return new WaitForSeconds(0.005f);
        }
        
    }

}
