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
  
    float Left = 90.0f;
    float Right = -90.0f;
    float total = 0.0f;
    

    public float rotatespeed = 5.0f;
    void Start()
    {
        target = F;
    }

    // Update is called once per frame
    void Update()
    {
        go.transform.rotation = Quaternion.Lerp(go.transform.rotation, target.transform.rotation, Time.deltaTime * rotatespeed);
       // Debug.Log(target);
        if (Input.GetKeyUp(KeyCode.A))
        {
            total += Left;
            target.transform.rotation = Quaternion.Euler(0, total, 0); 
        }
        if (Input.GetKeyUp(KeyCode.D))
        {
            total += Right;
            target.transform.rotation = Quaternion.Euler(0, total, 0);
        }
    }

}
