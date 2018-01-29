using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Audio;

public class Anfangspunkt : MonoBehaviour {

    [Header("Inputs")]
    private Vector3 Startpunkt;
    public Text GameOver;
    public LineRenderer Linie;

    public Button switchButton;

    

    public AnimationCurve curve; 

    private int lengthOfLineRenderer;
    private int currLengthLine;

    private Vector3 startPos;
    private Vector3 currentPos;

    private Vector3[] points;

    private float[] samples;
    private float scaler;
    private float halfScreenWidth = 600.0f;
    private float halfScreenHeight = 400.0f;

    private float lineWidth;

    public float cent;
    bool stop;
    float d;
    float z, x, y, p;
    bool schwer = false;

    private TrailRenderer tr;


    public void setLineWidth(float lw)
    {
        lineWidth = lw;
    }

    public void setCents(float c)
    {
        cent = c;
        Debug.Log("cent: " + c.ToString());
    }

    // Use this for initialization
    void Start () {
      //  Mikrofon = GetComponent<AudioSource>();
      //  Mikrofon.clip = Microphone.Start(null, true, 2, AudioSettings.outputSampleRate);
      //  Mikrofon.loop = true;
      //  Mikrofon.volume = 1.0f;

        lengthOfLineRenderer = 5000;
        currLengthLine = 0;
        
        scaler = 0.01f;

        stop = false;
        x = 0;
        y = 0;
        p = 0.7f;

        tr = GetComponentInChildren<TrailRenderer>();

        points = new Vector3[lengthOfLineRenderer];
        for (int i = 0; i < lengthOfLineRenderer; i++)
        {
            points[i] = new Vector3(transform.localPosition.x, transform.localPosition.y);          
        }

       /* Linie = gameObject.AddComponent<LineRenderer>();
        Linie.useWorldSpace = true;
        Linie.widthMultiplier = 0.05f;
        Linie.startColor = Color.blue;
        Linie.loop = false;*/
    }
	
	// Update is called once per frame
	void Update () {

        //  Mikrofon.GetOutputData(samples, 0);

        //currentPos = Input.mousePosition;// - new Vector3(400.0f, 400.0f, 0.0f);


        // Startpunkt = transform.localPosition;

        // startPos = currentPos;

        //transform.localPosition += new Vector3(-0.1f,0.0f,0.0f);
        //transform.localPosition = currentPos - new Vector3(400.0f, 400.0f, 0.0f);// Input.mousePosition - new Vector3(400.0f, 400.0f, 0.0f);



        //transform.localPosition += new Vector3(0.3f, 0.6f, 0.0f);

        if (stop == false)
        {
            d = cent % 1200;
            z = d / 1200;
            x = Mathf.Sin(z * 2 * Mathf.PI) * p;
            y = Mathf.Cos(z * 2 * Mathf.PI) * p;

            if ((schwer))
            {
                p += 0.01f;
            }


            transform.localPosition += new Vector3(x, y, 0.0f);

        }

        Vector3 test = transform.localPosition;

        if (test.x < -436.0f)
        {
            if (schwer)
            {
                GameOver.text = "Game Over!!!";
                stop = true;
            }
            test.x = -436.0f;
        }

        if (test.x > 447.0f)
        {
            if (schwer)
            {
                GameOver.text = "Game Over!!!";
                stop = true;
            }
            test.x = 447.0f;
        }

        if (test.y < -335.0f)
        {
            if (schwer)
            {
                GameOver.text = "Game Over!!!";
                stop = true;
            }
            test.y = -335.0f;
        }

        if (test.y > 350.0f)
        {
            if (schwer)
            {
                GameOver.text = "Game Over!!!";
                stop = true;

            }
            test.y = 350.0f;
        }

        transform.localPosition = test;

        //Vector3 test = transform.localPosition;

        // prevent overflow




        /* points[currLengthLine + 1].x = scaler * (transform.localPosition.x);
         points[currLengthLine + 1].y = scaler * (transform.localPosition.y);

         // Debug.Log("Linienende: " + points[0]);
        curve = new AnimationCurve();
         curve.AddKey(0.0f, 0.0f);
         curve.AddKey(1.0f, 1.0f);

         Linie.positionCount = currLengthLine + 1;
         Linie.SetPositions(points);
         Linie.widthMultiplier = lineWidth;
         Linie.widthCurve = curve;

         currLengthLine += 1;*/

    }

    public void SwitchDifficulty()
    {
        schwer = !schwer;
        p = 0.5f;

        if (schwer == true)
        {
            switchButton.GetComponentInChildren<Text>().text = "schwer";
        }
        else
        {
            switchButton.GetComponentInChildren<Text>().text = "leicht";

        }

            /*
                    // Button go = GameObject<Button>.Find("SwitchButton");
                    // Text switchText = go.GetComponentsInChildren<Text>();
                    Vector3 test = transform.localPosition;
                    if (schwer == true)
                    { 
                        switchButton.GetComponentInChildren<Text>().text = "schwer";
                    //    switchText = "schwer";
                        Debug.Log("schwer");
                        if (test.x < -436.0f)
                        {
                            GameOver.text = "Game Over!!!";
                            test.x = -436.0f;
                        }

                        if (test.x > 447.0f)
                        {
                            GameOver.text = "Game Over!!!";
                            test.x = 447.0f;
                        }

                        if (test.y < -335.0f)
                        {
                            GameOver.text = "Game Over!!!";
                            test.y = -335.0f;
                        }

                        if (test.y > 350.0f)
                        {
                            GameOver.text = "Game Over!!!";
                            test.y = 350.0f;
                        }

                        transform.localPosition = test;

                        Debug.Log("x: " + test.x + "y: " + test.y);


                    }
                    else
                    {
                        switchButton.GetComponentInChildren<Text>().text = "leicht";
                        //switchText = "leicht";
                        Debug.Log("leicht");
                        if (test.x < -436.0f)
                        {
                            test.x = -436.0f;
                        }

                        if (test.x > 447.0f)
                        {
                            test.x = 447.0f;
                        }

                        if (test.y < -335.0f)
                        {
                            test.y = -335.0f;
                        }

                        if (test.y > 350.0f)
                        {
                            test.y = 350.0f;
                        }

                        transform.localPosition = test;

                        Debug.Log("x: " + test.x + "y: " + test.y);


                    }
                    */

        }
    public void Neu()
    {
        tr.Clear();
        Debug.Log("Neu");
        transform.localPosition = new Vector3(0.0f, 0.0f, 0.0f);
        p = 0.5f;
        GameOver.text = " ";
        stop = false;

    }

    
}


