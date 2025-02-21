using System.Collections;
using UnityEngine;

public class DinoController : MonoBehaviour
{
    [SerializeField] private CharacterController controller;
    [SerializeField] private float acc = 0.01f;
    [SerializeField] private float jumpForce = 10.0f;
    [SerializeField] private float gravity = -20f;
    [SerializeField] private bool isGrounded;
    [SerializeField] private Vector3 velocity;
    [SerializeField] public GameManager gameManager;
    [SerializeField] private GameObject section;
    [SerializeField] private bool sectionSpawned = false;
    [SerializeField] private GameObject trex;
    [SerializeField] private Animator trexAnimator;

    void Start()
    {  
        velocity = Vector3.zero;
        trexAnimator = trex.GetComponent<Animator>();
        trexAnimator.enabled = false; 
    }

    void Update()
    {
        if (!gameManager.gameIsLaunched) return;

        trexAnimator.enabled = true;

        isGrounded = controller.isGrounded;

        if (isGrounded && velocity.y < 0)
        {
            velocity.y = -2f;
        }

        if (Input.GetKeyDown(KeyCode.Space) && isGrounded)
        {
            velocity.y = jumpForce;
        }

        velocity.y += gravity * Time.deltaTime;

        controller.Move(velocity * Time.deltaTime);
    }

    public void StartGame()
    {
        velocity = Vector3.zero;
    }

    private void OnControllerColliderHit(ControllerColliderHit hit)
    {
        if (gameManager.gameIsLaunched && hit.gameObject.CompareTag("collider"))
        {

            gameManager.gameIsLaunched = false;
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

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Trigger") && section != null && !sectionSpawned)
        {
            Instantiate(section, new Vector3(60, 0.5f, 0), Quaternion.identity);
            sectionSpawned = true;
            StartCoroutine(ResetSectionSpawn());
        }
    } 

    private IEnumerator ResetSectionSpawn()
    {
        yield return new WaitForSeconds(0.5f);
        sectionSpawned = false;
    }
}