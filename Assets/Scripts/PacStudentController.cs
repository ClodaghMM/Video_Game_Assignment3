using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PacStudentController : MonoBehaviour
{
 
    [SerializeField] private GameObject player;
    private Vector3 nextPos;
    private Tweener tweener;
    private string playerInput;
    private int counter = 0; 
    private string currentInput;
    private Animator animatorController;
    private Vector3[] movePos = new Vector3 [4] {
        new Vector3 (0.4f, 0.0f, 0.0f), new Vector3(0.0f, -0.4f, 0.0f), new Vector3(-0.4f, 0.0f, 0.0f), new Vector3(0.0f, 0.4f, 0.0f)};
    private string[] animatorDirections = new string [4] {
            "MoveDown", "MoveLeft", "MoveUp", "MoveRight"
        };
    private string lastInput;
    // Start is called before the first frame update
    void Start()
    {
        tweener = gameObject.GetComponent<Tweener>();
        animatorController = gameObject.GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        //want to move from one grid position to another. 0.4
        //start coroutine to check for input
        if(Input.GetKeyDown("d")) {
            playerInput = "d";
            characterMovement(0);
            lastInput = playerInput;
            playerInput = ""; 
            }

        if(Input.GetKeyDown("s")) {
            playerInput = "s";
            characterMovement(1);
            lastInput = "s";
            lastInput = playerInput;
            playerInput = "";
        }

        if(Vector3.Distance(player.transform.position,nextPos) < 0.4 && playerInput == "")
        {   
            if(lastInput == "d")
            {
                currentInput = lastInput;
                characterMovement(0);} 
            }
        }
        
        //method to check that a key was pressed. 


    void characterMovement(int i) {
        nextPos = player.transform.position + movePos[i];
        tweener.AddTween(player.transform, player.transform.position, nextPos, 3.5f* Time.deltaTime);}

        //check if player input was entered here.
    }

    
    


