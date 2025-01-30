using UnityEngine;

public class DinoController : MonoBehaviour
{
    [SerializeField] private CharacterController controller;
    [SerializeField] private float speed = 5.0f;
    [SerializeField] private float acc = 0.01f;
    [SerializeField] private float jumpForce = 10.0f;

    private Vector3 velocity;
    private bool isGrounded;
    private bool gameStarted = false;

    private Vector3 initialPosition;

    [SerializeField] private float gravity = -20f;

    void Start()
    {
        // GameScreen.SetActive(false);
        // GameOverScreen.SetActive(false);
        // initialPosition = transform.position;
        // ShowHomeScreen();
    }

    void Update()
    {
        // if (!gameStarted) return;

        isGrounded = controller.isGrounded;

        if (isGrounded && velocity.y < 0)
        {
            velocity.y = 0f;
        }

        velocity.y += gravity * Time.deltaTime;

        float moveX = speed * Time.deltaTime;
        Vector3 move = new Vector3(moveX, 0, 0);

        if (Input.GetKeyDown(KeyCode.Space) && isGrounded)
        {
            velocity.y = jumpForce;
        }

        speed += Time.deltaTime * acc;

        controller.Move(move + velocity * Time.deltaTime);
    }

    private void OnControllerColliderHit(ControllerColliderHit hit)
    {
        if (hit.gameObject.CompareTag("collider"))
        {
            // stop game
            // call function to hide game screen and show game over screen
            // Time.timeScale = 0f; pas la bonne solution
        }
    }

    // public void StartGame()
    // {
    //     gameStarted = true;
    //     ResetPlayerPosition();
    //     ShowGameScreen();
    // }

    // public void GameOver()
    // {
    //     Time.timeScale = 0f;
    //     ShowGameOverScreen();
    // }

    // public void RestartGame()
    // {
    //     Time.timeScale = 1f;
    //     gameStarted = true;
    //     ResetPlayerPosition();
    //     ShowGameScreen();
    // }

    // public void ReturnToStart()
    // {
    //     Time.timeScale = 1f;
    //     gameStarted = false;
    //     ResetPlayerPosition();
    //     ShowHomeScreen();
    // }

    // private void ShowHomeScreen()
    // {
    //     HomeScreen.SetActive(true);
    //     GameScreen.SetActive(false);
    //     GameOverScreen.SetActive(false);
    // }

    // private void ShowGameScreen()
    // {
    //     HomeScreen.SetActive(false);
    //     GameScreen.SetActive(true);
    //     GameOverScreen.SetActive(false);
    // }

    // private void ShowGameOverScreen()
    // {
    //     HomeScreen.SetActive(false);
    //     GameScreen.SetActive(false);
    //     GameOverScreen.SetActive(true);
    // }

    // private void ResetPlayerPosition()
    // {
    //     controller.enabled = false;
    //     transform.position = initialPosition;
    //     controller.enabled = true; 
    //     velocity = Vector3.zero;
    // }
}