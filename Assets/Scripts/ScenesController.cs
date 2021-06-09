using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ScenesController : MonoBehaviour
{
    public GameObject GameclearPanel;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }


    public void closeClearPanel()
    {
        GameclearPanel.SetActive(false);
    }

    public void returnStartScene()
    {
        GameclearPanel.SetActive(false);
        SceneManager.LoadScene("StartGame");
    }

    
}
