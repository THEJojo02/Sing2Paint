using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Audio;

[RequireComponent (typeof(AudioSource))]
public class MicrophoneSpectrum : MonoBehaviour
{

    [Header("Inputs")]
    [SerializeField] KeyCode _switch;

    public Text PitchDisplay;
    public Button PlayButton;

    public bool showSpectrum = true;

    public LineRenderer waveForm;

    public int lenghtOfLineRenderer = 4096;

    private AudioSource currentAudioSource;

    // Canvas newObject = (Canvas)GameObject.Find(gameObjectName);
    // public GameObject achtelNote;
    public Anfangspunkt m_achtelnote;

    private float[] samples;
    private float[] spectrum;

    private Vector3[] points;

    private float audioPegel;

    // Use this for initialization
    void Start()
    {

        GameObject go = GameObject.Find("Achtelnote");
        m_achtelnote = go.GetComponent<Anfangspunkt>();

       
        // Debug.Log("obj:" + achtelNote);
        // Debug.Break();

        currentAudioSource = GetComponent<AudioSource>();
        currentAudioSource.clip = Microphone.Start(null, true, 2, AudioSettings.outputSampleRate);
        currentAudioSource.loop = true;
        currentAudioSource.volume = 1.0f;
        currentAudioSource.Play();

        waveForm = gameObject.AddComponent<LineRenderer>();
        waveForm.widthMultiplier = 0.05f;
        waveForm.startColor = Color.red;
        waveForm.loop = false;

        samples = new float[lenghtOfLineRenderer];
        spectrum = new float[lenghtOfLineRenderer];

        points = new Vector3[lenghtOfLineRenderer];
        for (int i = 0; i < lenghtOfLineRenderer; i++)
        {
            points[i] = new Vector3(0.0f, 0.0f);
        }

        audioPegel = 0.0f;
    }
	
	// Update is called once per frame
	void Update ()
    {

      //  achtelNote.setMalen(false);


        if (Input.GetKeyDown (_switch))
        {
            showSpectrum = !showSpectrum;
            return;
        
        }
        // get samples from microphone
        currentAudioSource.GetOutputData(samples, 0);

        audioPegel = 0.0f;
        for (int k = 0; k < lenghtOfLineRenderer;k++)
        {
            audioPegel += Mathf.Abs(samples[k]);
        }

        audioPegel = 0.15f; // audioPegel / (float)lenghtOfLineRenderer;

        Debug.Log("Pegel: " + audioPegel);
        m_achtelnote.setLineWidth(audioPegel);

        //get magnitude spectrum from microphone
        currentAudioSource.GetSpectrumData(spectrum, 0, FFTWindow.Hanning);

        // these numbers should be fetched from the object
        float drawWidth = 80.0f;
        float leftPos = -drawWidth * 0.5f;
        float rightPos = drawWidth * 0.5f;

        if(showSpectrum)
        {
            for(int i = 0; i < lenghtOfLineRenderer; i++)
            {
                points[i].x = Mathf.Log(1.0f + i);
                points[i].y = Mathf.Log(1.0f + spectrum[i] * 100.0f);  
            }
        }
        else
        {
            for (int i = 0; i < lenghtOfLineRenderer; i++)
            {
                points[i].x = leftPos + drawWidth * (i / (float)lenghtOfLineRenderer);
                points[i].y = 10.0f * samples [i];
            }
        }
        waveForm.positionCount = lenghtOfLineRenderer;
        waveForm.SetPositions(points);
        waveForm.startColor = Color.blue;
        waveForm.loop = false;
	}
}
