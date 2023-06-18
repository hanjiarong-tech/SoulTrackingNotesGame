using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class opendoor : MonoBehaviour
{
    public AudioClip OpenSound;
    public Animator anim1;
    public Animator anim2;
    bool doorisopen=false;
    //public AudioClip OpenbgSound;
    public float doorOpenTime=30f;
    float doorTimer = 0.0f;
    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        if (doorisopen)
        {
            doorTimer += Time.deltaTime;
            if (doorTimer > doorOpenTime)
            {
                doorshut();
                doorTimer = 0.0f;

            }
        }
    }
    void doorcheck()
    {
        if (!doorisopen)
        {
            dooropen();
        }
    }
    void dooropen()
    {
        anim1.SetBool("open", true);
        anim2.SetBool("open", true);
        Invoke("playsound", 0.1f);
        doorisopen = true;
        //GetComponent<AudioSource>().PlayOneShot(OpenbgSound);
    }
    void doorshut()
    {
        anim1.SetBool("open", false);
        anim2.SetBool("open", false);
        doorisopen = false;
        Invoke("playsound", 0.1f);
    }
    void playsound()
    {
        GetComponent<AudioSource>().PlayOneShot(OpenSound);
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            transform.SendMessage("doorcheck");
        }
    }
}
