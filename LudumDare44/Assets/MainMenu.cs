using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;

public class MainMenu : MonoBehaviour
{

    [SerializeField] private GameObject continuePrompt;

    public void Initialize()
    {
        gameObject.SetActive(false);
    }
    // Start is called before the first frame update
    public void Show()
    {
        gameObject.SetActive(true);
        
        continuePrompt.SetActive(true);
        continuePrompt.transform.localScale = Vector3.one * 0.5f;
        continuePrompt.transform.DOScale(1, 0.3f).SetEase(Ease.OutBack);


    }
    
    public void Update()
    {
        if (!gameObject.activeSelf) return;
        
        if (Input.GetKeyDown("space"))
        {
            GameplayManager.instance.ShowSlideShow();
            gameObject.SetActive(false);
        }
    }

}
