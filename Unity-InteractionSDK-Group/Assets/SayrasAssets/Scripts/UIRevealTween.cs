using System.Collections;
using UnityEngine;

public class UIRevealTween : MonoBehaviour
{
    [Header("Fade + Scale (relative)")]
    public CanvasGroup canvasGroup;
    public Transform target;
    public float showDuration = 0.35f;

    [Tooltip("1 = aynı boy. 0.92 = %8 küçük başlayıp büyür.")]
    public float startScaleFactor = 0.92f;

    [Header("Auto Hide")]
    public bool autoHide = true;
    public float visibleTime = 2.5f;         // 2–3 saniye
    public float hideDuration = 0.30f;
    public float endScaleFactor = 0.98f;     // kaybolurken çok hafif küçülsün

    [Header("Sound (optional)")]
    public AudioSource audioSource;
    public AudioClip revealClip;
    public AudioClip hideClip;

    private Vector3 baseScale;
    private Coroutine routine;

    void Reset()
    {
        canvasGroup = GetComponent<CanvasGroup>();
        target = transform;
    }

    void Awake()
    {
        if (!canvasGroup) canvasGroup = GetComponent<CanvasGroup>();
        if (!target) target = transform;

        baseScale = target.localScale;

        // başlangıçta görünmesin
        canvasGroup.alpha = 0f;
        target.localScale = baseScale * startScaleFactor;
        gameObject.SetActive(false);
    }

    public void Show()
    {
        // tekrar çağrılırsa düzgün resetlensin
        if (routine != null) StopCoroutine(routine);

        gameObject.SetActive(true);
        routine = StartCoroutine(ShowHideRoutine());
    }

    IEnumerator ShowHideRoutine()
    {
        // SHOW
        if (audioSource && revealClip)
            audioSource.PlayOneShot(revealClip);

        float t = 0f;
        while (t < showDuration)
        {
            t += Time.unscaledDeltaTime;
            float p = Mathf.Clamp01(t / showDuration);
            float eased = 1f - Mathf.Pow(1f - p, 3f); // easeOutCubic

            canvasGroup.alpha = eased;
            target.localScale = Vector3.Lerp(baseScale * startScaleFactor, baseScale, eased);

            yield return null;
        }

        canvasGroup.alpha = 1f;
        target.localScale = baseScale;

        // WAIT
        if (autoHide)
        {
            float wait = Mathf.Max(0f, visibleTime);
            float elapsed = 0f;
            while (elapsed < wait)
            {
                elapsed += Time.unscaledDeltaTime;
                yield return null;
            }

            // HIDE
            if (audioSource && hideClip)
                audioSource.PlayOneShot(hideClip);

            float ht = 0f;
            while (ht < hideDuration)
            {
                ht += Time.unscaledDeltaTime;
                float p = Mathf.Clamp01(ht / hideDuration);
                float eased = p * p * (3f - 2f * p); // smoothstep

                canvasGroup.alpha = Mathf.Lerp(1f, 0f, eased);
                target.localScale = Vector3.Lerp(baseScale, baseScale * endScaleFactor, eased);

                yield return null;
            }

            canvasGroup.alpha = 0f;
            target.localScale = baseScale * startScaleFactor;

            gameObject.SetActive(false);
        }

        routine = null;
    }
}
