using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tween_Manager : MonoBehaviour
{
    //This script is going to be attached to the pac-man game object or takes an array value. 

    [SerializeField] private GameObject player; 
    private Tweener tweener; 
    private int i;   
    private Vector3[] star_pos; 
    private bool move; 
    private string[] animatorDirections;
    private Animator animatorController; 
    private AudioSource moveSound;
    [SerializeField] private AudioSource[] playerSounds;
    private float timer; 
    private float j = 1.0f; 

    // Start is called before the first frame update
    void Start()
    {
        tweener = gameObject.GetComponent<Tweener>(); 
        animatorController = player.GetComponent<Animator>();

        animatorDirections = new string [4] {
            "MoveDown", "MoveLeft", "MoveUp", "MoveRight"
        };
        star_pos = new Vector3 [4] {
            new Vector3(-0.05f,2.7672f, 0.0f), new Vector3(0.05f, 1.7f, 0.0f), new Vector3(-3.984f, 1.577262f, 0.0f), new Vector3(-3.894f, 2.787262f, 0.0f)};

               i = 0;
        }
    
    // Update is called once per frame
    void Update() {
        timer += Time.deltaTime; 
        if((int)timer == j){
            playerSounds[0].Play();
            j +=1; }
     if (i < star_pos.Length){
            tweener.AddTween(player.transform, player.transform.position, star_pos[i], 2.0f); 
        }

        if (player.transform.position == star_pos[i]) {
            animatorController.SetTrigger(animatorDirections[i]);
             i = i + 1; 
             if (i == 4) {
                  i = 0;
             }
        }
      }  
            
            }
    

    

    




  
