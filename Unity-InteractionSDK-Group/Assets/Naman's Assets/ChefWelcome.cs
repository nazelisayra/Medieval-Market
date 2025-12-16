using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class ChefGreeting : MonoBehaviour
{
    void Start()
    {
        StartCoroutine(GreetPlayer());
    }

    IEnumerator GreetPlayer()
    {
        yield return new WaitForSeconds(2f);
        Debug.Log("Hello!");
    }
}

public class ChefWelcome : MonoBehaviour
{
    public Animator animator;
    public AudioSource audioSource;
    public float cooldown = 5f; // Chef won't repeat too fast
    private bool canGreet = true;

    private void OnTriggerEnter(Collider other)
    {
        // Detect player head or player rig
        if (!canGreet) return;

        if (other.CompareTag("MainCamera") || other.CompareTag("Player"))
        {
            StartCoroutine(WelcomeRoutine());
        }
    }

    private IEnumerator WelcomeRoutine()
    {
        canGreet = false;

        // Play animation
        animator.SetTrigger("Welcome");

        // Say hi
        audioSource.Play();

        // Wait before allowing another greeting
        yield return new WaitForSeconds(cooldown);
        canGreet = true;
    }
}
