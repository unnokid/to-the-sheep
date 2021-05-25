using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollisionCheck : MonoBehaviour
{

    private void OnCollisionEnter(Collision collision)
    {
        //collision
        if(collision.gameObject.tag.Equals("sheep"))
        {
            GameObject sheep = collision.gameObject;

        }
    }
}
