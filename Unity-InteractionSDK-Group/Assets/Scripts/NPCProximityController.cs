using UnityEngine;

public class NPCProximityController : MonoBehaviour
{
    public Animator anim;
    public string playerTag = "Player"; // You will set tag on OVRCameraRig
    public float activationDistance = 3.5f;

    private Transform player;
    private bool isNear = false;

    void Start()
    {
        // Find your XR rig
        player = GameObject.Find("OVRCameraRig").transform;
    }

    void Update()
    {
        if (player == null) return;

        float dist = Vector3.Distance(transform.position, player.position);

        // Player enters interaction distance
        if (!isNear && dist < activationDistance)
        {
            isNear = true;
            anim.SetBool("IsCustomerNearby", true);
            anim.SetTrigger("Greet");       // Idle → Hello
            anim.SetTrigger("StartTalking"); // Hello → Talking
        }

        // Player leaves interaction distance
        if (isNear && dist > activationDistance + 1f)
        {
            isNear = false;
            anim.SetBool("IsCustomerNearby", false);
            anim.SetTrigger("ThankPlayer"); // Talking → Thankful
            anim.SetTrigger("ResetToIdle"); // Returns to Idle
        }
    }
}