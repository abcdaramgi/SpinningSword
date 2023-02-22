using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SwordFly : MonoBehaviour
{
    Rigidbody2D rb;
    public float jumpPower;
    public float rotationPower;
    public static bool swordWay = false;
    public Vector3 center_of_mass;
    Vector3 targetPosition;
    public GameObject go;
    float ratio;
    public Transform headPosition;
    // private Quaternion targetRotation;
    private Quaternion Right = Quaternion.identity;
    private bool shouldRotateClockwise = true;
    public float rotationSpeed = 100f;
    public float targetRotation = 180f;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();

        gameObject.GetComponent<Rigidbody2D>().centerOfMass = center_of_mass;

        Vector2 gravityDirection = headPosition.position - transform.position;
        gravityDirection.Normalize();

        Physics2D.gravity = gravityDirection * Physics2D.gravity.magnitude;
    }

    // Update is called once per frame
    void Update()
    {
        Vector2 gravityDirection = headPosition.position - transform.position;
        gravityDirection.Normalize();

        Physics2D.gravity = gravityDirection * Physics2D.gravity.magnitude;
        // targetPosition = new Vector3(transform.position.x, transform.position.y, 180);
        // transform.LookAt(targetPosition);
        // gameObject.GetComponent<Rigidbody2D>().centerOfMass = center_of_mass;
        //Debug.Log(rb.angularVelocity);
        // transform.Rotate(new Vector3(0, 0, ratio));
        //ratio *= 0.97f;

        if (Input.GetKeyDown(KeyCode.B))
        {
            if (transform.rotation.eulerAngles.z < targetRotation)
            {
                rb.angularVelocity = 0;
                float rotaPower = rotationPower + Random.Range(-10f, 11f);
                rb.AddTorque(rotaPower * -1, ForceMode2D.Force);
                // rb.angularVelocity = 0;
                // // Apply torque to the z-axis of the object
                // float torque = rotationSpeed * Time.deltaTime;
                // Debug.Log(torque);
                // rb.AddTorque(torque, ForceMode2D.Force);

            }
            // shouldRotateClockwise = !shouldRotateClockwise;
            // rb.angularVelocity = 0;
            // float rotation = shouldRotateClockwise ? 180 : -180;
            // targetRotation *= Quaternion.Euler(0, 0, rotation);
        }
        
        if(Input.GetMouseButtonDown(0)){

            // for(int i = 0; i < transform.childCount; i++)
            GetComponent<AudioSource>().Play();
            jumpSword();

            // if(swordWay)
            //     jumpSword();
            // else
            //     jumpSword(-1);
        }
    }

    public void jumpSword(int way = 1)
    {
        rb.angularVelocity = 0;
        float rotaPower = rotationPower + Random.Range(-10f,11f);
        rb.AddTorque(rotaPower * way, ForceMode2D.Force);
        //rb.AddForce(Vector2.up * jumpPower, ForceMode2D.Force);

        //if(rb.velocity.y <= 0)
        //    rb.drag
        rb.velocity = Vector2.up * jumpPower;


        //ratio = -10;
    }

    private void OnCollisionEnter2D(Collision2D other) {
        if(Score.score > Score.bestScore){
            Score.bestScore = Score.score;
        }
        SceneManager.LoadScene("GameOverScene");
    }

    public void jump2Sword(int way = 1)
    {
        rb.angularVelocity = 0;
        float rotaPower = rotationPower + Random.Range(-10f, 11f);
        rb.AddTorque(rotaPower * way, ForceMode2D.Force);
        //rb.AddForce(Vector2.up * jumpPower, ForceMode2D.Force);

        //if(rb.velocity.y <= 0)
        //    rb.drag
        rb.velocity = Vector2.up * jumpPower;
    }

    // void CheckRotationAndFall()
    // {
    //     // If the knife is not rotating and it's not facing down, make it rotate 180 degrees
    //     if (rb.angularVelocity == 0)
    //     {
    //         // Set the rotation of the knife to 180 degrees around the Z-axis
    //         transform.rotation = Quaternion.Euler(0, 0, 180);
    //     }
    // }

    // void FixedUpdate()
    // {
    //     transform.rotation = Quaternion.Lerp(transform.rotation, targetRotation, rotationSpeed * Time.fixedDeltaTime);
    //         // If the knife is not rotating and it's not facing down, make it rotate in the current direction
    //         if (rb.angularVelocity == 0)
    //         {
    //             // Set the rotation of the knife based on the current rotation direction
    //             float rotation = shouldRotateClockwise ? 90 : -90;
    //             rb.AddTorque(rotation);
    //         }
    // }

}
