using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tween_Manager : MonoBehaviour
{
    //This script is going to be attached to the pac-man game object or takes an array value. 

    [SerializeField] private GameObject player; 
    private Tweener tweener; 
    //positions of stars used to calculate the lerp
    //[SerializeField] private Vector3[] stars_pos;
    private int count; 


    // Start is called before the first frame update
    void Start()
    {
        tweener = gameObject.GetComponent<Tweener>();
    }

    // Update is called once per frame
    void Update() {

    tweener.AddTween(player.transform, player.transform.position, new Vector3(1.859f, 1.66f, 0.0f), 1.5f);

    Debug.Log(tweener);

    }    
   
}
