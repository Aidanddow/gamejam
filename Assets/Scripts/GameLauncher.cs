using UnityEngine;
using UnityEngine.SceneManagement;

public class GameLauncher : MonoBehaviour
{
    public void LaunchGame()
    {
        SceneManager.LoadScene("Minigame", LoadSceneMode.Single);
    }
}
