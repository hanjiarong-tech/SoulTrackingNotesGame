using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BagSystem : MonoBehaviour
{
    public static BagSystem instance;
    [HideInInspector]
    public int Cuenumber;
    [HideInInspector]
    public bool Key;
    [HideInInspector]
    public bool Map;
    [HideInInspector]
    public bool Book;
    [HideInInspector]
    public bool diary;
    public int Keypos;
    public int mappos;
    public int diarypos;
    // Start is called before the first frame update

    private void Awake()
    {
        Book = true;
        instance = this;
    }

    void Start()
    {
        GameObject.DontDestroyOnLoad(gameObject);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

}
