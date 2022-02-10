using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public float restartDelay = 1f;

    public GameObject completeLevelUI;
    
    public void CompleteLevel ()
    {
        completeLevelUI.SetActive(true);
    }
    
    public void EndGame()
    {
        Debug.Log("GAME OVER");
        Invoke("Restart", restartDelay);
    }

    void Restart()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
