using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MapController : MonoBehaviour
{
    public GameObject go;
    public GameObject line;
    public GameObject sheep;
    public Rigidbody rigid;
    public GameObject target;

    float Left = 90.0f;
    float Right = -90.0f;
    float length;
    float total = 180.0f;
    public float rotatespeed = 1.0f;

    private bool rightrotate=false;
    private bool leftrotate = false;
    void Start()
    {
        rigid = sheep.GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        Debug.Log(total +"total");
        go.transform.rotation = Quaternion.Lerp(go.transform.rotation, target.transform.rotation, Time.deltaTime * rotatespeed);
        
        if (Input.GetKeyDown(KeyCode.A) && go.transform.rotation == target.transform.rotation)
        {
            StopCoroutine("Moving");
            Invoke("useGravity", 0.1f);
            leftrotate = true;
            Move();
            total += Left;
            target.transform.rotation = Quaternion.Euler(0, total, 0);
            
            
}
        if (Input.GetKeyDown(KeyCode.D) && go.transform.rotation == target.transform.rotation)
        {
            StopCoroutine("Moving");
            Invoke("useGravity", 0.1f);
            rightrotate = true;
            Move();
            total += Right;
            target.transform.rotation = Quaternion.Euler(0, total, 0);
            
            
        }
        if(Input.GetKeyDown(KeyCode.R))
        {
            GameObject.Find("Deadline").GetComponent<Deadline>().ResetMap();
            GameObject.Find("GameManager").GetComponent<UITimer>().Reset_Timer();
        }
    }

    public void Move()
    {
        //가운데 기준 캐릭터 이동  x만 움직임
        rigid.useGravity = false;
        line.transform.position = new Vector3(0, sheep.transform.position.y,sheep.transform.position.z);
        length = 8.0f;
        if (sheep.transform.position.x > 0.0f)
        {
            Vector3 targetVect;
            if(rightrotate)//오른쪽회전했니?
            {
                targetVect = new Vector3(-length, line.transform.position.y, line.transform.position.z);
                rightrotate = false;
                //sheep.transform.position = Vector3.Lerp(sheep.transform.position, targetVect, 10.0f);
                StartCoroutine(Moving(targetVect));
            }
            else if (leftrotate)
            {
                targetVect = new Vector3(length, line.transform.position.y, line.transform.position.z);
                StartCoroutine(Moving(targetVect));
                //sheep.transform.position = Vector3.Lerp(sheep.transform.position, targetVect, 10.0f);
            }
        }
        else
        {
            Vector3 targetVect;
            if (rightrotate)//오른쪽회전했니?
            {
                targetVect = new Vector3(-length, line.transform.position.y, line.transform.position.z);
                rightrotate = false;
                StartCoroutine(Moving(targetVect));
                //sheep.transform.position = Vector3.Lerp(sheep.transform.position, targetVect, 10.0f);
            }
            else if (leftrotate)
            {
                targetVect = new Vector3(length, line.transform.position.y, line.transform.position.z);
                StartCoroutine(Moving(targetVect));
                //sheep.transform.position = Vector3.Lerp(sheep.transform.position, targetVect, 10.0f);
            }
        }
        Invoke("useGravity", 0.3f);
    }

    IEnumerator Moving(Vector3 targetVect)
    {
        
        while (Vector3.Distance(sheep.transform.position, targetVect) > 1.0f)
        {
            sheep.transform.position = Vector3.Lerp(sheep.transform.position, targetVect, 10.0f * Time.deltaTime);

            yield return null;

        }
        Invoke("useGravity", 0.3f);
    }
    public void Restart()
    {
        total = 180.0f;
        target.transform.rotation = Quaternion.Euler(0, total, 0);
    }

    public void useGravity()
    {
        rigid.useGravity = true;
    }

    public float GetTotal()
    {

        return total % 360;
    }
  

}
