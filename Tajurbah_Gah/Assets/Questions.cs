using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
using System.IO;
using System;

public class Questions : MonoBehaviour
{
    public UnityEngine.UI.Button miscibleb;
    public UnityEngine.UI.Button imiscibleb;
    public UnityEngine.UI.Button submitb;
    public UnityEngine.UI.Button closeb;
    public UnityEngine.UI.Button pclosebutton;
    public UnityEngine.UI.Button closebutton;
    public UnityEngine.UI.Text t;
    public UnityEngine.UI.InputField IF;
    public UnityEngine.UI.Button stepsb;
    public UnityEngine.UI.Button gifsb;
    public UnityEngine.UI.Button qbutton;
    private int qno = 0;
    public GameObject panel;
    public GameObject canvas;
    public GameObject stepspanel;
    public GameObject gifpanel;
    public Image gifimages;
    public Sprite[] images;
    
    
    
    
   
    void Start()
    { 
       miscibleb.onClick.AddListener(onMiscibleclick);
       imiscibleb.onClick.AddListener(oniMiscibleclick);
       submitb.onClick.AddListener(onSubmitclick);
       stepsb.onClick.AddListener(onStepsClick);
       closeb.onClick.AddListener(onClosebclick);
       gifsb.onClick.AddListener(onGifsbclick);
       closebutton.onClick.AddListener(onclosebClick);
       pclosebutton.onClick.AddListener(onclosepbClick);
       qbutton.onClick.AddListener(oqbClick);

    }

    private void oqbClick()
    {
        RectTransform rt = panel.GetComponent<RectTransform>();
        rt.localScale = new Vector3(1, 1, 1);
        RectTransform rt2 = qbutton.GetComponent<RectTransform>();
        rt2.localScale = new Vector3(0,0,0);
    }

    private void onclosepbClick()
    {
        RectTransform rt = panel.GetComponent<RectTransform>();
        rt.localScale = new Vector3(0, 0, 0);
        RectTransform rt2 = qbutton.GetComponent<RectTransform>();
        rt2.localScale = new Vector3(1, 1, 1);
    }

    void onclosebClick()
    {
        RectTransform rt = gifpanel.GetComponent<RectTransform>();
        rt.localScale = new Vector3(0, 0, 0);
    }
   
    void onClosebclick()
    {
        RectTransform rt = stepspanel.GetComponent<RectTransform>();
        rt.localScale = new Vector3(0, 0, 0);
    }
    void onStepsClick()
    {
        RectTransform rt = stepspanel.GetComponent<RectTransform>();
        rt.localScale = new Vector3(1, 1, 1);
    }
    void onGifsbclick()
    {
        RectTransform rt = gifpanel.GetComponent<RectTransform>();
        rt.localScale = new Vector3(1, 1, 1);
    }

    void onSubmitclick()
    {
        string serializedData = IF.text;
        StreamWriter writer = new StreamWriter("C:/Users/HP/Tajurbah_Gah/Assets/ans.txt", true);
        
        if (qno ==4)
        {
            serializedData = "3. " + serializedData;
            writer.WriteLine(serializedData);
            writer.Close();
            Destroy(IF.gameObject);
            t.text = "RESPONSE SUBMITTED";
            t.fontSize = 20;
            t.color = Color.green;
            t.fontStyle = FontStyle.Normal;
            Destroy(submitb.gameObject);
            
        }
        else if (qno == 3)
        {
            serializedData = "2. " + serializedData;
            writer.WriteLine(serializedData);
            writer.Close();
            IF.text = " ";
            t.text = "Why is it generally easy to remove stains from synthetic fabrics than from cotton fabrics?";
            qno++;
        }
        else if (qno==2)
        {
            serializedData = "1. " + serializedData;
            writer.WriteLine(serializedData);
            writer.Close();
            IF.text = " ";
            t.text = "Water insoluble lubricants are used to run machines. What type of soaps are used to clean these machines?";
            qno++;
        }

        
        
        
        
        
    }
    // Update is called once per frame
    void onMiscibleclick()
    {
        if(qno==0)
        {
            t.text = "water and oil are immiscible. Choose the correct option to proceed";
            t.fontSize = 12;
            t.fontStyle = FontStyle.Bold;
            t.color = Color.red;
        }

        else if(qno==1)
        {
            t.text = "CORRECT";
            t.fontSize = 15;
            t.color = Color.green;
            qno++;
            StartCoroutine(wait());
            t.text = "How will you remove grease stains from cotton fabrics?";
            t.color = Color.white;
            t.fontSize = 12;
            Destroy(miscibleb.gameObject);
            Destroy(imiscibleb.gameObject);
            RectTransform rt = IF.GetComponent<RectTransform>();
            rt.localScale = new Vector3(1,1,1);
            rt = submitb.GetComponent<RectTransform>();
            rt.localScale = new Vector3(1, 1, 1);
            
     

            

        }
        
    }
    IEnumerator wait()
    {
       
        yield return new WaitForSeconds(10f);
        
    }
    void oniMiscibleclick()
    {
        if(qno==0)
        {
            t.text = "CORRECT";
            t.fontSize = 15;
            t.color = Color.green;
            StartCoroutine(wait());
            qno++;
            t.text = "WATER AND ETHANOL ARE?";
            t.fontSize = 14;
            t.color = Color.white;
        }
        else if(qno==1)
        {
            t.text = "water and ethanol are miscible. Choose the correct option to proceed";
            t.fontSize = 12;
            t.fontStyle = FontStyle.Bold;
            t.color = Color.red;
        }

        
        
    }
    

    void Update()
    {
        gifimages.sprite = images[(int)(Time.time * 10) % images.Length];
    }

}
