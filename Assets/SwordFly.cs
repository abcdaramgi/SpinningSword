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
    public float torque = 10f; // The torque to apply
    public float resistance = 2f; // The resistance to rotation
    public float damping = 2f;  
    public RotateObject rotateObject;
    private bool blueCheck = false;
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
        if(blueCheck){
            // float currentRotation = transform.rotation.eulerAngles.z;

            // if (currentRotation > targetRotation)
            // {
            //     // rotate counterclockwise
            //     rb.AddTorque(-torque);
            // }
            // else if (currentRotation < targetRotation)
            // {
            //     // rotate clockwise
            //     rb.AddTorque(torque);
            // }

            // // apply rotation resistance
            // rb.angularVelocity *= Mathf.Clamp01(1f - Time.deltaTime * damping);

            // // check if the target rotation has been reached
            // if (Mathf.Abs(transform.rotation.eulerAngles.z - targetRotation) < 0.1f)
            // {
            //     blueCheck = false;
            //     rb.angularVelocity = 0f; // stop the rotation
            // }

            // if(gameObject.transform.rotation.z > 120){

            // rb.angularVelocity *= Mathf.Clamp01(1f - Time.deltaTime * damping);
            
            // check if the target rotation has been reached
            if (transform.rotation.eulerAngles.z < 180f && transform.rotation.eulerAngles.z > 0f)
            {
                rb.angularDrag += 0.5f;
                // rb.angularVelocity = 0f; // stop the rotation
                if(rb.angularVelocity < 200){
                    blueCheck = false;
                    
                    Debug.Log("블루폴스");
                }
            }
            // }
        } else {
            rb.angularDrag = 5;
        }
        

        if (Input.GetKeyDown(KeyCode.B))
        {
          
                jump2Sword(-1);
            
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
            PlayerPrefs.SetInt("BestScore",Score.bestScore);
        }
        SceneManager.LoadScene("GameOverScene");
    }

    public void jump2Sword(int way = 1)
    {
        rb.angularVelocity = 0;
        blueCheck = true;
        Debug.Log("블루체크트루");
        float rotaPower = -50;
        rb.AddTorque(rotaPower * -1, ForceMode2D.Force);
        //rb.AddForce(Vector2.up * jumpPower, ForceMode2D.Force);

        //if(rb.velocity.y <= 0)
        //    rb.drag
        rb.velocity = Vector2.up * jumpPower;

    }

    public void jump3Sword(int way = 1)
    {
        rb.angularVelocity = 0;
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
