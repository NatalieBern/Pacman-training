using UnityEngine;

public class Point : MonoBehaviour
{
    private Animator PointAnin_;
    public GameObject PointObj_;

    void Start()
    {
        PointAnin_ = GetComponent<Animator>();   
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void StartAnimLose()
    {
        if (PointAnin_ != null)
        {
            PointAnin_.SetTrigger("isLose");
            Invoke("OffPoint", 1f);
        }

    }
    public void StartAnimRight()
    {
        if (PointAnin_ != null)
        {
            PointAnin_.SetTrigger("isRight");
        }
    }
    void OffPoint()
    {
        PointObj_.SetActive(false);
    }
}
