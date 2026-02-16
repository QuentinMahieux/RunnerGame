using System.Collections.Generic;
using UnityEngine;

public class DefaultChoiceElement : MonoBehaviour
{
    public List<GameObject> choiceElements =  new List<GameObject>(3);
    [Range(0, 3)] public int numberElement = 1;
    void Start()
    {
        for (int i = 0; i < choiceElements.Count; i++)
        {
            choiceElements[i].SetActive(false);
        }
        for (int i = 0; i < numberElement; i++)
        {
            choiceElements[Random.Range(0,3)].SetActive(true);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
