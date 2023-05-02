using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public Rigidbody rb;

    public float forwardForce = 2000f;
    public float sidewaaysForce = 500f;

    // Update is called once per frame
    void FixedUpdate()
    {
        rb.AddForce(0, 0, forwardForce * Time.deltaTime);// * Time.deltaTime- sa functioneze la fel pt orice computer, indiferent de frame rate

        if (Input.GetKey("d"))
        {
            rb.AddForce(sidewaaysForce * Time.deltaTime, 0, 0,ForceMode.VelocityChange);
        }

        if (Input.GetKey("a"))
        {
            rb.AddForce(-sidewaaysForce * Time.deltaTime, 0, 0, ForceMode.VelocityChange);
        }

        if (rb.position.y < -1f)
        {
            FindObjectOfType<GameManager>().EndGame();
            
        }
    }
}
