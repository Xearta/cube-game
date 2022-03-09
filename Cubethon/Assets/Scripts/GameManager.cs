using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    bool gameHasEnded = false;
    public float restartDelay = 1f;
    public GameObject completeLevelUI;
    public GameObject currentLevelUI;
    public Text currentLevelText;

    public void StartLevel()
    {
        currentLevelText.text = "Level: " + SceneManager.GetActiveScene().buildIndex;
        currentLevelUI.SetActive(true);
        Debug.Log("Starting");
    }

    public void CompleteLevel()
    {
        completeLevelUI.SetActive(true);
        currentLevelUI.SetActive(false);
        
    }

    public void EndGame()
    {
        if (gameHasEnded == false)
        {
            gameHasEnded = true;
            Debug.Log("GAME OVER");
            Invoke("Restart", restartDelay);
        }        
    }

    void Restart()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
