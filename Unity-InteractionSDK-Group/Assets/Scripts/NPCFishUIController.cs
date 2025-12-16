using UnityEngine;
using UnityEngine.UI;

public class NPCFishUIController : MonoBehaviour
{
    public Animator anim;

    public Slider weightSlider;
    public Dropdown fishTypeDropdown;
    public Button buyButton;

    void Start()
    {
        // Open UI means Calculating
        weightSlider.onValueChanged.AddListener(OnSliderChanged);
        fishTypeDropdown.onValueChanged.AddListener(OnDropdownChanged);

        // Buy logic
        buyButton.onClick.AddListener(OnBuyPressed);
    }

    void OnSliderChanged(float v)
    {
        anim.SetBool("IsUIOpen", true);
        anim.SetTrigger("StartCalculating");
    }

    void OnDropdownChanged(int index)
    {
        anim.SetBool("IsUIOpen", true);
        anim.SetTrigger("StartCalculating");
    }

    void OnBuyPressed()
    {
        anim.SetTrigger("GiveFish");     // Talking → FishGrab
        anim.SetTrigger("ThankPlayer");  // FishGrab → Thankful
        anim.SetTrigger("ResetToIdle");  // Back to Idle
    }
}
