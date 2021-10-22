using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicPlayerScrpit : MonoBehaviour {

    AudioSource audSrce;
    private bool isPlaying = false;

	void Start ()
    {

        audSrce = GetComponent<AudioSource>();      

        DontDestroyOnLoad(gameObject);
        var destroy = FindObjectsOfType<MusicPlayerScrpit>();
        for (int i = 1; i < destroy.Length; i++)
        {
            Destroy(destroy[i]);
        }
	}

    void Update()
    {
        if (isPlaying == false)
        {
            audSrce.Play();
            isPlaying = true;
        }
    }
}