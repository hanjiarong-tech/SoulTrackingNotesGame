using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using Fungus;

public class fingerprint : MonoBehaviour
{
    public static bool status;
    public Fungus.Flowchart flowchart;
    // Start is called before the first frame update

    public void clickprint()
    {
        if (BagSystem.instance.diary && BagSystem.instance.Map && BagSystem.instance.Key && BagSystem.instance.Book)
        {
            Flowchart.BroadcastFungusMessage("choose");
            if (flowchart.GetBooleanVariable("choose"))
            {
                SceneManager.LoadSceneAsync("Character");
            }

        }
        else
        {
            print("no");
        }
    }
}
