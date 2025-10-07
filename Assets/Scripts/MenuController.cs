using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuController : MonoBehaviour
{
    [SerializeField] private GameObject titleScreen;
    [SerializeField] private GameObject levelScreen;

    public void ShowTitle()
    {
        titleScreen.SetActive(true);
        levelScreen.SetActive(false);
    }

    public void ShowLevel()
    {
        levelScreen.SetActive(true);
        titleScreen.SetActive(false);
    }

    public void LoadSceneLevel()
    {
        SceneManager.LoadScene("DemoAIAgent");
    }

}
