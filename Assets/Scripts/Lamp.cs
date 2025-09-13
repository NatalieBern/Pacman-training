using UnityEngine;
using UnityEngine.UI;

public class Lamp : MonoBehaviour
{
    public Sprite LampDefault;
    public Sprite LampBlue;
    public Sprite LampYellow;
    public Sprite LampPink;
    public Sprite LampGreen;

    private Image ImageBase;

    void Start()
    {
        ImageBase = GetComponent<Image>();
        Level_0();

    }

    // Update is called once per frame
    void Update()
    {


    }

    void Level_0()
    {
        Invoke("ChangePink", 2f);
        Invoke("ChangeBlue", 4f);
        Invoke("ChangeGreen", 6f);
    }
    void ChangePink()
    {
        ImageBase.sprite = LampPink;
    }
    void ChangeGreen()
    {
        ImageBase.sprite = LampGreen;
    }
    void ChangeBlue()
    {
        ImageBase.sprite = LampBlue;
    }
    void ChangeDelault()
    {
        ImageBase.sprite = LampDefault;
    }
    void ChangeYellow()
    {
        ImageBase.sprite = LampYellow;
    }
}
