using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class MenuManager : MonoBehaviour
{
    [Header("Панели меню")]
    public GameObject mainMenuPanel;
    public GameObject pausePanel;
    public GameObject settingsPanel;

    [Header("Настройки звука")]
    public Slider volumeSlider;
    public float minVolume = 0.1f; // Минимальная громкость

    private void Start()
    {
        // Показываем только главное меню
        mainMenuPanel.SetActive(true);
        pausePanel.SetActive(false);
        settingsPanel.SetActive(false);

        // Настраиваем слайдер громкости
        if (volumeSlider != null)
        {
            volumeSlider.minValue = minVolume;
            volumeSlider.maxValue = 1f;
            volumeSlider.value = AudioListener.volume;
            volumeSlider.onValueChanged.AddListener(SetVolume);
        }
    }

    // ==================== ГЛАВНОЕ МЕНЮ ====================
    public void StartGame()
    {
        Debug.Log("Игра начинается!");
        // Здесь переход на игровую сцену
        SceneManager.LoadScene("TestLevel");
    }

    public void OpenSettingsFromMain()
    {
        ShowPanel(settingsPanel);
    }

    public void ExitGame()
    {
        Application.Quit();
#if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
#endif
    }

    public void ExitToMainMenu()
    {
        Time.timeScale = 1f;
        // Просто скрываем паузу и показываем главное меню
        pausePanel.SetActive(false);
        mainMenuPanel.SetActive(true);
    }

    // ==================== МЕНЮ ПАУЗЫ ====================
    public void OpenPauseMenu()
    {
        // Эта функция вызывается из игровой сцены кнопкой "бургер"
        ShowPanel(pausePanel);
        Time.timeScale = 0f; // Останавливаем время
    }

    public void ResumeGame()
    {
        // Скрываем все панели
        mainMenuPanel.SetActive(false);
        pausePanel.SetActive(false);
        settingsPanel.SetActive(false);

        Time.timeScale = 1f;
    }

    public void OpenSettingsFromPause()
    {
        ShowPanel(settingsPanel);
    }

    public void GoToMainMenu()
    {
        Time.timeScale = 1f;
        // Возврат в главное меню
        SceneManager.LoadScene("Menu");
    }

    // ==================== НАСТРОЙКИ ====================
    public void SetVolume(float volume)
    {
        // Убеждаемся, что звук не выключается полностью
        AudioListener.volume = Mathf.Max(volume, minVolume);
    }

    public void BackFromSettings()
    {
        // Определяем, откуда пришли в настройки
        if (pausePanel.activeSelf)
        {
            ShowPanel(pausePanel);
        }
        else
        {
            ShowPanel(mainMenuPanel);
        }
    }

    // ==================== ДЛЯ ИГРОВОЙ СЦЕНЫ ====================
    public void TogglePauseFromGame()
    {
        // Проверяем, есть ли панель паузы на этой сцене
        if (pausePanel != null)
        {
            bool isPaused = !pausePanel.activeSelf;
            pausePanel.SetActive(isPaused);
            Time.timeScale = isPaused ? 0f : 1f;
        }
        else
        {
            Debug.Log("Панель паузы не найдена на этой сцене");
        }
    }

    // ==================== ПРОВЕРКА НАЛИЧИЯ ПАНЕЛЕЙ ====================
    private bool HasSettingsPanel()
    {
        return settingsPanel != null;
    }

    public void OpenSettingsFromGame()
    {
        if (HasSettingsPanel())
        {
            OpenSettingsFromMain(); // Используем существующий метод
        }
        else
        {
            Debug.Log("Панель настроек не доступна в игровой сцене");
            // Можно показать сообщение игроку
        }
    }

    // ==================== ВСПОМОГАТЕЛЬНЫЕ МЕТОДЫ ====================
    private void ShowPanel(GameObject panel)
    {
        // Скрываем все панели
        mainMenuPanel.SetActive(false);
        pausePanel.SetActive(false);
        settingsPanel.SetActive(false);

        // Показываем нужную панель
        panel.SetActive(true);
    }

    private void HideAllPanels()
    {
        mainMenuPanel.SetActive(false);
        pausePanel.SetActive(false);
        settingsPanel.SetActive(false);
    }

    // Для тестирования в редакторе
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            // Если в настройках - возврат назад
            if (settingsPanel.activeSelf)
            {
                BackFromSettings();
            }
            // Если в паузе - продолжить игру
            else if (pausePanel.activeSelf)
            {
                ResumeGame();
            }
        }
    }
}