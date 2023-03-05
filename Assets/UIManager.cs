using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;
using UnityEngine.SceneManagement;

public class UIManager : MonoBehaviour
{
    public GameObject pause;
    public static bool isPause;

    public void QuitApp(){  //나가기
        Application.Quit();  //나가기
        Debug.Log("quit");
    }

    void Start()
    {
        isPause = false;        //일시정지되었는지 확인합니다
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Escape)){  //뒤로가기/ESC 누를 시 일시정지
            PauseGame();
        }
    }

    public void PauseGame()
    {
        isPause = true;
        Time.timeScale = 0;
        pause.SetActive(true);
    }

    public void ResumeGame()
    {
        isPause = false;
        Time.timeScale = 1;
        pause.SetActive(false);
    }
}

