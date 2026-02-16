using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerRunner : MonoBehaviour
{
    public static PlayerRunner instance;
    public Rigidbody rb;
    [Header("Player Speed")]
    public float playerSpeed = 3f;
    
    [Header("Player Movement")]
    public float changeLine = 10f;
    public int actualLine = 1;
    public List<float> linePositionX = new List<float>();

    [Header("Other Information")] 
    public int goldNumber;

    void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }
    
    void Update()
    {
        rb.linearVelocity = playerSpeed * transform.forward;

        if (Input.GetKeyDown(KeyCode.LeftArrow))
        {
            if (actualLine > 0)
            {
                actualLine--;
            }
            ChangePlayerLine();
        }
        else if (Input.GetKeyDown(KeyCode.RightArrow))
        {
            if (actualLine < linePositionX.Count - 1)
            {
                actualLine++;
            }
            ChangePlayerLine();
        }
    }

    void ChangePlayerLine()
    {
        var vector3 = transform.localPosition;
        vector3.x = linePositionX[actualLine];
        transform.localPosition = vector3;
    }

    void OnTriggerEnter(Collider other)
    {
        Debug.Log(other.gameObject.name);
        if (other.CompareTag("Obstacle"))
        {
            Destroy(gameObject);
            //SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }
        else if (other.CompareTag("Gold"))
        {
            Destroy(other.gameObject);
            goldNumber++;
        }
    }
   
}
