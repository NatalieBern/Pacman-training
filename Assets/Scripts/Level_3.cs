using UnityEngine;

public class Level_3 : LevelManager
{
    protected override void Start()
    {
        //последовательность уовня
        OrderLevel = new int[] {  };

        base.Start(); // вызываем базовый Start, чтобы OrderPlayer и Number настроились
    }

    protected override void Win()
    {
        base.Win();
        Debug.Log("Level 2 Complete!");
        // тут можно загрузить Level_2 или показать экран победы
    }
}