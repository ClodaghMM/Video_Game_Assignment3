using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tween_Manager : MonoBehaviour
{
    //This script is going to be attached to the pac-man game object or takes an array value. 

    [SerializeField] private GameObject player; 
    private Tweener tweener; 
    private int i;   
    [SerializeField] private Vector3[] star_pos; 
    private bool move; 
    private string[] animatorDirections;
    private Animator animatorController; 
    private AudioSource moveSound; 

    // Start is called before the first frame update
    void Start()
    {
        tweener = gameObject.GetComponent<Tweener>();
        i = 0; 
        animatorController = player.GetComponent<Animator>();

      //  moveSound = player.GetComponent<AudioSource>();

        animatorDirections = new string [4] {
            "MoveDown", "MoveLeft", "MoveUp", "MoveRight"
        };
    }

    // Update is called once per frame
    void Update() {
    StartCoroutine(movePlayer());
        }

    IEnumerator movePlayer() {
     if (i < star_pos.Length){
            tweener.AddTween(player.transform, player.transform.position, star_pos[i], 2.0f); 
        
        }

        if (player.transform.position == star_pos[i]) {
             i = i + 1; 
             if (i == 4) {
                 i = 0; 
             }
        }
        yield return new WaitForSeconds(2);

    }   
    }

    

    




  
