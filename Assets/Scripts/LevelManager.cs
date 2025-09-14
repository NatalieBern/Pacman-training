using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelManager : MonoBehaviour
{
    //1 - розовая точка
    //2 - желтая точка
    //3 - зеленая точка
    //4 - голубая точка
    protected int[] OrderLevel;      // последовательность правильных точек
    protected int[] OrderPlayer;    // последовательность созданная игроком

    public AudioSource RightSoundSour;
    public AudioSource MistakeSoundSour;

    protected int Number;

    public Puzzle puzzle;

    protected virtual void Start()
    {
        Number = 1;
        OrderPlayer = new int[OrderLevel.Length]; // создаём массив уровня
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        int value = 0;

        switch (collision.gameObject.tag)
        {
            case "PinkPoint":   value = 1; Debug.Log("Розовая точка"); break;
            case "YellowPoint": value = 2; Debug.Log("Желтая точка"); break;
            case "GreenPoint":  value = 3; Debug.Log("Зеленая точка"); break;
            case "BluePoint":   value = 4; Debug.Log("Голубая точка"); break;

        }

        if (value != 0)
        {
            OrderPlayer[Number - 1] = value;

            if (OrderPlayer[Number - 1] == OrderLevel[Number - 1])
            {
                Debug.Log("Правильная точка");
                RightSoundSour.Play();

                Point p = collision.gameObject.GetComponent<Point>();
                if (p != null)
                {
                    p.StartAnimRight();

                }
  
            }
            else
            {
                MistakeSoundSour.Play();
                Debug.Log("Неправильная точка");

                Point p = collision.gameObject.GetComponent<Point>();
                if (p != null)
                {
                    p.StartAnimLose();

                }
                Invoke("Lose", 1.5f);
                return;
            }

            if (Number == OrderLevel.Length)
            {
                if (CheckWin())
                    Win();
            }

            Number++;
        }
    }

    protected bool CheckWin()
    {
        for (int i = 0; i < OrderLevel.Length; i++)
        {
            if (OrderPlayer[i] != OrderLevel[i])
                return false;
        }
        return true;
    }

    protected virtual void Win()
    {
        Debug.Log("Победа");
        if (puzzle != null)
        {
            puzzle.StartOpenPuzzle();
            Debug.Log("Функция найдена и вызвана");
        }
    }

    protected virtual void Lose()
    {
        
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        Debug.Log("Проигрыш");
    }
}