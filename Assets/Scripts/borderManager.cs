using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class borderManager : MonoBehaviour
{
    public GameObject[] starsTransform;
    private float timer;
    private int updateTime = 2;
    private Tweener tweener;
    public GameObject starPos1;
    private Animator animatorPos1; 
    private Animator animatorPos2;
    private Animator animatorPos3;
    private Animator animatorPos4;

    // Start is called before the first frame update
    void Start()
    {
        animatorPos1 = starsTransform[0].
        GetComponent<Animator>();
        animatorPos2 = starsTransform[1].GetComponent<Animator>();
        animatorPos3 = starsTransform[2].GetComponent<Animator>();
        animatorPos4 = starsTransform[3].GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;
        if((int)timer == updateTime){
            animatorPos1.SetTrigger("moveNow");
            animatorPos1.SetTrigger("moveBack");
            animatorPos2.SetTrigger("moveDown");
            animatorPos2.SetTrigger("downBack");
            animatorPos3.SetTrigger("moveLeft");
            animatorPos3.SetTrigger("LeftBack");
            animatorPos4.SetTrigger("MoveUp");
            animatorPos4.SetTrigger("upBack");

        updateTime += 2;
        }
        
    
    }
}
