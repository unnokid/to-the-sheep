using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameFinish : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "Player")
        {
            Debug.Log("∞‘¿”≥°");
            GameObject.Find("GameManager").GetComponent<UITimer>().Timeup();
            
        }
    }
   
}
