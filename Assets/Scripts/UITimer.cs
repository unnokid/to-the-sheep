using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UITimer : MonoBehaviour
{
    public UnityEngine.UI.Text text_Timer;
    private float time_start;
    private float time_current;
    private float time_Max = 100000.0f;
    private bool isEnded;
    private bool isTimerout=false;

    private void Start()
    {
        Reset_Timer();
    }
    void Update()
    {
        if (isEnded)
        {
            return;
        }
            

        Check_Timer();
    }

    private void Check_Timer()
    {
        time_current = Time.time - time_start;
        if (time_current < time_Max)
        {
            text_Timer.text = $"{time_current:N2}";
            text_Timer.gameObject.SetActive(true);
        }
        else if (!isEnded)
        {
            End_Timer();
        }
    }

    public void End_Timer()
    {
        Debug.Log("End");
        time_current = time_Max;
        text_Timer.text = $"{time_current:N2}";
        isEnded = true;
    }


    public void Reset_Timer()
    {
        text_Timer.gameObject.SetActive(true);
        time_start = Time.time;
        time_current = 0;
        text_Timer.text = $"{time_current:N2}";
        isEnded = false;
       
    }

    public void Timeup()
    {
        isEnded = true;
        StartCoroutine(ShowReady());
    }
    
    public bool isTimeup()
    {
        return isEnded;
    }

    public float getTime()
    {
        return time_current;
    }

    IEnumerator ShowReady()
    {
        if(!isTimerout)
        {
            isTimerout = true;
            while (isEnded)
            {

                text_Timer.gameObject.SetActive(true);
                yield return new WaitForSeconds(0.5f);
                text_Timer.gameObject.SetActive(false);
                yield return new WaitForSeconds(0.5f);

            }
        }
       

    }
}
