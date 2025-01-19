using UnityEngine;

public class CamController : MonoBehaviour
{
    public float followSpeed = 15f;

    // Start est appelé une fois avant la première exécution de Update
    void Start()
    {

    }

    // Update est appelé une fois par frame
    void Update()
    {
        this.transform.position += new Vector3(followSpeed * Time.deltaTime, 0, 0);
    }
}