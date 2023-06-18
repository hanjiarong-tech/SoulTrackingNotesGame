using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Fungus;
using UnityEngine.UI;

public class Key : MonoBehaviour
{
    private string Password = "8349";
    private string mima="";
    public GameObject box;
    public GameObject bagpanel;
    public Text text;

    private void Play()
    {
        Animator boxanim = box.GetComponent<Animator>();
        boxanim.SetBool("box", true);
    }

    private void Update()
    {
        text.text = mima;
    }

    public void delete()
    {
        if (mima != "" || mima.Length != 0)
        {
            mima = mima.Remove(mima.Length - 1, 1);
        }
    }
    public void c()
    {
        mima = "";
    }
    public void enter()
    {
        if (mima == Password)
        {
            gameObject.SetActive(false);
            Play();
            BagSystem.instance.Key = true;
            Flowchart.BroadcastFungusMessage("keyget");
            BagPanel.check(bagpanel);
        }
    }
    public void shut()
    {
        gameObject.SetActive(false);
    }
    public void button1()
    {
        mima += "1";
    }
    public void button2()
    {
        mima += "2";
    }
    public void button3()
    {
        mima += "3";
    }
    public void button4()
    {
        mima += "4";
    }
    public void button0()
    {
        mima += "0";
    }
    public void button5()
    {
        mima += "5";
    }
    public void button6()
    {
        mima += "6";
    }
    public void button7()
    {
        mima += "7";
    }
    public void button8()
    {
        mima += "8";
    }
    public void button9()
    {
        mima += "9";
    }
    public void buttona()
    {
        mima += "*";
    }
    public void buttonb()
    {
        mima += "#";
    }
}
