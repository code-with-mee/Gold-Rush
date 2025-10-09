using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuController : MonoBehaviour
{
    [SerializeField] private GameObject titleScreen;
    [SerializeField] private GameObject levelScreen;

    private void OnEnable()
    {
        Time.timeScale = 1;
        //GameObject newGold = Instantiate(gameObject);
        ///newGold.transform.position = new Vector3(10, 1, 10);
        
    }

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
