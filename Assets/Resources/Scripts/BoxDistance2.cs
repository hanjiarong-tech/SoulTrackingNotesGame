using Fungus;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoxDistance2 : MonoBehaviour
{
    public GameObject box;
    public GameObject keypanel;
    private bool e = false;
    public GameObject FPS;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        boxcheck(box);
    }

    private void boxcheck(GameObject gameObject)
    {
        float sqrLenght = (FPS.transform.position - gameObject.transform.position).sqrMagnitude;//获取两个物体向量的平方长度
        bool boxb = BagSystem.instance.Key;
        if (sqrLenght < 3 * 3)//因为sqrLenght是平方，所以对比值也需要平方
        {
            if (!e && !boxb)
            {
                Debug.Log("与目标小于1米");
                Flowchart.BroadcastFungusMessage(gameObject.name);
                print(gameObject.name);
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
