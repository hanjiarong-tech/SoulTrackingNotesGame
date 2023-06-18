using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;

public class Bag : MonoBehaviour
{
    public GameObject panel;
    public GameObject bag;
    public static GameObject map;
    public GameObject dmap;
    public static GameObject mapmodule;
    // Start is called before the first frame update
    void Start()
    {
        map = gameObject.transform.Find("map").gameObject;
        mapmodule = dmap;
        if (BagSystem.instance.Map)
        {
            dmap.SetActive(false);
        }
    }


    public void clickbag()
    {
        if (!panel.activeSelf)
        {
            panel.SetActive(true);
        }
        else
        {
            panel.SetActive(false);
        }
    }

    public void back()
    {
        BagSystem.instance.diary = true;
        SceneManager.LoadSceneAsync("Dungeon_Map"); 
    }
}
