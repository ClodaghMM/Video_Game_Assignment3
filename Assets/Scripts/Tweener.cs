using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tweener : MonoBehaviour
{
    private Tween activeTween; 
    private float timeFraction;
    private string direction;
    private int move_count = 0; 
    // Start is called before the first frame update
    void Start()
    {
        direction = "right";
    }

    // Update is called once per frame
    void Update()
    { 
    
        if (activeTween != null) { 
    
         if(Vector3.Distance(activeTween.Target.position, activeTween.EndPos) > 0.1f) {
         timeFraction = (Time.time - activeTween.StartTime) / activeTween.Duration; 
         activeTween.Target.position = Vector3.Lerp(activeTween.StartPos, activeTween.EndPos, timeFraction);
         }

       else {
         activeTween.Target.position = activeTween.EndPos;
            activeTween = null; 
          }
        } 

        moveCount();
    }

    public int moveCount() {
        move_count = move_count+ 1; 
        return move_count;
    }




    public void AddTween(Transform targetObject, Vector3 startPos, Vector3 endPos, float duration) {

        if(activeTween == null) {
            activeTween = new Tween(targetObject, startPos, endPos, Time.time, duration);
        }
}

    

}
