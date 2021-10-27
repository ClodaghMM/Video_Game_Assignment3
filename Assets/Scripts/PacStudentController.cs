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
    private Animator animatorController;
    private Vector3[] movePos = new Vector3 [4] {
        new Vector3 (0.23f, 0.0f, 0.0f), new Vector3(0.0f, -0.23f, 0.0f), new Vector3(-0.23f, 0.0f, 0.0f), new Vector3(0.0f, 0.23f, 0.0f)};
    private string[] animatorDirections = new string [4] {
            "MoveDown", "MoveLeft", "MoveUp", "MoveRight"
        };
    private GameObject wallnames;
    private string lastInput;
    // Start is called before the first frame update
    void Start()
    {
        tweener = gameObject.GetComponent<Tweener>();
        animatorController = gameObject.GetComponent<Animator>();
     //   wallnames = GameObject.Find("/UpperLef WallsandCorners/T Section");
    }

    // Update is called once per frame
    void Update()
    {
        //Debug.Log(wallnames.name);
        
        if(Input.GetKeyDown("d")) {
            playerInput = "d";
            characterMovement(0);
            lastInput = playerInput;
            playerInput = ""; 
            }

        if(Input.GetKeyDown("s")) {
            playerInput = "s";
            characterMovement(1);
            lastInput = playerInput;
            playerInput = "";
        }

        if(Input.GetKeyDown("a")) {
            playerInput = "a";
            characterMovement(2);
            lastInput = playerInput;
            playerInput = "";
        }

        if(Input.GetKeyDown("w")) {
            playerInput = "w";
            characterMovement(3);
            lastInput = playerInput;
            playerInput = "";
        }


        if(Vector3.Distance(player.transform.position,nextPos) < 0.3 && playerInput == "")
        {   
            if(lastInput == "d")
            {
                currentInput = lastInput;
                characterMovement(0);} 
        
            if(lastInput == "s")
            {
                currentInput = lastInput;
                characterMovement(1);
            }

            if(lastInput == "a")
            {
                currentInput = lastInput;
                characterMovement(2);
            }

            if(lastInput == "w")
            {
                currentInput = lastInput;
                characterMovement(3);
            }
    checkWalkable();
        //method to check if it is walkable 
           
        }
    }

    void characterMovement(int i) {
        nextPos = player.transform.position + movePos[i];
        speed = Mathf.Clamp(0.5f * Time.fixedDeltaTime, 0.3f, 2.0f);
        tweener.AddTween(player.transform, player.transform.position, nextPos, speed);}
    
   

    

   bool checkWalkable() {
    RaycastHit wallInfo;
        bool isWall = Physics.Raycast(transform.position,Vector3.right, out wallInfo, 2.0f);
         return true; 
    }
}



    
    


