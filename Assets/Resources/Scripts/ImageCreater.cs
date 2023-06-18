using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class ImageCreater : MonoBehaviour
{
    public static ImageCreater _instance;

    //存储裁剪好图片的数组.
    public Sprite[] sprites;

    //格子的预设体.
    public GameObject cellPrefab;


    void Start()
    {
        _instance = this;
        CreateImages();
    }

    private void CreateImages()
    {
        //将图片数组随机排列.
        GameManager.RandomArray(sprites);

        //生产图片.
        for (int i = 0; i < sprites.Length; i++)
        {
            //通过预设体生成图片.
            GameObject cell = (GameObject)Instantiate(cellPrefab);

            //设置cell的名字方便检测是否完成拼图.
            cell.name = i.ToString();

            //获取cell的子物体.
            Transform image = cell.transform.GetChild(0);

            //设置显示的图片.
            image.GetComponent<Image>().sprite = sprites[i];

            //设置子物体的名称，方便检测是否完成拼图.
            int tempIndex = sprites[i].name.LastIndexOf('_');
            image.name = sprites[i].name.Substring(tempIndex + 1);

            //将Cell设置为Panel的子物体.
            cell.transform.SetParent(this.transform);

            //初始化大小.
            cell.transform.localScale = Vector3.one;
        }
    }

}

public class GameManager
{

    /// <summary>
    /// Randoms the array.
    /// </summary>
    static public void RandomArray(Sprite[] sprites)
    {
        for (int i = 0; i < sprites.Length; i++)
        {
            //随机抽取数字中的一个位置，并将这张图片与第i张图片交换.
            int index = Random.Range(i, sprites.Length);
            Sprite temp = sprites[i];
            sprites[i] = sprites[index];
            sprites[index] = temp;
        }
    }

    static public void SetParent(Transform mine, Transform target, Transform oldParent)
    {
        //如果检测到图片，则交换父物体并重置位置.
        switch (target.tag)
        {
            case "Cell":
                mine.SetParent(target.parent);
                target.SetParent(oldParent);
                mine.localPosition = Vector3.zero;
                target.localPosition = Vector3.zero;
                break;
            default:
                mine.SetParent(oldParent);
                mine.localPosition = Vector3.zero;
                break;
        }
    }

    /// <summary>
    /// Checks is win.
    /// </summary>
    static public bool CheckWin()
    {
        for (int i = 0; i < ImageCreater._instance.transform.childCount; i++)
        {
            if (ImageCreater._instance.transform.GetChild(i).name != ImageCreater._instance.transform.GetChild(i).transform.GetChild(0).name)
            {
                return false;
            }
        }
        return true;
    }
}