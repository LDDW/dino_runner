using UnityEngine;
using UnityEngine.UI;

public class GameOverScreenController : MonoBehaviour
{
    [SerializeField] private GameObject GameOverScreen;
    [SerializeField] private Button RestartButton;
    [SerializeField] private Button HomeButton;

    void Start()
    {
        RestartButton.onClick.AddListener(OnRestartClick);
        HomeButton.onClick.AddListener(OnHomeClick);
    }

    void Update()
    {
                
    }

    public void OnRestartClick()
    {

    }

    public void OnHomeClick()
    {

    }

    public void ShowGameOverScreen()
    {
        GameOverScreen.SetActive(true);
    }

    public void HideGameOverScreen()
    {
        GameOverScreen.SetActive(false);
    }
}
