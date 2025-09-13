using UnityEngine;

public class PauseButton : MonoBehaviour
{
    public GameObject pausePanel; // ������ �� ������ �����

    public void TogglePauseMenu()
    {
        if (pausePanel != null)
        {
            bool isActive = !pausePanel.activeSelf;
            pausePanel.SetActive(isActive);
            Time.timeScale = isActive ? 0f : 1f;
        }
    }
}