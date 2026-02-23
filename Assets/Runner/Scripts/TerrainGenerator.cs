using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class TerrainGenerator : MonoBehaviour
{
    public static TerrainGenerator instance;
    [Header("Terrain Settings")]
    public List<GroundInformation> groundInformation;
    [SerializeField] private List<GroundInformation> allLuckGround;
    public float groundDistance = 1.5f;
    public int levelSize = 500;
    
    [Header("Optimisation Parameters")]
    public float timeToCreateNewElement = 0.2f;

    public List<GameObject> listElementInstanciate =  new List<GameObject>();
    [Tooltip("Nombre d'object instancier avant de reprendre de objects instancier")] 
    public int numberElementMinimal = 100;

    [Header("Terrain Statistics")]
    public int actualLevelSize;
    public int actualWalk;

    void Awake()
    {
        if (!instance)
        {
            instance = this;
        }
        else
        {
            Debug.LogError("TerrainGenerator instance already exists");
            Destroy(this);
        }
    }

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
            GameObject newInstantiate = Instantiate(randomGround.groundPrefab,  new Vector3(0, 0, actualLevelSize * groundDistance), Quaternion.identity);
            actualLevelSize++;
        }

        StartCoroutine(NewElement());
    }
    
    IEnumerator NewElement()
    {
        while (true)
        {
            yield return new WaitForSeconds(timeToCreateNewElement);

            if (!LevelManager.instance.isLevelUp)
            {
                if (listElementInstanciate.Count >= numberElementMinimal && listElementInstanciate.Count != 0)
                {
                    Debug.Log("Respawn Prefab !");
                    int indexRandom = Random.Range(0, listElementInstanciate.Count);
                    listElementInstanciate[indexRandom].transform.position = new Vector3(0, 0, actualLevelSize * groundDistance);
                    listElementInstanciate[indexRandom].SetActive(true);
                    listElementInstanciate.RemoveAt(indexRandom);
                }
                else
                {
                    GroundInformation randomGround = allLuckGround[Random.Range(0, allLuckGround.Count)];
                    Instantiate(randomGround.groundPrefab,  new Vector3(0, 0, actualLevelSize * groundDistance), Quaternion.identity);
                }
                actualWalk++;
            }
            else
            {
                Instantiate(LevelManager.instance.levelGroundPrefab, new Vector3(0, 0, actualLevelSize * groundDistance), Quaternion.identity);
            }
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