using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PacStudentController : MonoBehaviour
{
 
    [SerializeField] private GameObject player;
    private Vector3 nextPos;
    private Tweener tweener;
    private Animator animatorController;
    private Vector3[] movePos = new Vector3 [4] {
        new Vector3 (0.4f, 0.0f, 0.0f), new Vector3(0.0f, -0.4f, 0.0f), new Vector3(-0.4f, 0.0f, 0.0f), new Vector3(0.0f, 0.4f, 0.0f)};
    private int i;
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
        if(Input.GetKeyDown("d")) {
            i = 0;
            nextPos = player.transform.position + movePos[i];
            tweener.AddTween(player.transform, player.transform.position, nextPos, 1.0f* Time.fixedDeltaTime);
            lastInput = "d";
        }

    }

        //have a counter and then check if the timer has continued. 
        

        }
    


