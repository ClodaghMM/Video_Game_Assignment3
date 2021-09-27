using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class die_animation : MonoBehaviour
{

    [SerializeField] private GameObject mouse_death; 
    private Animator animatorController; 
    // Start is called before the first frame update
    void Start()
    {
        animatorController = mouse_death.GetComponent<Animator>();
        
    }

    // Update is called once per frame
    void Update()
    {
            animatorController.SetTrigger("Die");
            animatorController.SetTrigger("Start_Move");
        }
    }

