using UnityEngine;

public class LevelManager : MonoBehaviour
{
    protected int[] OrderLevel;      // последовательность правильных точек
    protected int[] OrderPlayer;    // выбор игрока

    public AudioSource RightSoundSour;
    public AudioSource MistakeSoundSour;

    protected int Number;

    protected virtual void Start()
    {
        Number = 1;
        OrderPlayer = new int[OrderLevel.Length]; // создаём массив под уровень
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
            }
            else
            {
                Debug.Log("Неправильная точка");
                Lose();
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
    }

    protected virtual void Lose()
    {
        MistakeSoundSour.Play();
        Debug.Log("Проигрыш");
    }
}