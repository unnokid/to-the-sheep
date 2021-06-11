using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Secretground : MonoBehaviour
{
    public float number;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (GameObject.Find("GameManager").GetComponent<MapController>().GetTotal() % 360 == number || GameObject.Find("GameManager").GetComponent<MapController>().GetTotal() % 360 == number-360)
        {
            gameObject.GetComponent<BoxCollider>().enabled =true;
        }
        else
        {
            gameObject.GetComponent<BoxCollider>().enabled = false;
        }
    }
}
