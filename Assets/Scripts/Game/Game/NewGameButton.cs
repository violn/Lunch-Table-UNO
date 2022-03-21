using UnityEngine;
using UnityEngine.SceneManagement;

public class NewGameButton : MonoBehaviour
{
    public void NewGameButtonOnClick()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}
