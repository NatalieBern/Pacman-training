using UnityEngine;

public class Level_1 : LevelManager
{
    protected override void Start()
    {
        //последовательность уовня
        OrderLevel = new int[] { 1 };

        base.Start(); // вызываем базовый Start, чтобы OrderPlayer и Number настроились
    }

    protected override void Win()
    {
        base.Win();
        Debug.Log("Level 1 Complete!");
        // тут можно загрузить Level_2 или показать экран победы
    }
}