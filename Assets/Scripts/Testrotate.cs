using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Testrotate : MonoBehaviour
{
    public GameObject go;

    public GameObject F;
    public GameObject R;
    public GameObject B;
    public GameObject L;

    private GameObject target;
    Vector3 Lvect = new Vector3(0, 90, 0);
    Vector3 Rvect = new Vector3(0, -90, 0);
    Vector3 Tvect = new Vector3(0, 180, 0);
    private Quaternion rot;
    float Left = 90.0f;
    float Right = -90.0f;

    public float rotatespeed = 5.0f;
    void Start()
    {
        target = F;
    }

    // Update is called once per frame
    void Update()
    {
        transform.LookAt(target.transform.position * Time.deltaTime);
        Debug.Log(target);
        if (Input.GetKeyUp(KeyCode.A))
        {

            Rotation(Lvect, Left);
            

        }
        if (Input.GetKeyUp(KeyCode.D))
        {

            Rotation(Rvect, Right);
            

        }
    }

    public void Rotation(Vector3 vect, float f)
    {
        
        if (go.transform.rotation.y % 360 == 0 )
        {
            if(f == 90)
            {
                //newRotation = Quaternion.LookRotation(Vector3.right);
                target = L;
            }
            else
            {
                //newRotation = Quaternion.LookRotation(Vector3.left);
                target = R;
            }
           
        }
        else if(go.transform.rotation.y % 360 == 90)
        {
            if (f == 90)
            {
                //newRotation = Quaternion.LookRotation(Vector3.forward);
                target = B;
            }
            else
            {
                //newRotation = Quaternion.LookRotation(Vector3.back);
                target = F;
            }
        }
        else if (go.transform.rotation.y % 360 == 180)
        {
            if (f == 90)
            {
                //newRotation = Quaternion.LookRotation(Vector3.left);
                target = R;
            }
            else
            {
                //newRotation = Quaternion.LookRotation(Vector3.right);
                target = L;
            }
        }
        else
        {
            if (f == 90)
            {
                //newRotation = Quaternion.LookRotation(Vector3.forward);
                target = F;
            }
            else
            {
                //newRotation = Quaternion.LookRotation(Vector3.back);
                target = B;
            }
        } 

    }


    IEnumerator Rotate(Vector3 vect, float number)
    {
        Quaternion newRotation;
        newRotation = Quaternion.identity;
        if (go.transform.rotation.y % 360 == 0)
        {
            if (number == 90)
            {
                //newRotation = Quaternion.LookRotation(Vector3.right * 90);
            }
            else
            {
                newRotation = Quaternion.LookRotation(Vector3.left *90);
            }

        }
        else if (go.transform.rotation.y % 360 == 90)
        {
            if (number == 90)
            {
                newRotation = Quaternion.LookRotation(Vector3.back * 90);
            }
            else
            {
                newRotation = Quaternion.LookRotation(Vector3.forward * 90);
            }
        }
        else if (go.transform.rotation.y % 360 == 180)
        {
            if (number == 90)
            {
                newRotation = Quaternion.LookRotation(Vector3.left * 90);
            }
            else
            {
                newRotation = Quaternion.LookRotation(Vector3.right * 90);
            }
        }
        else
        {
            if (number == 90)
            {
                newRotation = Quaternion.LookRotation(Vector3.forward * 90);
            }
            else
            {
                newRotation = Quaternion.LookRotation(Vector3.back * 90);
            }
        }

        go.transform.rotation *= newRotation;
        Debug.Log(newRotation);
        for (float f = 1000f; f >= -0.05f; f -= 0.05f)
        {

            go.transform.rotation = Quaternion.Slerp(go.transform.rotation, newRotation, rotatespeed * Time.deltaTime);
            yield return new WaitForSeconds(0.0005f);
        }
     
    }

}
