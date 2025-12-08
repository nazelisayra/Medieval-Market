using UnityEngine;

public class SwordCarousel : MonoBehaviour
{
    [Header("Sword Images (GameObjects)")]
    public GameObject[] swords;   // sword1, sword2, sword3

    [Header("Options")]
    public bool loopAtEnd = false;  // true yaparsan 3'ten sonra 1'e döner

    private int _currentIndex = 0;

    private void Start()
    {
        // Sahne açıldığında sadece ilk sword görünsün
        ShowSword(_currentIndex);
    }

    public void ShowNextSword()
    {
        if (swords == null || swords.Length == 0)
            return;

        if (loopAtEnd)
        {
            // 0 -> 1 -> 2 -> 0 ...
            _currentIndex = (_currentIndex + 1) % swords.Length;
        }
        else
        {
            // 0 -> 1 -> 2 ve 2'de kal (daha fazla artma)
            if (_currentIndex < swords.Length - 1)
                _currentIndex++;
        }

        ShowSword(_currentIndex);
    }

    private void ShowSword(int index)
    {
        for (int i = 0; i < swords.Length; i++)
        {
            if (swords[i] != null)
                swords[i].SetActive(i == index);
        }
    }
}
