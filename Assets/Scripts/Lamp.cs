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

    public GameObject PlayerOb;

    void Start()
    {
        ImageBase = GetComponent<Image>();
        PlayerOb.SetActive(false);
        Level_0();

    }

    // Update is called once per frame
    void Update()
    {


    }

    void Level_0()
    {
        Invoke("ChangePink", 1f);
        Invoke("ChangeBlue", 1.5f);
        Invoke("ChangeGreen", 2f);
        Invoke("ChangeDelault",2.5f);
        Invoke("SpawnPlayer", 0.5f);
        



    }
    void SpawnPlayer()
    {
        PlayerOb.SetActive(true);
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
