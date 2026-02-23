using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
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

    [Header("Player Movement Mobile")] 
    private Vector2 startTouchPosition;
    private Vector2 endTouchPosition;

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

        //Mobile Controller
        if (Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Began)
        {
            startTouchPosition = Input.GetTouch(0).position;
        }

        if (Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Ended)
        {
            endTouchPosition = Input.GetTouch(0).position;

            if (endTouchPosition.x > startTouchPosition.x)
            {
                if (actualLine < linePositionX.Count - 1)
                {
                    actualLine++;
                }
                ChangePlayerLine();
            }
            else if (endTouchPosition.x < startTouchPosition.x)
            {
                if (actualLine > 0)
                {
                    actualLine--;
                }
                ChangePlayerLine();
            }
        }
        
        //PC Controller
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
        if (other.CompareTag("Obstacle"))
        {
            Destroy(gameObject);
            //SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }
        else if (other.CompareTag("Gold"))
        {
            other.gameObject.SetActive(false);
            goldNumber++;
        }
    }
}
