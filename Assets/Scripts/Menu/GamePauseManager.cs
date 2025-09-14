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
        // ��� ������ ���������� ������ ����, � �� ����
        mainMenuPanel.SetActive(false);  // �������� ����
        backButtonPanel.SetActive(true); // ���������� ���� � ������� "�����"
        pausePanel.SetActive(false);     // �������� �����
        Time.timeScale = 0f;
    }

    // ������ "������" - �������� ����, ���������� ����
    public void StartGame()
    {
        mainMenuPanel.SetActive(false);
        backButtonPanel.SetActive(true);
        Time.timeScale = 1f;
    }

    // ������ "�����" - ���������� �����
    public void OpenPause()
    {
        backButtonPanel.SetActive(false);
        pausePanel.SetActive(true);
        Time.timeScale = 0f;
    }

    // ������ "����������" - ������� � ����
    public void ResumeGame()
    {
        pausePanel.SetActive(false);
        backButtonPanel.SetActive(true);
        Time.timeScale = 1f;
    }

    // ������ "�����" - ����� � ������� ����
    public void ExitToMenu()
    {
        pausePanel.SetActive(false);
        mainMenuPanel.SetActive(true);
        Time.timeScale = 1f;
    }

    // ������ "����� �� ����" (���� �����)
    public void ExitGame()
    {
        Application.Quit();
    }
}