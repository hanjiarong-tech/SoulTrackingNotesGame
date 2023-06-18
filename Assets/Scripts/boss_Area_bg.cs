using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class boss_Area_bg : MonoBehaviour
{
    public AudioClip OpenbgSound;
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
        GetComponent<AudioSource>().PlayOneShot(OpenbgSound);
    }
    void stopbgmusic()
    {
        GetComponent<AudioSource>().Stop() ;
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            transform.SendMessage("playbgmusic");
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            transform.SendMessage("stopbgmusic");
        }
    }
    
}
