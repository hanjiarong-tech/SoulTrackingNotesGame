using UnityEngine;
using System.Collections;
using UnityEngine.EventSystems;

public class DragOnPic : MonoBehaviour, IBeginDragHandler, IDragHandler, IEndDragHandler
{

    //记录下自己的父物体.
    Transform myParent;

    //Panel，使拖拽是显示在最上方.
    Transform tempParent;
    CanvasGroup cg;
    RectTransform rt;

    //记录鼠标位置.
    Vector3 newPosition;

    void Awake()
    {
        //添加CanvasGroup组件用于在拖拽是忽略自己，从而检测到被交换的图片.
        cg = this.gameObject.AddComponent<CanvasGroup>();

        rt = this.GetComponent<RectTransform>();

        tempParent = GameObject.Find("Canvas").transform;
    }

    /// <summary>
    /// Raises the begin drag event.
    /// </summary>
    public void OnBeginDrag(PointerEventData eventData)
    {
        //拖拽开始时记下自己的父物体.
        myParent = transform.parent;

        //拖拽开始时禁用检测.
        cg.blocksRaycasts = false;

        this.transform.SetParent(tempParent);
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
            GameManager.SetParent(this.transform, target.transform, myParent);
        }
        else
        {
            this.transform.SetParent(myParent);
            this.transform.localPosition = Vector3.zero;
        }

        //拖拽结束时启用检测.
        cg.blocksRaycasts = true;

        //检测是否完成拼图.
        if (GameManager.CheckWin())
        {
            Debug.Log("Win!!!");
            Bag.map.SetActive(true);
        }

    }

}