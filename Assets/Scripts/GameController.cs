using UnityEngine;

public class GameController : MonoBehaviour
{
    public DinoController dinoController;

    // screen
    public HomeScreenController homeScreenController;
    public GameScreenController gameScreenController;
    public GameOverScreenController gameOverScreenController;

    void Awake() 
    {
        
    }

    void Start()
    {
        homeScreenController.ShowHomeScreen();
        gameScreenController.HideGameScreen();
        gameOverScreenController.HideGameOverScreen();
    }

    void Update()
    {
        
    }

    
}
