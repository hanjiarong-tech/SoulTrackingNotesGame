using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BagPanel : MonoBehaviour
{

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void clickcheck()
    {
        check(gameObject);
    }


    public static void check(GameObject gameObject)
    {
        print(BagSystem.instance.Book);
        if (BagSystem.instance.Book)
        {
            gameObject.transform.Find("Book").gameObject.SetActive(true);
        }
        else
        {
            gameObject.transform.Find("Book").gameObject.SetActive(false);
        }
        if (BagSystem.instance.Map)
        {
            Color Imagecolor = new Color(1f, 1f, 1f);
            Imagecolor.a = 1f;
            gameObject.transform.GetChild(BagSystem.instance.mappos).GetComponent<Image>().color = Imagecolor;
            gameObject.transform.GetChild(BagSystem.instance.mappos).GetComponent<Image>().sprite = Resources.Load("Images/map1", typeof(Sprite)) as Sprite;
        }
        if (BagSystem.instance.diary)
        {
            if (BagSystem.instance.diarypos == 0)
            {
                BagSystem.instance.diarypos = finddiarypos(BagSystem.instance.mappos, BagSystem.instance.Keypos);
            }
            Color Imagecolor = new Color(1f, 1f, 1f);
            Imagecolor.a = 1f;
            gameObject.transform.GetChild(BagSystem.instance.diarypos).GetComponent<Image>().color = Imagecolor;
            gameObject.transform.GetChild(BagSystem.instance.diarypos).GetComponent<Image>().sprite = Resources.Load("Images/cover1", typeof(Sprite)) as Sprite;
        }
        if (BagSystem.instance.Key)
        {
            if (BagSystem.instance.Keypos == 0)
            {
                BagSystem.instance.Keypos = findkeypos(BagSystem.instance.mappos, BagSystem.instance.diarypos);
            }
            Color Imagecolor = new Color(1f, 1f, 1f);
            Imagecolor.a = 1f;
            gameObject.transform.GetChild(BagSystem.instance.Keypos).GetComponent<Image>().color = Imagecolor;
            gameObject.transform.GetChild(BagSystem.instance.Keypos).GetComponent<Image>().sprite = Resources.Load("Images/key1", typeof(Sprite)) as Sprite;
        }
    }

    public static int findkeypos(int mappos,int diarypos)
    {
        int[] pos = new int[7];
        pos[0] = 1;
        pos[mappos] = 1;
        pos[diarypos] = 1;
        for(int i = 0; i < 7; i++)
        {
            if (pos[i] == 0)
            {
                return i;
            }
        }
        return -1;
    }

    public static int finddiarypos(int mappos, int keypos)
    {
        int[] pos = new int[7];
        pos[0] = 1;
        pos[mappos] = 1;
        pos[keypos] = 1;
        for (int i = 0; i < 7; i++)
        {
            if (pos[i] == 0)
            {
                return i;
            }
        }
        return -1;
    }
}
