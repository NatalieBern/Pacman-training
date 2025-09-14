using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class StartMenuManager : MonoBehaviour
{
    public Button playButton; // Перетащи сюда кнопку "Играть"

    void Start()
    {
        // Настраиваем кнопку
        playButton.onClick.AddListener(StartGame);
    }

    public void StartGame()
    {
        // Переход на ПЕРВЫЙ УРОВЕНЬ (сцена "TestLevel")
        SceneManager.LoadScene("TestLevel");

        // КОММЕНТАРИЙ ДЛЯ БУДУЩЕГО:
        // Для перехода на уровень 2: SceneManager.LoadScene("Level2");
        // Для перехода на уровень 3: SceneManager.LoadScene("Level3");
    }
}