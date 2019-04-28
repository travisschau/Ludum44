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
    
    [SerializeField] private GameObject dialog;
    // Start is called before the first frame update
    public void Initialize()
    {
        gameObject.SetActive(false);
    }

    // Update is called once per frame
    public void Show()
    {
        totalZombiesText.text = GameplayManager.instance.totalZombies.ToString();
        largestArmyText.text = GameplayManager.instance.largestArmy.ToString();

        gameObject.SetActive(true);
        dialog.transform.localScale = Vector3.one * 0.5f;
        dialog.transform.DOScale(1, 0.3f).SetEase(Ease.OutBack);
    }
    
    public void Update()
    {
        if (!gameObject.activeSelf) return;
        
        if (Input.GetKeyDown("space"))
        {
            Scene scene = SceneManager.GetActiveScene(); 
            SceneManager.LoadScene(scene.name);
        }
    }

}
