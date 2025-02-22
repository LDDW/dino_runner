using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    [SerializeField] public GameObject gameOverUI;
    [SerializeField] public GameObject homeUI;
    [SerializeField] public DinoController dinoController;
    [SerializeField] public MoveSection moveSection;
    [SerializeField] public bool gameIsLaunched = false;

    void Start()
    {
        gameIsLaunched = false;
        displayHomeScreen();
        hiddenGameOverScreen();
    }

    void Update()
    {
        
    }

    public void displayGameOverScreen()
    {
        if (gameOverUI != null) {
            gameOverUI.SetActive(true);
        } else {
            Debug.LogError("Impossible d'afficher l'écran de game over: gameOverUI est null");
        }
    }

    public void hiddenGameOverScreen()
    {
        if (gameOverUI != null) {
            gameOverUI.SetActive(false);
        } else {
            Debug.LogError("Impossible de cacher l'écran de game over: gameOverUI est null");
        }
    }

    public void displayHomeScreen()
    {
        if (homeUI != null) {
            homeUI.SetActive(true);
        } else {
            Debug.LogError("Impossible d'afficher l'écran d'accueil: homeUI est null");
        }
    }

    public void hiddenHomeScreen()
    {
        if (homeUI != null) {
            homeUI.SetActive(false);
        } else {
            Debug.LogError("Impossible de cacher l'écran d'accueil: homeUI est null");
        }
    }

    public void StartGame()
    {
        hiddenHomeScreen();
        gameIsLaunched = true;
        dinoController.StartGame();
        moveSection.StartGame();
    }


    public void restart()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}