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
    private Animator animator; 

    // Start is called before the first frame update
    void Start()
    {
        animator = starPos1.GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;
        if((int)timer == updateTime){
            animator.SetTrigger("moveNow");
        }
            
    
    }
}
