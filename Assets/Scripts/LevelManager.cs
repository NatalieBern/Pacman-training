using UnityEngine;

public class LevelManager : MonoBehaviour
{
    //1 - розовый
    //2 - желтый
    //3 - зеленый
    //4 - голубой

    int[] LevelTest = { 1, 4, 3 };
    int[] OrderPlayer = { 0, 0, 0 };

    public AudioSource RightSoundSour;
    public AudioSource MistakeSoundSour;

    private int Number;
    void Start()
    {
        Number = 1;
    }

    // Update is called once per frame
    void Update()
    {
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        switch (collision.gameObject.tag)
        {
            case "PinkPoint":
                OrderPlayer[Number - 1] = 1;
                Debug.Log("Розовая точка");
                if (OrderPlayer[Number - 1] == LevelTest[Number - 1])
                {
                    Debug.Log("Правильная точка");
                    RightSoundSour.Play();

                }
                else
                {
                    Debug.Log("Неправильная точка");
                    Lose();
                }
                break;

            case "YellowPoint":
                OrderPlayer[Number - 1] = 2;
                Debug.Log("Желтая точка");
                if (OrderPlayer[Number - 1] == LevelTest[Number - 1])
                {
                    Debug.Log("Правильная точка");
                    RightSoundSour.Play();
                }
                else
                {
                    Debug.Log("Неправильная точка");
                    Lose();
                }
                break;

            case "GreenPoint":
                OrderPlayer[Number - 1] = 3;
                Debug.Log("Зеленая точка");
                if (OrderPlayer[Number - 1] == LevelTest[Number - 1])
                {
                    Debug.Log("Правильная точка");
                    RightSoundSour.Play();
                }
                else
                {
                    Debug.Log("Неправильная точка");
                    Lose();
                }
                break;

            case "BluePoint":
                OrderPlayer[Number - 1] = 4;
                Debug.Log("Голубая");
                if (OrderPlayer[Number - 1] == LevelTest[Number - 1])
                {
                    Debug.Log("Правильная точка");
                    RightSoundSour.Play();
                }
                else
                {
                    Debug.Log("Неправильная точка");
                    Lose();
                }
                break;
        }
        if (Number == LevelTest.Length)
        {
            if (CheckWin())
                Win();
        }

        Number += 1;
     
    }
    bool CheckWin()
    {
        for (int i = 0; i < LevelTest.Length; i++)
        {
            if (OrderPlayer[i] != LevelTest[i])
                return false;
        }
        return true;
    }
    void Win()
    {
        Debug.Log("Победа");
    }
    void Lose()
    {
        MistakeSoundSour.Play();
        Debug.Log("Проигрыш");
    }
}
