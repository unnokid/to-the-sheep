using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class UIController : MonoBehaviour
{
    public Transform name;
    public GameObject press;

    private bool isLoaded;
    private bool sceneChange;
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(MoveName(name));
        
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetMouseButtonDown(0) && isLoaded)
        {
            sceneChange = true;
            SceneManager.LoadScene("MainGame");
        }
    }

    IEnumerator MoveName(Transform rt)
    {
        var origin = rt.position.y;
        rt.position = new Vector3(rt.position.x, rt.position.y - 1.0f, rt.position.z);
        press.SetActive(false);
        
        while(rt.position.y < origin)
        {
            rt.Translate(0, 0.05f, 0);
            if(rt.position.y >= origin)
            {
                isLoaded = true;
                press.SetActive(true);
                StartCoroutine(FadeColor(press.GetComponent<Text>()));
            }
            yield return new WaitForSeconds(0.01f);
        }
        yield return null;
    }

    IEnumerator FadeColor(Text text)
    {
        var i = 0.5f;
        var isHalf = true;

        while(!sceneChange)
        {
            if(isHalf)
            {
                text.color = new Color(text.color.r, text.color.g, text.color.b, i += 0.05f);
                if(i >= 1)
                {
                    isHalf = false;
                }
                yield return new WaitForSeconds(0.1f);
            }
            else if(!isHalf)
            {
                text.color = new Color(text.color.r, text.color.g, text.color.b, i -= 0.05f);
                if(i<=0.5)
                {
                    isHalf = true;
                }
                yield return new WaitForSeconds(0.1f);
            }
        }
        yield return null;
    }

}
