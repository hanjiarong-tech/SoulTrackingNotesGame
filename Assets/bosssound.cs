using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bosssound : MonoBehaviour
{
    public AudioClip OpenbgSound;
    public GameObject[] obj;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
    }
    void playbgmusic()
    {
        obj = GameObject.FindGameObjectsWithTag("musicbg");
        foreach (GameObject child in obj)
        {
            child.GetComponent<AudioSource>().Stop();
        }
        GetComponent<AudioSource>().Play();
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            transform.SendMessage("playbgmusic");
        }
    }
}
