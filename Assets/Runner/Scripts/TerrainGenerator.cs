using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TerrainGenerator : MonoBehaviour
{
    [Header("Terrain Settings")]
    public List<GroundInformation> groundInformation;
    [SerializeField] private List<GroundInformation> allLuckGround;
    public float groundDistance = 1.5f;
    public int levelSize = 500;
    public int actualLevelSize;
    
    [Header("Optimisation Parameters")]
    public float timeToCreateNewElement = 0.2f;

    void Start()
    {
        allLuckGround = new List<GroundInformation>();
        for (int i = 0; i < groundInformation.Count; i++)
        {
            for (int j = 0; j < groundInformation[i].ratioSpawn; j++)
            {
                allLuckGround.Add(groundInformation[i]);
            }
        }
        for (int i = 0; i < levelSize; i++)
        {
            GroundInformation randomGround = allLuckGround[Random.Range(0, allLuckGround.Count)];
            Instantiate(randomGround.groundPrefab,  new Vector3(0, 0, actualLevelSize * groundDistance), Quaternion.identity);
            actualLevelSize++;
        }

        StartCoroutine(NewElement());
    }
    
    IEnumerator NewElement()
    {
        while (true)
        {
            yield return new WaitForSeconds(timeToCreateNewElement);
            GroundInformation randomGround = allLuckGround[Random.Range(0, allLuckGround.Count)];
            Instantiate(randomGround.groundPrefab,  new Vector3(0, 0, actualLevelSize * groundDistance), Quaternion.identity);
            actualLevelSize++;
        }
        
    }

}
[System.Serializable]
public class GroundInformation
{
    public GameObject groundPrefab;
    [Range(0, 100)]
    public int ratioSpawn = 25;

}