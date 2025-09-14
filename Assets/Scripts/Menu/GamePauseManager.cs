using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GamePauseManager : MonoBehaviour
{
    public GameObject mainMenuPanel;
    public GameObject backButtonPanel;
    public GameObject pausePanel;

    void Start()
    {
        // ПРИ СТАРТЕ ПОКАЗЫВАЕМ ТОЛЬКО ИГРУ, А НЕ МЕНЮ
        mainMenuPanel.SetActive(false);  // Скрываем меню
        backButtonPanel.SetActive(true); // Показываем игру с кнопкой "Назад"
        pausePanel.SetActive(false);     // Скрываем паузу
        Time.timeScale = 0f;
    }

    // КНОПКА "ИГРАТЬ" - скрывает меню, показывает игру
    public void StartGame()
    {
        mainMenuPanel.SetActive(false);
        backButtonPanel.SetActive(true);
        Time.timeScale = 1f;
    }

    // КНОПКА "НАЗАД" - показывает паузу
    public void OpenPause()
    {
        backButtonPanel.SetActive(false);
        pausePanel.SetActive(true);
        Time.timeScale = 0f;
    }

    // КНОПКА "ПРОДОЛЖИТЬ" - возврат в игру
    public void ResumeGame()
    {
        pausePanel.SetActive(false);
        backButtonPanel.SetActive(true);
        Time.timeScale = 1f;
    }

    // КНОПКА "ВЫХОД" - выход в главное меню
    public void ExitToMenu()
    {
        pausePanel.SetActive(false);
        mainMenuPanel.SetActive(true);
        Time.timeScale = 1f;
    }

    // КНОПКА "ВЫХОД ИЗ ИГРЫ" (если нужна)
    public void ExitGame()
    {
        Application.Quit();
    }
}