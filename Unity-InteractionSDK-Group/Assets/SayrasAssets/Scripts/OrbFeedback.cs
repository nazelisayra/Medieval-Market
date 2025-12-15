using System.Collections;
using UnityEngine;

public class OrbFeedback : MonoBehaviour
{
    [Header("Pop")]
    public Transform target;
    public float popUpScale = 1.12f;
    public float popDuration = 0.12f;

    [Header("Sound")]
    public AudioSource audioSource;
    public AudioClip clickClip;

    [Header("Optional FX")]
    public ParticleSystem fx;

    Vector3 baseScale;
    Coroutine routine;

    void Awake()
    {
        if (!target) target = transform;
        baseScale = target.localScale;
    }

    public void PlayFeedback()
    {
        if (audioSource && clickClip)
            audioSource.PlayOneShot(clickClip);

        if (fx)
        {
            fx.Play();
        }

        if (routine != null) StopCoroutine(routine);
        routine = StartCoroutine(PopRoutine());
    }

    IEnumerator PopRoutine()
    {
        // up
        float t = 0f;
        while (t < popDuration)
        {
            t += Time.unscaledDeltaTime;
            float p = Mathf.Clamp01(t / popDuration);
            target.localScale = Vector3.Lerp(baseScale, baseScale * popUpScale, p);
            yield return null;
        }

        // back
        t = 0f;
        while (t < popDuration)
        {
            t += Time.unscaledDeltaTime;
            float p = Mathf.Clamp01(t / popDuration);
            target.localScale = Vector3.Lerp(baseScale * popUpScale, baseScale, p);
            yield return null;
        }

        target.localScale = baseScale;
        routine = null;
    }
}
