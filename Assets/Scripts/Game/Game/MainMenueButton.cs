using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenueButton : MonoBehaviour
{
    public void MainMenueButtonOnClick()
    {
        SceneManager.LoadScene(0);
    }
}
