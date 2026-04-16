using UnityEngine;

public class GameOverManager : MonoBehaviour
{
    [SerializeField] private GameObject youLosePanel;

    public void ShowGameOver()
    {
        youLosePanel.SetActive(true);
        Time.timeScale = 0f;
    }

    public void QuitGame()
    {
        Application.Quit();
        Debug.Log("Game closed");
    }
}