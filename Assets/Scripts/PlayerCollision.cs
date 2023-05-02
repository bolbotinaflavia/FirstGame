using UnityEngine;

public class PlayerCollision : MonoBehaviour
{
    public PlayerMovement movement;
    //public GameManager gameManager; nu se foloseste, se cauta de fiecare data


    public int cubePerAxis = 8;
    public float delay = 1f;
    public float force = 300f;
    public float radius = 2f;

    // Start is called before the first frame update

    void Start()
    {
    }

    void Main()
    {
        for (int x = 0; x < cubePerAxis; x++)
            for (int y = 0; y < cubePerAxis; y++)
                for (int z = 0; z < cubePerAxis; z++)
                    CreateCube(new Vector3(x, y, x));
        Destroy(gameObject);
    }
    void CreateCube(Vector3 coordinates)
    {
        GameObject cube = GameObject.CreatePrimitive(PrimitiveType.Cube);

        Renderer rd = GetComponent<Renderer>();
        rd.material = GetComponent<Renderer>().material;
        cube.GetComponent<Renderer>().material = rd.material;

        cube.transform.localScale = transform.localScale / cubePerAxis;

        Vector3 firstCube = transform.position - transform.localScale / 2 + cube.transform.localScale / 2;
        cube.transform.position = firstCube + Vector3.Scale(coordinates, cube.transform.localScale);

        Rigidbody rb = cube.AddComponent<Rigidbody>();
        rb.AddExplosionForce(force, transform.position, radius);
    }

    void OnCollisionEnter(Collision collisionInfo)
    {

       

        if (collisionInfo.collider.tag == "Obstacle")
        {
            movement.enabled = false;
            Invoke("Main", delay);
            FindObjectOfType<GameManager>().EndGame();
           
        }
    }
}
