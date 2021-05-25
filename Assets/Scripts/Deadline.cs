using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Deadline : MonoBehaviour
{
    public GameObject CheckPoint;
    public GameObject map;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnTriggerEnter(Collider col)
    {
        if (col.gameObject.tag == "Player")
        {
            GameObject.Find("sheep").GetComponent<cshPlayerController>().setdead(true);
            map.transform.localEulerAngles = new Vector3(0.0f, 180.0f, 0.0f);
            col.gameObject.transform.position = CheckPoint.transform.position;
        }
    }

   
}
