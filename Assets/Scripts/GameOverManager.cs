using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.XR.Interaction.Toolkit;
using Unity.XR.CoreUtils;

public class GameOverManager : MonoBehaviour
{
    public GameObject gameOverCanvas;
    public Transform playerHead;  // Reference to XR Camera (CenterEye)

    private void Start()
    {
        gameOverCanvas.SetActive(false); // Hide Game Over screen at the start

        if (playerHead == null)
        {
            playerHead = GameObject.FindObjectOfType<XROrigin>().Camera.transform;
        }
    }

    public void TriggerGameOver()
    {
        gameOverCanvas.SetActive(true); // Display Game Over screen
        Time.timeScale = 0f; // Pause the game

        // Position the Game Over Canvas in front of the player's view
        gameOverCanvas.transform.position = playerHead.position + playerHead.forward * 2f;
        gameOverCanvas.transform.LookAt(playerHead);
        gameOverCanvas.transform.Rotate(0, 180f, 0);
    }

    public void RestartGame()
    {
        Time.timeScale = 1f; // Resume game speed
        SceneManager.LoadScene(SceneManager.GetActiveScene().name); // Reload current scene
    }

    public void QuitGame()
    {
        Application.Quit(); // Quit the game
    }
}
