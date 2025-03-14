using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.ProBuilder.Shapes;

public class Scr_Orb : MonoBehaviour
{
    private Rigidbody rb;
    public GameObject endUI;
    private Vector3 pos;
    private Scr_Player_Movement playerScript;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        playerScript = GameObject.FindWithTag("Player").GetComponent<Scr_Player_Movement>();

        pos = transform.position;
    }

    public void gravity()
    {
        rb.useGravity = true;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            endLevel();
        }
    }

    public void endLevel()
    {
        Instantiate(endUI, pos, Quaternion.Euler(Vector3.zero));
        playerScript.playerCanMove = false;
        Time.timeScale = 0f;
        Destroy(gameObject);
    }
}
