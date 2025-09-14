using UnityEngine;
using UnityEngine.SceneManagement;

public class Puzzle : MonoBehaviour
{
    public GameObject Piece_1;
    public GameObject Piece_2;
    public GameObject Piece_3;
    public GameObject Piece_4;
    public GameObject Piece_5;
    public GameObject Piece_6;
    public GameObject Piece_7;
    public GameObject Piece_8;
    public GameObject Piece_9;

    public GameObject ButtonNextLevel;

    public GameObject ObjPuzzle;

    static int IntLevel;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        Piece_1.SetActive(false);
        Piece_2.SetActive(false);
        Piece_3.SetActive(false);
        Piece_4.SetActive(false);
        Piece_5.SetActive(false);
        Piece_6.SetActive(false);
        Piece_7.SetActive(false);
        Piece_8.SetActive(false);
        Piece_9.SetActive(false);

        ButtonNextLevel.SetActive(false);

       
        ObjPuzzle.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        switch (IntLevel)
        {
            case 1:
                Piece_1.SetActive(true);
                break;
            case 2:
                Piece_2.SetActive(true);
                break;
            case 3:
                Piece_3.SetActive(true);
                break;
            case 4:
                Piece_4.SetActive(true);
                break;
            case 5:
                Piece_5.SetActive(true);
                break;
            case 6:
                Piece_6.SetActive(true);
                break;
            case 7:
                Piece_7.SetActive(true);
                break;
            case 8:
                Piece_8.SetActive(true);
                break;
            case 9:
                Piece_9.SetActive(true);
                break;
        }

    }

    public void AddIntLevel()
    {
        IntLevel++;
    }
    public void ClosePuzzle()
    {
        ObjPuzzle.SetActive(false);
    }
    public void StartOpenPuzzle()
    {
        Invoke("OpenPuzzle", 1f);
        Invoke("AddIntLevel", 2f);
        Invoke("SpawnButton", 2.5f);
    }
    void SpawnButton()
    {
        ButtonNextLevel.SetActive(true);
    }
    void OpenPuzzle()
    {
        ObjPuzzle.SetActive(true);
    }
    public void StartLevel2()
    {
        Debug.Log("переход уровня");
        SceneManager.LoadScene("Level2");
    }
    public void StartLevel3()
    {
        Debug.Log("переход уровня");
        SceneManager.LoadScene("Level3");
    }
}
