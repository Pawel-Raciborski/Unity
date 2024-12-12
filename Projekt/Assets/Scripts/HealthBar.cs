using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour
{
    private RectTransform bar;
    private Image barImage;
    // Start is called before the first frame update
    void Start()
    {
        bar = GetComponent<RectTransform>();
        barImage = GetComponent<Image>();
        SetSize(PlayerHealth.health);

        if (PlayerHealth.GetInterpolatedHealth() < 0.3f)
        {
            barImage.color = Color.red;
        }
    }

    void Update()
    {
        SetSize(PlayerHealth.GetInterpolatedHealth());
    }

    public void SetSize(float size)
    {
        bar.localScale = new Vector2(size, 1f);
    }
}
