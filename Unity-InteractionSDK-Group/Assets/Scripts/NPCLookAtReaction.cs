using UnityEngine;

public class NPCLookAtReaction : MonoBehaviour
{
    public Animator anim;
    public Transform playerCamera; // The MainCamera inside OVRCameraRig
    public float lookThreshold = 0.92f; // Dot product threshold

    private float reactionCooldown = 0f;

    void Start()
    {
        playerCamera = GameObject.Find("OVRCameraRig/TrackingSpace/CenterEyeAnchor").transform;
    }

    void Update()
    {
        reactionCooldown -= Time.deltaTime;
        if (reactionCooldown > 0) return;

        Vector3 toPlayer = (playerCamera.position - transform.position).normalized;
        float dot = Vector3.Dot(transform.forward, toPlayer);

        if (dot > lookThreshold)
        {
            anim.SetBool("IsCustomerLooking", true);

            float rnd = Random.value;
            anim.SetFloat("RandomReaction", rnd);

            if (rnd > 0.7f)
                anim.SetTrigger("Dance");
            else if (rnd < 0.2f)
                anim.SetTrigger("Kiss");
            else if (rnd > 0.9f)
                anim.SetTrigger("Rumba");

            reactionCooldown = 5f; // Prevent spam
        }
        else
        {
            anim.SetBool("IsCustomerLooking", false);
        }
    }
}