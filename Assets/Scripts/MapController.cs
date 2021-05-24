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
    public Transform Tg;
    private Quaternion rot;
    private Quaternion test;
    private Quaternion test2;
    Vector3 Lvect = new Vector3(0, 90, 0);
    Vector3 Rvect = new Vector3(0, -90, 0);
    Vector3 Tvect = new Vector3(0, 0, 0);
    float angle =0.0f;
    float Total;
    float Left = 90.0f;
    float Right = -90.0f;

    float sum=180;
    void Start()
    {
        //test = Quaternion.identity;
        Tg = target1.transform;
    }

    // Update is called once per frame
    void Update()
    {
        /*if((sum%360)/90 == 0)
        {
            go.transform.LookAt(target1.transform);
        }
        else if ((sum % 360) / 90 == 1)
        {
            go.transform.LookAt(target2.transform);
        }
        else if ((sum % 360) / 90 == 2)
        {
            go.transform.LookAt(target3.transform);
        }
        else if ((sum % 360) / 90 == 3)
        {
            go.transform.LookAt(target4.transform);
        }*/
        
        if (Input.GetKeyUp(KeyCode.A))
        {
            //sum += 90;
            
            Rotation(Lvect, 90.0f);
            //Look(Left);
            
        }
        if (Input.GetKeyUp(KeyCode.D))
        {
            //sum -= 90;
           
            //Look(Right);
            Rotation(Rvect, -90.0f);

        }
    }

    public void Look(float number)
    {
        float number2;
        if ((Total%360) / 90 == 0)
        {
            //360,0도
            number2 = 0;
            StartCoroutine(Lookat(target3,number2));
        }
        else if ((Total % 360) / 90 == 1)
        {
            //90도
            number2 = 90;
            StartCoroutine(Lookat(target4, number2));
        }
        else if ((Total % 360) % 90 == 2)
        {
            //180도
            number2 = 180;
            StartCoroutine(Lookat(target1, number2));
        }
        else if ((Total % 360) % 90 == 3)
        {
            //270도
            number2 = 270;
            StartCoroutine(Lookat(target2, number2));
        }
        
    }

    private IEnumerator Lookat(GameObject target, float number)
    {

        /*test2 = Quaternion.identity;
        target.transform.eulerAngles = new Vector3(0, number, 0);
        for (float f = 100f; f >= -0.05f; f -= 0.05f)
        {
            go.transform.rotation = Quaternion.Slerp(go.transform.rotation, target.transform.rotation*//*rot*//*, 5 * Time.deltaTime);
            yield return new WaitForSeconds(0.05f);
        }*/
        yield return new WaitForSeconds(0.05f);
    }
    public void Rotation( Vector3 vect, float f)
    {
        StartCoroutine(Rotate(vect, f));
        
    }

    IEnumerator Rotate(Vector3 vect, float number)
    {
        rot = Quaternion.identity;
        Tvect = Tvect+vect;
        Debug.Log(Tvect);
        rot.eulerAngles = Tvect;
        go.transform.rotation *= rot;
            
        //test.eulerAngles += new Vector3(0.0f, number, 0.0f);
        //go.transform.rotation *= test;

        Debug.Log(test.eulerAngles);
        for (float f = 100f; f >= -0.05f; f -= 0.05f)
        {
            go.transform.rotation = Quaternion.Slerp(go.transform.rotation, rot, 5 * Time.deltaTime);
            yield return new WaitForSeconds(0.005f);
        }
        
    }

}
