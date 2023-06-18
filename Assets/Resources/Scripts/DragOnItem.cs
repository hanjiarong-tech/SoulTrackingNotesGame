using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class DragOnItem : MonoBehaviour, IBeginDragHandler, IDragHandler, IEndDragHandler
{
    Transform myParent;
    Transform tempParent;
    RectTransform rt;
    CanvasGroup cg;
    Vector3 newPosition;
    Vector3 pos;

    void Awake()
    {
        rt = this.GetComponent<RectTransform>();
        cg = this.gameObject.AddComponent<CanvasGroup>();
        tempParent = GameObject.Find("Bag").transform;
        myParent = transform.parent;
        pos = myParent.localPosition;
    }


    public void OnBeginDrag(PointerEventData eventData)
    {
        //拖拽开始时记下自己的父物体.
        cg.blocksRaycasts = false;
        this.transform.localScale = new Vector3(0.2f, 0.2f, 0.2f);
    }

    /// <summary>
    /// Raises the drag event.
    /// </summary>
    void IDragHandler.OnDrag(PointerEventData eventData)
    {
        //推拽是图片跟随鼠标移动.
        RectTransformUtility.ScreenPointToWorldPointInRectangle(rt, Input.mousePosition, eventData.enterEventCamera, out newPosition);
        transform.position = newPosition;
    }

    /// <summary>
    /// Raises the end drag event.
    /// </summary>
    public void OnEndDrag(PointerEventData eventData)
    {
        //获取鼠标下面的物体.
        GameObject target = eventData.pointerEnter;

        //如果能检测到物体.
        if (target)
        {
            print(target.tag);
            if(target.tag == "bagcell")
            {
                BagSystem.instance.mappos = int.Parse(target.name);
                BagSystem.instance.Map = true;
                Color Imagecolor = new Color(1f,1f,1f);
                Imagecolor.a = 1f;
                target.GetComponent<Image>().color = Imagecolor;
                target.GetComponent<Image>().sprite = Resources.Load("Images/map1", typeof(Sprite)) as Sprite;
                Destroy(Bag.mapmodule);
                Destroy(this.gameObject);
            }
            else
            {
                this.transform.SetParent(myParent);
                this.transform.localPosition = pos;
                this.transform.localScale = new Vector3(1f, 1f, 1f);
            }
        }
        else
        {
            this.transform.SetParent(myParent);
            this.transform.localPosition = pos;
            this.transform.localScale = new Vector3(1f, 1f, 1f);
        }
        cg.blocksRaycasts = true;
    }    
}

