using UnityEngine;

public class TeleportRingTrigger : MonoBehaviour
{
    [Header("Jugador / rig (cámara)")]
    public Transform player;          // arrastras tu Camera o XR Rig

    [Header("Particle system del aro de fuego")]
    public ParticleSystem fireRing;   // arrastras el hijo FireRingFX

    [Header("Distancia para activar")]
    public float triggerDistance = 0.5f;

    [Header("Tiempo entre activaciones")]
    public float cooldown = 1.5f;

    float lastTimePlayed = -999f;

    void Update()
    {
        if (player == null || fireRing == null) return;

        // ignorar altura: solo distancia en el plano
        Vector3 playerPos = player.position;
        Vector3 here = transform.position;
        playerPos.y = 0f;
        here.y = 0f;

        float dist = Vector3.Distance(playerPos, here);

        if (dist < triggerDistance && Time.time - lastTimePlayed > cooldown)
        {
            fireRing.Play();
            lastTimePlayed = Time.time;
        }
    }
}
