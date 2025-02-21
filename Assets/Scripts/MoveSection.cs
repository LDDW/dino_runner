using UnityEngine;

public class MoveSection : MonoBehaviour
{
    [SerializeField] private float speed = 10.0f;
    [SerializeField] public GameManager gameManager;

    void Start()
    {
        
    }

    void Update()
    {
        if (!gameManager.gameIsLaunched) return;

        speed += Time.deltaTime * 0.1f;

        transform.Translate(Vector3.left * speed * Time.deltaTime); 
    }

    public void StartGame()
    {
        speed = 10.0f;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Destroy"))
        {
            Destroy(gameObject);
        }
    } 
}
