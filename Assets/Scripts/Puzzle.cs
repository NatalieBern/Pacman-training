using UnityEngine;

public class Puzzle : MonoBehaviour
{
    public GameObject Piece_1;
    public GameObject Piece_2;
    public GameObject Piece_3;
    public GameObject Piece_4;
    public GameObject Piece_5;
    public GameObject Piece_6;


    public GameObject ObjPuzzle;

    public int IntLevel = 0;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        Piece_1.SetActive(false);
        Piece_2.SetActive(false);
        Piece_3.SetActive(false);
        Piece_4.SetActive(false);
        Piece_5.SetActive(false);
        Piece_6.SetActive(false);

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
                Piece_5.SetActive(true);
                break;
            case 4:
                Piece_4.SetActive(true);
                break;
            case 5:
                
                break;
            case 6:
                Piece_6.SetActive(true);
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
    public void OpenPuzzle()
    {
        ObjPuzzle.SetActive(true);
    }
}
