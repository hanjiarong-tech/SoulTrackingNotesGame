using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using Fungus;

public class BagClick : MonoBehaviour
{
    public GameObject Contrast;
    public GameObject map;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    
    public void click()
    {
        if (gameObject.name == "Book")
        {
            if (Contrast.activeSelf)
            {
                Contrast.SetActive(false);
                
            }
            else
            {
                Flowchart.BroadcastFungusMessage("book");
                Contrast.SetActive(true);
                map.SetActive(false);
            }
        }
        else if (gameObject.name == BagSystem.instance.mappos.ToString())
        {
            if (map.activeSelf)
            {
                map.SetActive(false);
                
            }
            else
            {
                Flowchart.BroadcastFungusMessage("map");
                map.SetActive(true);
                Contrast.SetActive(false);
            }
        }
        else if(gameObject.name == BagSystem.instance.diarypos.ToString())
        {
            SceneManager.LoadSceneAsync("Diary");
        }
        else if (gameObject.name == BagSystem.instance.Keypos.ToString())
        {
            Flowchart.BroadcastFungusMessage("key");
        }
    }
}
