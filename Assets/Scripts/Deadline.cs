using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Deadline : MonoBehaviour
{
    public GameObject CheckPoint;
    public GameObject map;
    public GameObject sheep;


    void OnTriggerEnter(Collider col)
    {
        if (col.gameObject.tag == "Player")
        {
            GameObject.Find("sheep").GetComponent<cshPlayerController>().setdead(true);
            map.transform.localEulerAngles = new Vector3(0.0f, 180.0f, 0.0f);
            col.gameObject.transform.position = CheckPoint.transform.position;
        }
    }

    public void ResetMap()
    {
        GameObject.Find("sheep").GetComponent<cshPlayerController>().setdead(true);
        map.transform.localEulerAngles = new Vector3(0.0f, 180.0f, 0.0f);
        sheep.transform.position = CheckPoint.transform.position;
    }
}
