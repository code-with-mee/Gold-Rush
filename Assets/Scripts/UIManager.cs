using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    private static int GoldCount = 0;

    [SerializeField] private Text goldCountLabel = null;
    [SerializeField] private Text labelWinLose;
    [SerializeField] private GameObject winloseScreen;


    public void ShowWinningScreen()
    {
        labelWinLose.text = "LEVEL COMPLETED.";
        winloseScreen.SetActive(true);
    }

    public void RestartGame()
    {
        SceneManager.LoadScene("DemoAIAgent");
    }

    public void BackToMenu()
    {
        SceneManager.LoadScene("Menu");
    }

    public void RefreshGoldHitCount()
    {
        GoldCount += 1;
        goldCountLabel.text = "GOLD : " + GoldCount;
    }


}
