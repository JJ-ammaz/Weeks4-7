using System.Threading;
using UnityEngine;
using UnityEngine.InputSystem;

public class Move : MonoBehaviour
{
    Vector2 bottoml;
    Vector2 topr;
    //use this maybe? public bool flipped = true;

    public float speed = 5f;
    float duration = 1f;
    public bool leftcondition = false;
    public bool rightcondition = false;
    public bool upcondition = false;
    public bool downcondition = false;
    public WallMovement wall;
    public UIManager uiManager;
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
            uiManager.ShowGameOver();

        }
        //bleh
        if (screenPos.y < 0 || screenPos.y > Screen.height)
        {
            uiManager.ShowGameOver();

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

        if (Keyboard.current.upArrowKey.wasPressedThisFrame)
        {
            upcondition = true;
        }

        if (Keyboard.current.downArrowKey.wasPressedThisFrame)
        {
            downcondition = true;
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
            //Debug.Log("right release");
            rightcondition = false;
        }

        if (Keyboard.current.upArrowKey.wasReleasedThisFrame)
        {
            //Debug.Log("up release");
            upcondition = false;
        }
        if (Keyboard.current.downArrowKey.wasReleasedThisFrame)
        {
            //Debug.Log("down release");
            downcondition = false;
        }


        if (leftcondition == true)
        {
            //Debug.Log("left condition");
            newPosition.x += -speed * Time.deltaTime;
        }
        if (rightcondition == true)
        {
            //Debug.Log("right condition");
            newPosition.x += speed * Time.deltaTime;
        }
        if (upcondition == true)
        {
            //Debug.Log("up condition");
            newPosition.y += speed * Time.deltaTime;
        }
        if (downcondition == true)
        {
            //Debug.Log("down condition");
            newPosition.y += -speed * Time.deltaTime;
        }

        transform.position = newPosition;
        //Put into inspector (Drag the wall into the side thingy)
        // Check collision with the wall (hopefully ;w;)
        // Check collision with walls
        GameObject[] walls = GameObject.FindGameObjectsWithTag("Wall");
        for (int i = 0; i < walls.Length; i++)
        {
            if (walls[i].transform.position.x < transform.position.x + 1f &&
                walls[i].transform.position.x > transform.position.x - 1f)
            {
                float gapSize = 3f;
                float gapTop = walls[i].transform.position.y + (gapSize / 2f);
                float gapBottom = walls[i].transform.position.y - (gapSize / 2f);

                if (transform.position.y > gapTop || transform.position.y < gapBottom)
                {
                    uiManager.ShowGameOver();
                }
            }
        }
    }
}
