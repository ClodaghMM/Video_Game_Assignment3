using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Background_Music : MonoBehaviour
{

    [SerializeField] private AudioSource startMusic; 
    [SerializeField] private AudioSource normalState;

    // Start is called before the first frame update
    void Start()
    {   
    }

    // Update is called once per frame
    void Update()
    {
        if (!startMusic.isPlaying)
        {
            normalState.Play();
        }
    }
}
