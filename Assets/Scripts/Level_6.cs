using UnityEngine;

public class Level_6 : LevelManager
{
    protected override void Start()
    {
        //������������������ �����
        OrderLevel = new int[] { 1, 3, 2, 3, 4, 1 };

        base.Start(); // �������� ������� Start, ����� OrderPlayer � Number �����������
    }

    protected override void Win()
    {
        base.Win();
        Debug.Log("Level 6 Complete!");
        // ��� ����� ��������� Level_2 ��� �������� ����� ������
    }
}

// 1,3,2,3,4,1

//Pink
//Green
//Yellow
//Green
//Blue
//Pink

//1 - ������� �����
//2 - ������ �����
//3 - ������� �����
//4 - ������� �����
