using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOverDialog : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI totalZombiesText;
    [SerializeField] private TextMeshProUGUI largestArmyText;

    [SerializeField] private TextMeshProUGUI title;
    [SerializeField] private GameObject dialog;
    [SerializeField] private GameObject continuePrompt;

    private bool continueEnabled;
    // Start is called before the first frame update
    public void Initialize()
    {
        gameObject.SetActive(false);
        continuePrompt.SetActive(false);
    }

    // Update is called once per frame
    public void Show(bool success = false)
    {
        if (success)
        {
            title.text = "MISSION 1: COMPLETE";
        }
        totalZombiesText.text = GameplayManager.instance.totalZombies + " / " + GameplayManager.instance.totalCivilians;
        largestArmyText.text = GameplayManager.instance.largestArmy.ToString();

        gameObject.SetActive(true);
        dialog.transform.localScale = Vector3.one * 0.5f;
        dialog.transform.DOScale(1, 0.3f).SetEase(Ease.OutBack);

        DOVirtual.DelayedCall(0.5f, EnableContinue);
    }

    public void EnableContinue()
    {
        continuePrompt.SetActive(true);
        continueEnabled = true;
        continuePrompt.transform.localScale = Vector3.one * 0.5f;
        continuePrompt.transform.DOScale(1, 0.3f).SetEase(Ease.OutBack);
    }
    
    public void Update()
    {
        if (!gameObject.activeSelf || !continueEnabled) return;
        
        if (Input.GetKeyDown("space"))
        {
            Scene scene = SceneManager.GetActiveScene(); 
            SceneManager.LoadScene(scene.name);
        }
    }

}
