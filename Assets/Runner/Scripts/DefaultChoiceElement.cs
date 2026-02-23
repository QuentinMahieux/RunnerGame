using System.Collections.Generic;
using UnityEngine;

public class DefaultChoiceElement : MonoBehaviour
{
    public bool isRandomized = true;
    public List<GameObject> choiceElements =  new List<GameObject>(3);
    [Range(0, 3)] public int numberElement = 1;

    [Header("Optimisation Settings")] 
    public float timeToDespawn = 10f;
    public float timeActual = 10f;
    void OnEnable()
    {
        timeActual = timeToDespawn;

        if (!isRandomized)
        {
            return;
        }
        for (int i = 0; i < choiceElements.Count; i++)
        {
            choiceElements[i].SetActive(false);
        }
        for (int i = 0; i < numberElement; i++)
        {
            choiceElements[Random.Range(0,3)].SetActive(true);
        }
    }

    void Update()
    {
        timeActual -= Time.deltaTime;
        if (timeActual < 0)
        {
            timeActual = timeToDespawn;
            TerrainGenerator.instance.listElementInstanciate.Add(gameObject);
            gameObject.SetActive(false);
        }
    }

    
}
