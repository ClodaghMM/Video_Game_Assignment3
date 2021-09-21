using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tween_Manager : MonoBehaviour
{
    //This script is going to be attached to the pac-man game object or takes an array value. 

    [SerializeField] private GameObject player; 
    private Tweener tweener; 
    private string move;  
    private bool timer; 
    private Transform[] position_vals;



    // Start is called before the first frame update
    void Start()
    {
        tweener = gameObject.GetComponent<Tweener>();
        move = "right";
    
    }

    // Update is called once per frame
    void Update() {

        //update works so that it is being run every frame
        //which is why the move variable is being triggered so much. 
        StartCoroutine(addTweensLerp());

    }

    IEnumerator addTweensLerp() {

        switch(move) 
        {
        case "right":
        tweener.AddTween(player.transform, player.transform.position, new Vector3(1.859f, 1.66f, 0.0f), 1.5f); 
        yield return new WaitForSeconds(1);
        move = "down";
        break; 

        case "down":
        tweener.AddTween(player.transform, player.transform.position, new Vector3(1.883f, 0.47f, 0.0f), 1.5f);
        yield return new WaitForSeconds(2);
        move = "left";
        break; 

        case "left":
        tweener.AddTween(player.transform, player.transform.position, new Vector3(-1.84f, 0.47f, 0.0f), 1.5f);yield return new WaitForSeconds(1);
        move = "up";
        break; 

        case "up":
        tweener.AddTween(player.transform, player.transform.position, new Vector3(-1.84f, 1.66f, 0.0f), 1.5f);
        yield return new WaitForSeconds(2);
        move = "right";
        break; 


        }

        yield return new WaitForEndOfFrame();

    }

    public void destroyTween() {
        Destroy(gameObject.GetComponent<Tweener>());
    }
}



  
