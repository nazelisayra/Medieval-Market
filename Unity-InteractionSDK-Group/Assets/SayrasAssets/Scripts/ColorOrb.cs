using UnityEngine;

public class ColorOrb : MonoBehaviour
{
    public ArmorMaterialSwapper targetArmor;
    public Material materialToApply;

    [Tooltip("MaterialToApply boşsa, kürenin kendi material'ını kullanır.")]
    public bool useOwnMaterialIfEmpty = true;

    void Awake()
    {
        if (useOwnMaterialIfEmpty && materialToApply == null)
        {
            var r = GetComponent<Renderer>();
            if (r) materialToApply = r.sharedMaterial;
        }
    }

    // Bunu Interaction event'ine bağlayacağız
    public void Apply()
    {
        if (targetArmor && materialToApply)
            targetArmor.ApplyMaterial(materialToApply);
    }
}
