using Fungus;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoxDistance : MonoBehaviour
{
    public GameObject FPS;
    private bool a = false;
    private bool b = false;
    private bool c = false;
    private bool d = false;
    private bool e = false;
    public GameObject coffin1;
    public GameObject coffin2;
    public GameObject coffin3;
    public GameObject rock;
    public GameObject box;
    public GameObject keypanel;
    public Fungus.Flowchart myflowchart;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        coffincheck1(coffin1);
        coffincheck2(coffin2);
        coffincheck3(coffin3);
        boxcheck(box);
        rockheck(rock);
    }

    private void coffincheck1(GameObject gameObject)
    {
        float sqrLenght = (FPS.transform.position - gameObject.transform.position).sqrMagnitude;//获取两个物体向量的平方长度
        if (sqrLenght < 3 * 3)//因为sqrLenght是平方，所以对比值也需要平方
        {
            if (!a)
            {
                Debug.Log("与目标小于5米");
                Flowchart.BroadcastFungusMessage(gameObject.name);
                print(gameObject.name);
                a = true;
            }
        }
    }

    private void coffincheck2(GameObject gameObject)
    {
        float sqrLenght = (FPS.transform.position - gameObject.transform.position).sqrMagnitude;//获取两个物体向量的平方长度
        if (sqrLenght < 3 * 3)//因为sqrLenght是平方，所以对比值也需要平方
        {
            if (!b)
            {
                Debug.Log("与目标小于5米");
                Flowchart.BroadcastFungusMessage(gameObject.name);
                print(gameObject.name);
                b = true;
            }
        }
    }

    private void rockheck(GameObject gameObject)
    {
        float sqrLenght = (FPS.transform.position - gameObject.transform.position).sqrMagnitude;//获取两个物体向量的平方长度
        if (sqrLenght < 2)//因为sqrLenght是平方，所以对比值也需要平方
        {
            if (!c)
            {
                Debug.Log("与目标小于1米");
                Flowchart.BroadcastFungusMessage(gameObject.name);
                print(gameObject.name);
                c = true;
            }
        }
        else
        {
            if (!myflowchart.GetBooleanVariable("Rock"))
            {
                c = false;
            }
            else
            {
                c = true;
            }
        }
    }

    private void coffincheck3(GameObject gameObject)
    {
        float sqrLenght = (FPS.transform.position - gameObject.transform.position).sqrMagnitude;//获取两个物体向量的平方长度
        if (sqrLenght < 4)//因为sqrLenght是平方，所以对比值也需要平方
        {
            if (!d)
            {
                Debug.Log("与目标小于1米");
                Flowchart.BroadcastFungusMessage(gameObject.name);
                print(gameObject.name);
                d = true;
            }
        }
        else
        {
            if (!myflowchart.GetBooleanVariable("Coffin"))
            {
                d = false;
            }
        }
    }

    private void boxcheck(GameObject gameObject)
    {
        float sqrLenght = (FPS.transform.position - gameObject.transform.position).sqrMagnitude;//获取两个物体向量的平方长度
        bool boxb = BagSystem.instance.Key;
        if (sqrLenght < 3*3)//因为sqrLenght是平方，所以对比值也需要平方
        {
            if (!e && !boxb)
            {
                Debug.Log("与目标小于1米");
                Flowchart.BroadcastFungusMessage(gameObject.name);
                e = true;
            }
            if (!boxb)
            {
                if (Input.GetKeyDown(KeyCode.E))
                {
                    keypanel.SetActive(true);
                }
            }
        }
        else
        {
            if (!boxb)
            {
                e = false;
            }
            else
            {
                e = true;
            }
        }
    }
}
