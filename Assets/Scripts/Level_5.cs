using UnityEngine;

public class Level_5 : LevelManager
{
    protected override void Start()
    {
        //последовательность уовня
        OrderLevel = new int[] { 1, 3, 2, 3, 4 };

        base.Start(); // вызываем базовый Start, чтобы OrderPlayer и Number настроились
    }

    protected override void Win()
    {
        base.Win();
        Debug.Log("Level 5 Complete!");
        // тут можно загрузить Level_2 или показать экран победы
    }
}

// 1,3,2,3,4,1

//Pink
//Green
//Yellow
//Green
//Blue
//Pink

//1 - розовая точка
//2 - желтая точка
//3 - зеленая точка
//4 - голубая точка
