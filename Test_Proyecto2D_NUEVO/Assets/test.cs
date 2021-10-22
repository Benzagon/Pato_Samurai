using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class test : MonoBehaviour {
	void Start ()
    {
        DontDestroyOnLoad(gameObject);
        var destroy = FindObjectsOfType<test>();
        for (int i = 1; i < destroy.Length; i++)
        {
            Destroy(destroy[i]);
        }
	}
}