using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Scr_Check_Point : MonoBehaviour
{
    public GameObject player;
    private Transform playerTransform;
    private Scr_Player_Animations playerAnim;
    public Transform checkPoint1;
    public Transform checkPoint2;

    public bool C1;
    public bool C2;

    private void Awake()
    {
        playerTransform = player.GetComponent<Transform>();
        playerAnim = player.GetComponentInChildren<Scr_Player_Animations>();
    }

    private void Start()
    {
        LoadCheckPointState();
        checkPointRespawn();
    }

    private void Update()
    {
        if (playerAnim.restart)
        {
            SaveCheckPointState();
            RestartScene();
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            changCheckPoint();
        }
    }

    private void OnApplicationQuit()
    {
        C1 = true;
        C2 = false;
        SaveCheckPointState();
    }

    private void RestartScene()
    {
        int currentSceneIndex = SceneManager.GetActiveScene().buildIndex;
        SceneManager.LoadScene(currentSceneIndex);
    }

    public void checkPointRespawn()
    {
        if (C1)
        {
            playerTransform.position = checkPoint1.position;
        }

        if (C2)
        {
            playerTransform.position = checkPoint2.position;
        }
    }

    public void changCheckPoint()
    {
        C1 = false;
        C2 = true;
    }

    private void SaveCheckPointState()
    {
        PlayerPrefs.SetInt("C1", C1 ? 1 : 0);
        PlayerPrefs.SetInt("C2", C2 ? 1 : 0);
        PlayerPrefs.Save();
    }

    private void LoadCheckPointState()
    {
        C1 = PlayerPrefs.GetInt("C1", 0) == 1;
        C2 = PlayerPrefs.GetInt("C2", 0) == 1;
    }
}
