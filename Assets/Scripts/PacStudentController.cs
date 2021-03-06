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
    private Vector2 position;
    private RaycastHit2D wallright;
    private float timer;
    private int move_time = 1;
    private AudioSource move_sound; 
    private Animator animatorController;
    private bool pauseSound= true;
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
        pauseSound = false;

        if((int)timer == move_time) 
      {
        move_sound.Play();
        move_time +=1;
      }
        
        position = new Vector2(transform.position.x, transform.position.y);
        }
        else if(i == 4)
        {

            speed = 0;

            nextPos = player.transform.position + movePos[i];
            tweener.AddTween(player.transform, player.transform.position, nextPos, speed);
           if(pauseSound == false)
           {
               move_sound.Pause();
                pauseSound = true;
            }
           
        }
    }

   void checkWalkable(string currentInput) {

       if(currentInput == "d")
       {
        wallright = Physics2D.Raycast(position,Vector2.right, 0.3f);

        if(wallright.collider != null) 
        {
       
            characterMovement(4);
        }
    }
        if(currentInput == "s")
       {
        wallright = Physics2D.Raycast(position,Vector2.down, 0.3f);

        if(wallright.collider != null) 
        {
            characterMovement(4);
        }
    }

        if(lastInput == "a")
        {
            wallright = Physics2D.Raycast(position,Vector2.left, 0.3f);

        if(wallright.collider != null) 
        {
    
            characterMovement(4);
        }
        }

        if(lastInput == "w")
        {
            wallright = Physics2D.Raycast(position,Vector2.up, 0.3f);

        if(wallright.collider != null) 
        {
            characterMovement(4);
        }
        }
   }

    void characterDirection(string playerInput) {
        if(playerInput == "s")
        {
            animatorController.SetTrigger("down 0");
            animatorController.ResetTrigger("left 0");
            animatorController.ResetTrigger("right 0");
            animatorController.ResetTrigger("up 0");
            
        }

        if(playerInput == "d")
        {
            animatorController.SetTrigger("right 0");
            animatorController.ResetTrigger("left 0");
            animatorController.ResetTrigger("down 0");
            animatorController.ResetTrigger("up 0");
        }

        if(playerInput == "a")
        {
            animatorController.SetTrigger("left 0");
            animatorController.ResetTrigger("right 0");
            animatorController.ResetTrigger("down 0");
            animatorController.ResetTrigger("up 0");
            
        }

        if(playerInput == "w")
        {
            animatorController.SetTrigger("up 0");
            animatorController.ResetTrigger("right 0");
            animatorController.ResetTrigger("down 0");
            animatorController.ResetTrigger("left 0");
           

        }
    }
}



    
    


