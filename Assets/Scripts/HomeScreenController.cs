using UnityEngine;
using UnityEngine.UI;

public class HomeScreenController : MonoBehaviour
{
    [SerializeField] private GameObject HomeScreen;
    [SerializeField] private Button StartGameButton;

    void Start()
    {
        StartGameButton.onClick.AddListener(OnClick);
    }

    void Update()
    {
        
    }

    public void OnClick()
    {
        // hide screen
        // start game
        // show game screen
    }

    public void ShowHomeScreen()
    {
        HomeScreen.SetActive(true);
    }

    public void HideHomeScreen()
    {
        HomeScreen.SetActive(false);
    }
}
