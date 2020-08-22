using UnityEngine;
using UnityEngine.UI;

/// <summary>
/// This class take care of scaling the UI image that is used as a health bar, based on the ratio sent to it.
/// It is a singleton so it can be called from anywhere (e.g. PlayerController SetHealth)
/// </summary>
public class UIHealthBar : MonoBehaviour
{
	public static UIHealthBar Instance { get; private set; }

	public Image healthBar;
	public Image manaBar;

	float healthOriginalSize;
	float manaOriginalSize;

	// Use this for initialization
	void Awake ()
	{
		Instance = this;
	}

	void OnEnable()
	{
		healthOriginalSize = healthBar.rectTransform.rect.width;
		manaOriginalSize = manaBar.rectTransform.rect.width;
	}

	public void SetHealthValue(float value)
	{
		healthOriginalSize = 168f;
		healthBar.rectTransform.SetSizeWithCurrentAnchors(RectTransform.Axis.Horizontal, healthOriginalSize * value);
	}

	public void SetManaValue(float value)
    {
		manaOriginalSize = 168f;
		manaBar.rectTransform.SetSizeWithCurrentAnchors(RectTransform.Axis.Horizontal, manaOriginalSize * value);
    }
}
