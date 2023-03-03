using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SwordFly : MonoBehaviour
{
    Rigidbody2D rb;
    public float jumpPower;
    public float rotationPower;
    private bool blueCheck = false;
    
    // Start is called before the first frame update
    void Start()
    {
        #if UNITY_IOS || UNITY_ANDROID
            Application.targetFrameRate = 300;
        #else
            QualitySettings.vSyncCount = 1;
        #endif

        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetMouseButtonDown(0)){
            GetComponent<AudioSource>().Play();
            jumpSword();
        }
    }

    void FixedUpdate()
    {
        if (blueCheck)
        {
            if (transform.rotation.eulerAngles.z < 180f && transform.rotation.eulerAngles.z > 0f)
            {
                rb.angularDrag += 1.5f;
                if (rb.angularVelocity < 200)
                {
                    blueCheck = false;
                    Debug.Log("블루폴스");
                }
            }
        }
        else
        {
            rb.angularDrag = 5;
        }
    }

    public void jumpSword(int way = 1)
    {
        rb.angularVelocity = 0;
        float rotaPower = rotationPower + Random.Range(-10f,11f);
        rb.AddTorque(rotaPower * way, ForceMode2D.Force);
        rb.velocity = Vector2.up * jumpPower;
    }

    private void OnCollisionEnter2D(Collision2D other) {
        if(Score.score > Score.bestScore){
            Score.bestScore = Score.score;
            PlayerPrefs.SetInt("BestScore",Score.bestScore);
        }
        SceneManager.LoadScene("GameOverScene");
    }

    public void hitJumpSword(int way = 1)
    {
        rb.angularVelocity = 0;
        blueCheck = true;
        Debug.Log("블루체크트루");
        float rotaPower = -50;
        rb.AddTorque(rotaPower * -1, ForceMode2D.Force);
        rb.velocity = Vector2.up * jumpPower;
    }
}
