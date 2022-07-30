using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using UnityEngine.UI;

public class DateTime : MonoBehaviour
{
    [SerializeField] Text time;
    [SerializeField] Text date;
    [SerializeField] Text day;
    [SerializeField] Text month;
    //[SerializeField] Text era;

    void Start()
    {
        date.text   = System.DateTime.Now.ToString("MM/dd/yyy");
        day.text    = System.DateTime.Now.ToString("dddd");
        month.text  = System.DateTime.Now.ToString("MMMM");
        //era.text    = System.DateTime.Now.ToString("gg");
        


    }

    // Update is called once per frame
    void Update()
    {
        time.text = System.DateTime.Now.ToString("hh:mm:ss");

    }
}
