using UnityEngine;

public class MeatBehavior : MonoBehaviour
{
    private Vector3 startPos;
    private Quaternion startRot;
    private Rigidbody rb;
    public ShopkeeperController shopkeeper; // Drag the lady here

    void Start()
    {
        // Remember where the meat started
        startPos = transform.position;
        startRot = transform.rotation;
        rb = GetComponent<Rigidbody>();
    }

    void Update()
    {
        // If the meat falls through the floor (Y less than 0)
        if (transform.position.y < 0) 
        {
            ResetMeat();
        }
    }

    public void ResetMeat()
    {
        // Reset position and physics
        rb.velocity = Vector3.zero;
        rb.angularVelocity = Vector3.zero;
        transform.position = startPos;
        transform.rotation = startRot;

        // Make the lady mad because you threw it
        if(shopkeeper != null)
        {
            shopkeeper.TriggerAngry();
        }
    }
}