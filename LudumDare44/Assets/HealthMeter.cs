using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;
using UnityEngine.UI;

public class HealthMeter : MonoBehaviour
{
    private float fillValue;
    [SerializeField] private Image meterFill;
    [SerializeField] private CanvasGroup canvasGroup;

    private float lastUpdate;
    private float updateFade = 1;

    private bool isVisible;
    
    public void SetFill(float value)
    {
        if (!isVisible) FadeOn();
        
        meterFill.fillAmount = DOVirtual.EasedValue(0, 1, value, Ease.OutQuad);
        lastUpdate = Time.time;
    }

    public void Initialize()
    {
        lastUpdate = 0;
        canvasGroup.alpha = 0;
        gameObject.SetActive(false);
    }

    public void Update()
    {
        if (isVisible)
        {
            if (Time.time - lastUpdate > updateFade)
            {
                FadeOff();
            }
        }
    }
    

    private void FadeOn()
    {
        DOTween.Kill(canvasGroup);
        canvasGroup.alpha = 0;
        canvasGroup.DOFade(1, 0.2f);

        gameObject.SetActive(true);
        isVisible = true;
    }

    private void FadeOff()
    {
        DOTween.Kill(canvasGroup);
        canvasGroup.DOFade(0, 0.2f).OnComplete(()=> { gameObject.SetActive(false);});

        isVisible = false;
    }
}
