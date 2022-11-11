using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    //Bholeshvar Mahadev

    public GameObject cardCanvas;
    public GameObject shopcanvas;
    public RectTransform shopRect;
    public float y = Screen.height;
    float change;

    private void Start()
    {
         change = y / 10;
        cardCanvas.SetActive(true);
        shopcanvas.SetActive(false);
    }
    public void OnClickCart()
    {
        cardCanvas.SetActive(false);
        shopRect.anchoredPosition3D = new Vector3(shopRect.anchoredPosition3D.x, y, shopRect.anchoredPosition3D.z);
        shopcanvas.SetActive(true);
        StartCoroutine(Animation());
    }

    public void OnClickExit()
    {
        shopRect.anchoredPosition3D = new Vector3(shopRect.anchoredPosition3D.x, y, shopRect.anchoredPosition3D.z);
        StartCoroutine(Animation());
        //y = 1072;
    }
    IEnumerator Animation()
    {
        if(y>0)
        {
            while (y > 0)
            {
                y -= change*2;
                shopRect.anchoredPosition3D = new Vector3(shopRect.anchoredPosition3D.x, y, shopRect.anchoredPosition3D.z);
                Debug.Log(y);
                yield return new WaitForSeconds(0.1f);
            }
        }
        else if(y <= 0)
        {
                while (y < Screen.height)
                {
                    y += change*2;
                    shopRect.anchoredPosition3D = new Vector3(shopRect.anchoredPosition3D.x, y, shopRect.anchoredPosition3D.z);
                    Debug.Log(y);
                    yield return new WaitForSeconds(0.1f);
                }
                shopcanvas.SetActive(false);
                cardCanvas.SetActive(true);
        }
    }
}