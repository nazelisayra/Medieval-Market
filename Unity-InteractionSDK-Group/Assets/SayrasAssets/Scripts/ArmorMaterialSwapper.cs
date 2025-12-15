using UnityEngine;

public class ArmorMaterialSwapper : MonoBehaviour
{
    [Tooltip("True: tüm material slotlarını değiştirir. False: sadece ilk slot (0).")]
    public bool replaceAllSlots = true;

    private Renderer[] _renderers;

    void Awake()
    {
        // SkinnedMeshRenderer dahil her şeyi yakalar
        _renderers = GetComponentsInChildren<Renderer>(true);
    }

    public void ApplyMaterial(Material mat)
    {
        if (mat == null || _renderers == null) return;

        foreach (var r in _renderers)
        {
            if (r == null) continue;

            var mats = r.sharedMaterials;
            if (mats == null || mats.Length == 0) continue;

            if (replaceAllSlots)
            {
                for (int i = 0; i < mats.Length; i++)
                    mats[i] = mat;

                r.sharedMaterials = mats;
            }
            else
            {
                mats[0] = mat;
                r.sharedMaterials = mats;
            }
        }
    }
}
