using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ChangePanelColor : MonoBehaviour
{
    private Color exitcolor = new Color(67/255f, 75/255f, 183/255f, 212/255f);
    private Color entercolor = new Color(138/255f, 145/255f, 253/255f, 212/255f);
    

    void Start()
    {
        
    }

    private void OnMouseEnter()
    {
        //print("���콺�� ������Ʈ ���� �ֽ��ϴ�.");
        this.gameObject.GetComponent<Image>().color = entercolor;
    }

    private void OnMouseExit()
    {
        //print("���콺�� ������Ʈ ������ ������ϴ�.");
        this.gameObject.GetComponent<Image>().color = exitcolor;
    }
   

}
