using UnityEngine;

public class ShopkeeperController : MonoBehaviour
{
    public Animator animator;

    // Call this when player grabs the meat
    public void TriggerWave()
    {
        Debug.Log("✅ MESSAGE RECEIVED: I should be Waving!"); // <--- This will print if the meat works
        
        if (animator != null)
        {
            animator.SetTrigger("doWave");
        }
        else
        {
            Debug.LogError("❌ ERROR: I got the message, but my 'Animator' slot is empty!");
        }
    }

    // Call this when player throws the meat
    public void TriggerAngry()
    {
        Debug.Log("✅ MESSAGE RECEIVED: I should be Angry!");
        
        if (animator != null)
        {
            animator.SetTrigger("doAngry");
        }
    }

    public void TriggerConfusion()
    {
        if (animator != null) animator.SetTrigger("doConfused");
    }
}