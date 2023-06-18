using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bag1 : MonoBehaviour
{
    public GameObject panel;
    public GameObject bag;
    public GameObject contrast;
    public GameObject map;
    // Start is called before the first frame update

    public void clickbag()
    {
        if (!panel.activeSelf)
        {
            panel.SetActive(true);
        }
        else
        {
            panel.SetActive(false);
            contrast.SetActive(false);
            map.SetActive(false);
        }
    }
}
