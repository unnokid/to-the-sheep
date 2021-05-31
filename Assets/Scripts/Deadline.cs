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

            GameObject.Find("GameManager").GetComponent<MapController>().Restart();
            col.gameObject.transform.position = CheckPoint.transform.position;
        }
    }

    public void ResetMap()
    {
        GameObject.Find("GameManager").GetComponent<MapController>().Restart();
        sheep.transform.position = CheckPoint.transform.position;
    }
}
