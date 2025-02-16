using UnityEngine;

public class DinoController : MonoBehaviour
{
    [SerializeField] private CharacterController controller;
    [SerializeField] private float speed = 5.0f;
    [SerializeField] private float acc = 0.01f;
    [SerializeField] private float jumpForce = 10.0f;
    [SerializeField] private float gravity = -20f;
    [SerializeField] private bool isGrounded;
    [SerializeField] private bool gameIsLaunched = false;
    [SerializeField] private Vector3 velocity;
    [SerializeField] public GameManager gameManager;

    void Start()
    {
        gameIsLaunched = false;
        velocity = Vector3.zero;
    }

    void Update()
    {
        if (!gameIsLaunched) return;

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
        if (gameIsLaunched && hit.gameObject.CompareTag("collider"))
        {
            Die();
        }
    }

    public void StartGame()
    {
        gameIsLaunched = true;
        velocity = Vector3.zero;
        speed = 5.0f;
    }

    private void Die()
    {
        gameIsLaunched = false;
        velocity = Vector3.zero;
        
        if (gameManager != null)
        {
            gameManager.displayGameOverScreen();
        }
        else
        {
            Debug.LogError("GameManager non assigné dans DinoController!");
        }
    }

}