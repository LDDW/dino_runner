using UnityEngine;

public class DinoController : MonoBehaviour
{
    public float speed = 5f;
    public float jumpForce = 5f;

    void Start()
    {
    }

    void Update()
    {
        if (Input.GetKey(KeyCode.Space))
        {
            this.transform.position += new Vector3(0, jumpForce * Time.deltaTime, 0);
        }

        this.transform.position += new Vector3(speed * Time.deltaTime, 0, 0);
    }
}