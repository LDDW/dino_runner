using UnityEngine;
using UnityEngine.UI;

public class GameScreenController : MonoBehaviour
{
    [SerializeField] private GameObject GameScreen;
    [SerializeField] private Text scoreText;

    void Start()
    {
        
    }

    void Update()
    {
        
    }

    public void ShowGameScreen()
    {
        GameScreen.SetActive(true);
    }

    public void HideGameScreen()
    {
        GameScreen.SetActive(false);
    }

    public void UpdateScore(int score)
    {
        scoreText.text = score.ToString();
    }
}
