using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ButtonSound : MonoBehaviour
{
    [SerializeField] AudioClip m_audioClip;
    [SerializeField] [Range(0.0f, 1.0f)] float m_volume = 1.0f;
    AudioSource m_audioSource;

    void Awake()
    {
        m_audioSource = gameObject.AddComponent<AudioSource>();

        if(m_audioClip != null)
        {
            m_audioSource.clip = m_audioClip;
        }
        m_audioSource.playOnAwake = false;
        m_audioSource.volume = m_volume;
        //GetComponent<Button>().onClick.AddListener(() => m_audioSource.Play());
    }

    public void onClick()
    {
        int x = 5;
        m_audioSource.Play();
        Debug.Log("Miau " + "x:" + x.ToString());
    }
}
