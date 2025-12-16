using UnityEngine;

public class OrderMenuController : MonoBehaviour
{
    public GameObject apple;
    public GameObject carrot;
    public GameObject banana;

    public void ShowApple()
    {
        HideAll();
        apple.SetActive(true);
    }

    public void ShowCarrot()
    {
        HideAll();
        carrot.SetActive(true);
    }

    public void ShowBanana()
    {
        HideAll();
        banana.SetActive(true);
    }

    private void HideAll()
    {
        apple.SetActive(false);
        carrot.SetActive(false);
        banana.SetActive(false);
    }
}
