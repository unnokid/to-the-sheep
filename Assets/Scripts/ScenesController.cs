using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
public class ScenesController : MonoBehaviour
{
    public GameObject GameclearPanel;
    public Text Cleartime;
    public float time_current;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        time_current = GameObject.Find("GameManager").GetComponent<UITimer>().getTime();
        Cleartime.text = "½Ã°£: "+$"{time_current:N2}";
    }


    public void closeClearPanel()
    {
        GameclearPanel.SetActive(false);
    }
    public void openClearPanel()
    {
        GameclearPanel.SetActive(true);
    }
    public void returnStartScene()
    {
        GameclearPanel.SetActive(false);
        SceneManager.LoadScene("StartGame");
    }

    
}
