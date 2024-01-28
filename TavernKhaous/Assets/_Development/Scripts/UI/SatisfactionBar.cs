using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;

public class SatisfactionBar : MonoBehaviour
{
    public Slider slider;
    public Gradient gradient;
    public Image fill;

    [SerializeField]
    private float fillTransitionTime = 0.25f;

    private GradientColorKey[] gck = new GradientColorKey[3];
    private GradientAlphaKey[] gak = new GradientAlphaKey[3];

    public void HandleInitializeSatisfactionBar(Component sender, object data)
    {
        if (data is SatisfactionStruct)
        {
            SatisfactionStruct satisfactionData = (SatisfactionStruct) data;
            InitializeSatisfactionBar(satisfactionData.MaxSatisfaction, satisfactionData.InitialSatisfaction);
        }
    }

    public void HandleUpdateSatisfactionBar(Component sender, object data)
    {
        if (data is int)
        {
            int satisfactionValue = (int) data;
            UpdateSatisfactionBar(satisfactionValue);
        }
    }

    private void InitializeSatisfactionBar(int maxSatisfaction, int initialSatisfaction)
    {
        slider.maxValue = maxSatisfaction;
        slider.minValue = 0;
        slider.value = initialSatisfaction;

        InitializeGradient();

        fill.color = gradient.Evaluate(slider.normalizedValue);
    }

    private void InitializeGradient()
    {
        gradient.mode = GradientMode.Blend;

        gck[0].color = Color.green;
        gck[0].time = 1.0F;
        gck[1].color = Color.red;
        gck[1].time = 0.0F;
        gck[2].color = Color.yellow;
        gck[2].time = 0.5F;
        gak[0].alpha = 1.0F;
        gak[0].time = 1.0F;
        gak[1].alpha = 1.0F;
        gak[1].time = 0.0F;
        gak[2].alpha = 1.0F;
        gak[2].time = 0.5F;
        gradient.SetKeys(gck, gak);
    }

    private void UpdateSatisfactionBar(int satisfactionValue)
    {
        // slider.value = satisfactionValue;
        slider.DOValue(satisfactionValue, fillTransitionTime).SetEase(Ease.OutBounce);

        fill.color = gradient.Evaluate(slider.normalizedValue);
    }
}
