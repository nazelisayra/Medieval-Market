using UnityEngine;

public class CowProximityMoo : MonoBehaviour
{
    public AudioSource mooSound;
    public Transform player;
    public float triggerDistance = 2f;  // distance required to moo
    private bool hasMooed = false;

    void Update()
    {
        float distance = Vector3.Distance(player.position, transform.position);

        if (distance < triggerDistance && !hasMooed)
        {
            mooSound.Play();
            hasMooed = true;
        }
        else if (distance >= triggerDistance)
        {
            hasMooed = false;  // reset so it can moo again when you leave and return
        }
    }
}
