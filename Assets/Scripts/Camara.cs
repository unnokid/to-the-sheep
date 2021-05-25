using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Camara : MonoBehaviour
{
    public GameObject sheep;        // 따라다닐 타겟 오브젝트의 Transform

    void Start()
    {
        
    }

    void Update()
    {
        Vector3 targetVect = new Vector3(sheep.transform.position.x, sheep.transform.position.y+ 3.0f, transform.position.z);
        transform.position = Vector3.Lerp(this.transform.position, targetVect, 1.0f);

        //tr.LookAt(target);
    }
}
