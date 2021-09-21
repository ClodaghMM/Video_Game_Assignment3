using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tween_Manager : MonoBehaviour
{
    //This script is going to be attached to the pac-man game object or takes an array value. 

    [SerializeField] private GameObject player; 
    private Tweener tweener; 
    [SerializeField] private Transform[] stars;
    private string move;  



    // Start is called before the first frame update
    void Start()
    {
        tweener = gameObject.GetComponent<Tweener>();

        move = "right";
    }

    // Update is called once per frame
    void Update() {

        //update works so that it is being run every frame
        //which is why moveCount is being triggered so much. 
        StartCoroutine(addTweensLerp());


    }

    IEnumerator addTweensLerp() {
        
        switch(move) 
        {
        case "right":
        tweener.AddTween(player.transform, player.transform.position, new Vector3(1.859f, 1.66f, 0.0f), 1.5f); 
        move = "down";
        break; 

        case "down":
        tweener.AddTween(player.transform, player.transform.position, new Vector3(1.883f, 0.47f, 0.0f), 1.5f);
        break; 

        case "left":
        tweener.AddTween(player.transform, player.transform.position, new Vector3(-0.264f, 0.47f, 0.0f), 1.5f);
        break; 
        
        }
        yield return new WaitForEndOfFrame();

    }
}



  
