using Fungus;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Distance : MonoBehaviour
{
    public GameObject FPS;
    private bool b = false;
    public Fungus.Flowchart myflowchart;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        float sqrLenght = (FPS.transform.position - gameObject.transform.position).sqrMagnitude;//获取两个物体向量的平方长度
        if (sqrLenght < 3 * 3)//因为sqrLenght是平方，所以对比值也需要平方
        {
            if (!b)
            {
                Debug.Log("与目标小于5米");
                Flowchart.BroadcastFungusMessage("receive");
                b = true;
            }
        }
        else
        {
            b = false;
        }
        if (b)
        {
            int cue = myflowchart.GetIntegerVariable("Cue");
            if (cue >= 2)
            {
                myflowchart.SetBooleanVariable("Book", true);
            }
            if (Input.GetKeyDown(KeyCode.E)){
                if(cue >= 2)
                {

                    SceneManager.LoadSceneAsync("Diary");
                }
            }
        }
}
}
