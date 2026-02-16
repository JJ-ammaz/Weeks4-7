using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    public GameObject gameOverPanel;
    public Button restartButton;
    public Slider robotSpeedSlider;
    public Slider wallSpeedSlider;

    // References to game objects
    public Move robot;

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
        robot.speed = robotSpeedSlider.value;

        // Update wall speed from slider
        WallMovement.moveSpeed = wallSpeedSlider.value;
    }

    // Show game over screen
    public void ShowGameOver()
    {
        gameOverPanel.SetActive(true);

        // Hide robot
        robot.gameObject.SetActive(false);
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

        // Reset wall
    }
}