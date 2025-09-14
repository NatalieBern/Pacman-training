using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class MenuManager : MonoBehaviour
{
    [Header("������ ����")]
    public GameObject mainMenuPanel;
    public GameObject pausePanel;
    public GameObject settingsPanel;

    [Header("��������� �����")]
    public Slider volumeSlider;
    public float minVolume = 0.1f; // ����������� ���������

    private void Start()
    {
        // ���������� ������ ������� ����
        mainMenuPanel.SetActive(true);
        pausePanel.SetActive(false);
        settingsPanel.SetActive(false);

        // ����������� ������� ���������
        if (volumeSlider != null)
        {
            volumeSlider.minValue = minVolume;
            volumeSlider.maxValue = 1f;
            volumeSlider.value = AudioListener.volume;
            volumeSlider.onValueChanged.AddListener(SetVolume);
        }
    }

    // ==================== ������� ���� ====================
    public void StartGame()
    {
        Debug.Log("���� ����������!");
        // ����� ������� �� ������� �����
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
        // ������ �������� ����� � ���������� ������� ����
        pausePanel.SetActive(false);
        mainMenuPanel.SetActive(true);
    }

    // ==================== ���� ����� ====================
    public void OpenPauseMenu()
    {
        // ��� ������� ���������� �� ������� ����� ������� "������"
        ShowPanel(pausePanel);
        Time.timeScale = 0f; // ������������� �����
    }

    public void ResumeGame()
    {
        // �������� ��� ������
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
        // ������� � ������� ����
        SceneManager.LoadScene("Menu");
    }

    // ==================== ��������� ====================
    public void SetVolume(float volume)
    {
        // ����������, ��� ���� �� ����������� ���������
        AudioListener.volume = Mathf.Max(volume, minVolume);
    }

    public void BackFromSettings()
    {
        // ����������, ������ ������ � ���������
        if (pausePanel.activeSelf)
        {
            ShowPanel(pausePanel);
        }
        else
        {
            ShowPanel(mainMenuPanel);
        }
    }

    // ==================== ��� ������� ����� ====================
    public void TogglePauseFromGame()
    {
        // ���������, ���� �� ������ ����� �� ���� �����
        if (pausePanel != null)
        {
            bool isPaused = !pausePanel.activeSelf;
            pausePanel.SetActive(isPaused);
            Time.timeScale = isPaused ? 0f : 1f;
        }
        else
        {
            Debug.Log("������ ����� �� ������� �� ���� �����");
        }
    }

    // ==================== �������� ������� ������� ====================
    private bool HasSettingsPanel()
    {
        return settingsPanel != null;
    }

    public void OpenSettingsFromGame()
    {
        if (HasSettingsPanel())
        {
            OpenSettingsFromMain(); // ���������� ������������ �����
        }
        else
        {
            Debug.Log("������ �������� �� �������� � ������� �����");
            // ����� �������� ��������� ������
        }
    }

    // ==================== ��������������� ������ ====================
    private void ShowPanel(GameObject panel)
    {
        // �������� ��� ������
        mainMenuPanel.SetActive(false);
        pausePanel.SetActive(false);
        settingsPanel.SetActive(false);

        // ���������� ������ ������
        panel.SetActive(true);
    }

    private void HideAllPanels()
    {
        mainMenuPanel.SetActive(false);
        pausePanel.SetActive(false);
        settingsPanel.SetActive(false);
    }

    // ��� ������������ � ���������
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            // ���� � ���������� - ������� �����
            if (settingsPanel.activeSelf)
            {
                BackFromSettings();
            }
            // ���� � ����� - ���������� ����
            else if (pausePanel.activeSelf)
            {
                ResumeGame();
            }
        }
    }
}