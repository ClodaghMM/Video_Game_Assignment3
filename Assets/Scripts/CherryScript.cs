using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CherryScript : MonoBehaviour
{
    private int time = 10; 
    public GameObject cheeseCherry;
    private float timer;

    // Start is called before the first frame update
    void Start()
    {
        //instantiate cherry across the middle of the screen
        time = 10;
    }

    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;
        //Debug.Log(timer);
        if((int)timer == time)
        {
            Instantiate(cheeseCherry, new Vector3(1.289526f, -2.484625f, 655.8942f), Quaternion.identity);
        }
        
    }
}
