using System.Threading;
using UnityEngine;
using UnityEngine.InputSystem;

public class Move : MonoBehaviour
{
    Vector2 bottoml;
    Vector2 topr;
    //use this maybe? public bool flipped = true;

    float speed = 5f;
    float duration = 1f;
    private bool leftcondition = false;
    private bool rightcondition = false;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
     duration -= Time.deltaTime;   
        //Disallow movement outside border rudementary
        Vector3 newPosition = transform.position;
        Vector2 screenPos = Camera.main.WorldToScreenPoint(transform.position);
        if (screenPos.x < 0 || screenPos.x > Screen.width)
        {
            if(duration <= 0)
            {
                speed = speed * -1;
            }
            
        }


        //input movement
        if (Keyboard.current.leftArrowKey.wasPressedThisFrame)
        {
            leftcondition = true;
        }


        if (Keyboard.current.rightArrowKey.wasPressedThisFrame)
        {
            rightcondition = true;
        }


        //transform.position += transform.right * Time.deltaTime;
        if (Keyboard.current.leftArrowKey.wasReleasedThisFrame)
        {
            Debug.Log("left release");
            leftcondition = false;
            //print("hello dead")
        }


        if (Keyboard.current.rightArrowKey.wasReleasedThisFrame)
        {
            Debug.Log("right release");
            rightcondition = false;
        }


        if (leftcondition == true)
        {
            Debug.Log("left condition");
            newPosition.x += -speed * Time.deltaTime;
        }
        if (rightcondition == true)
        {
            Debug.Log("right condition");
            newPosition.x += speed * Time.deltaTime;
        }

        transform.position = newPosition;
    }
}
