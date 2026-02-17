using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    //Drag each into corresponding inspectors
    public GameObject gameOverPanel;
    public Button restartButton;
    public Slider robotSpeedSlider;
    public Slider wallSpeedSlider;


    // References to game objects
    public Move robot;
    public WallSpawner spawner;
    public WallMovement wall;

    void Start()
    {
        // Make sure game over panel is hidden
        gameOverPanel.SetActive(false);

        // Connect restart button to function
        restartButton.onClick.AddListener(RestartGame);
    }

    void Update()
    {
        // Update robot speed from slider
        robot.botspeed = robotSpeedSlider.value;

        // Update wall speed from slider
        wall.wallspeed = wallSpeedSlider.value;
    }

    // Show game over screen
    public void ShowGameOver()
    {
        gameOverPanel.SetActive(true);

        

        //ADDED - Wall Spawner now turns off so it stops spawning walls when player has died
        spawner.gameObject.SetActive(false );

        // ADDED - FIx to movement after death on restart. 
        robot.rightcondition = false;
        robot.leftcondition = false;
        robot.upcondition = false;
        robot.downcondition = false;

        // Hide robot
        robot.gameObject.SetActive(false);

        //ADDED - Wall speed going super fast to get all them off screen before player restarts

        wallSpeedSlider.value = 10f;
    }

    // Restart game
    void RestartGame()
    {
        // Hide game over panel
        gameOverPanel.SetActive(false);

        // Reset robot position

        robot.transform.position = new Vector3(0f, 0f, 0f); // change to your spawn pos

        // Show robot again

        robot.gameObject.SetActive(true);

        // ADDED Toggle spawner again 

        spawner.gameObject.SetActive(true );

        // Reset wall speed

        wallSpeedSlider.value = 3f;
    }
}