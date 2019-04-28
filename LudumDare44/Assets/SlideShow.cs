using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;
using UnityEngine.UI;

public class SlideShow : MonoBehaviour
{
    public List<Sprite> slideSprites = new List<Sprite>();

    public GameObject slideContainer;
    public Image slideImage;
    public Image spacePrompt;

    private int currentSlide = -1;

    public void Initialize()
    {
        gameObject.SetActive(false);
        spacePrompt.color = new Color(1,1,1,0);
    }
    // Start is called before the first frame update
    public void Show()
    {
        gameObject.SetActive(true);
        AdvanceSlide();
    }

    public void Update()
    {
        if (!gameObject.activeSelf) return;
        
        if (Input.GetKeyDown("space"))
        {
            if (currentSlide < slideSprites.Count - 1)
            {
                AdvanceSlide();
            }
            else
            {
                gameObject.SetActive(false);
                DOVirtual.DelayedCall(0.5f, GameplayManager.instance.EndSlideShow);
            }
        }
    }

    void AdvanceSlide()
    {
        currentSlide++;
        DOTween.Kill(slideContainer.transform);
        DOTween.Kill(spacePrompt.transform);
        DOTween.Kill(spacePrompt);

        spacePrompt.color = new Color(1, 1, 1, 0);
        spacePrompt.transform.localScale = Vector3.one * 0.6f;
        spacePrompt.DOFade(1, 0.1f).SetDelay(0.3f);
        spacePrompt.transform.DOScale(1, 0.3f).SetEase(Ease.OutBack).SetDelay(0.3f);
        
        slideContainer.transform.eulerAngles = slideContainer.transform.eulerAngles * -1;
        slideContainer.transform.localScale = Vector3.one * 0.5f;
        slideContainer.transform.DOScale(1, 0.3f).SetEase(Ease.OutBack);
        slideImage.sprite = slideSprites[currentSlide];        
    }
}
