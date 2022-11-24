using UnityEngine;

public class WinPopUp : MonoBehaviour
{
    void Awake()
    {
        gameObject.SetActive(false);
    }

    public void Show()
    {
        gameObject.SetActive(true);
    }

}
