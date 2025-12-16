using UnityEngine;

public class CowMooTimer : MonoBehaviour
{
    public AudioSource mooSound;
    public float mooInterval = 10f; // play every 10 seconds

    private float timer = 0f;

    void Update()
    {
        timer += Time.deltaTime;

        if (timer >= mooInterval)
        {
            mooSound.Play();
            timer = 0f;
        }
    }
}
