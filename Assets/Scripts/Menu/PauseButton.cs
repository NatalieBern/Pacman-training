using UnityEngine;

public class PauseButton : MonoBehaviour
{
    public GameObject pausePanel; // ���� �������� ������ �����

    public void TogglePause()
    {
        if (pausePanel != null)
        {
            bool isPaused = !pausePanel.activeSelf;
            pausePanel.SetActive(isPaused);
            Time.timeScale = isPaused ? 0f : 1f;
        }
    }
}