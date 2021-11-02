using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PacStudentController : MonoBehaviour
{
 
    [SerializeField] private GameObject player;
    private Vector3 nextPos;
    private Tweener tweener;
    private string playerInput;
    private string currentInput;
    private float speed;
    private bool isWall;
    private Vector2 position;
    private float timer;
    private int move_time = 1;
    private AudioSource move_sound; 
    private Animator animatorController;
    private Vector3[] movePos = new Vector3 [5] {
        new Vector3 (0.2f, 0.0f, 0.0f), new Vector3(0.0f, -0.2f, 0.0f), new Vector3(-0.2f, 0.0f, 0.0f), new Vector3(0.0f, 0.2f, 0.0f), new Vector3(0.0f, 0.0f, 0.0f)};
    private string lastInput;


    // Start is called before the first frame update
    void Start()
    {
        tweener = gameObject.GetComponent<Tweener>();
        animatorController = gameObject.GetComponent<Animator>();
        move_sound = gameObject.GetComponent<AudioSource>();
        characterDirection("d");
    }

    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;   
        if((int)timer == move_time) 
        {
            move_sound.Play();
            move_time += 1;
        }
    
        if(Input.GetKeyDown("d")) {
            playerInput = "d";
            checkWalkable(playerInput);
            characterDirection(playerInput);
            characterMovement(0);
            lastInput = playerInput;
            playerInput = ""; 
            }

        if(Input.GetKeyDown("s")) {
            playerInput = "s";
            checkWalkable(playerInput);
            characterDirection(playerInput);
            characterMovement(1);
            lastInput = playerInput;
            playerInput = "";
        }

        if(Input.GetKeyDown("a")) {
            playerInput = "a";
            checkWalkable(playerInput);
            characterDirection(playerInput);
            characterMovement(2);
            lastInput = playerInput;
            playerInput = "";
        }

        if(Input.GetKeyDown("w")) {
            playerInput = "w";
            checkWalkable(playerInput);
            characterDirection(playerInput);
            characterMovement(3);
            lastInput = playerInput;
            playerInput = "";
        }

        if(Vector3.Distance(player.transform.position,nextPos) < 0.3 && playerInput == "")
        {   
            if(lastInput == "d")
            {
                checkWalkable(lastInput);
                currentInput = lastInput;
                characterMovement(0);
                } 
        
            if(lastInput == "s")
            {
                checkWalkable(lastInput);
                currentInput = lastInput;
                characterMovement(1);
            }

            if(lastInput == "a")
            {
                checkWalkable(lastInput);
                currentInput = lastInput;
                characterMovement(2);
               
            }

            if(lastInput == "w")
            {
                checkWalkable(lastInput);
                currentInput = lastInput;
                characterMovement(3);
            }
        }
    }

    void characterMovement(int i) {
        
        if(i != 4) {
        nextPos = player.transform.position + movePos[i];
        speed = Mathf.Clamp(0.5f * Time.fixedDeltaTime, 0.3f, 2.0f);
        tweener.AddTween(player.transform, player.transform.position, nextPos, speed);
        position = new Vector2(transform.position.x, transform.position.y);
        }
        else if(i == 4)
        {
            nextPos = player.transform.position + movePos[i];
            tweener.AddTween(player.transform, player.transform.position, nextPos, speed);
        }
    }

   void checkWalkable(string currentInput) {

       if(currentInput == "d")
       {
    RaycastHit2D wallright = Physics2D.Raycast(position,Vector2.right, 0.3f);

        if(wallright.collider != null) 
        {
            characterMovement(4);
        }
    }
        if(currentInput == "s")
       {
    RaycastHit2D wallright = Physics2D.Raycast(position,Vector2.down, 0.3f);

        if(wallright.collider != null) 
        {
            characterMovement(4);
        }
    }

        if(lastInput == "a")
        {
            RaycastHit2D wallright = Physics2D.Raycast(position,Vector2.left, 0.35f);

        if(wallright.collider != null) 
        {
            characterMovement(4);
        }
        }

        if(lastInput == "w")
        {
            RaycastHit2D wallright = Physics2D.Raycast(position,Vector2.up, 0.3f);

        if(wallright.collider != null) 
        {
            characterMovement(4);
        }
        }
   }

    void characterDirection(string playerInput) {
        if(playerInput == "s")
        {
            animatorController.SetBool("down", false);
            animatorController.SetBool("right", true);
            animatorController.SetBool("left", true);
            animatorController.SetBool("up", true);
        }

        if(playerInput == "d")
        {
        animatorController.SetBool("right", false);
         animatorController.SetBool("down", true);
         animatorController.SetBool("left", true);
         animatorController.SetBool("up", true);
        }

        if(playerInput == "a")
        {
            animatorController.SetBool("left", false);
            animatorController.SetBool("down", true);
            animatorController.SetBool("right", true);
            animatorController.SetBool("up", true);
        }

        if(playerInput == "w")
        {
            animatorController.SetBool("up", false);
            animatorController.SetBool("left", true);
            animatorController.SetBool("down", true);
            animatorController.SetBool("right", true);
        }
    }
}



    
    


