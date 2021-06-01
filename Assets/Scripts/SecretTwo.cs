using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SecretTwo : MonoBehaviour
{
    public float number1;
    public float number2;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (GameObject.Find("GameManager").GetComponent<MapController>().GetTotal() == number1 || GameObject.Find("GameManager").GetComponent<MapController>().GetTotal() == -number1
            || GameObject.Find("GameManager").GetComponent<MapController>().GetTotal() == number2 || GameObject.Find("GameManager").GetComponent<MapController>().GetTotal() == -number2)
        {
            gameObject.GetComponent<BoxCollider>().enabled = true;
        }
        else
        {
            gameObject.GetComponent<BoxCollider>().enabled = false;
        }
    }
}
