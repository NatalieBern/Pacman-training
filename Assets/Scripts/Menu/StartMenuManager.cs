using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class StartMenuManager : MonoBehaviour
{
    public Button playButton; // �������� ���� ������ "������"

    void Start()
    {
        // ����������� ������
        playButton.onClick.AddListener(StartGame);
    }

    public void StartGame()
    {
        // ������� �� ������ ������� (����� "TestLevel")
        SceneManager.LoadScene("TestLevel");

        // ����������� ��� ��������:
        // ��� �������� �� ������� 2: SceneManager.LoadScene("Level2");
        // ��� �������� �� ������� 3: SceneManager.LoadScene("Level3");
    }
}