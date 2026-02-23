using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LevelManager : MonoBehaviour
{
    public static LevelManager instance;
    [Tooltip("Nombre de pas avant le levelUp")] 
    
    [Header("LevelUp Parameters")]
    public float levelUpWalk = 1000;
    public bool isLevelUp = false;
    public GameObject levelGroundPrefab;
    
    public List<PowerUp> listPowerUp;
    
    [Header("UI Elements")]
    public GameObject levelUpUI;
    public List<ChoiceUpgrade> listLevelUpChoice;
    void Awake()
    {
        if (!instance)
        {
            instance = this;
        }
        else
        {
            Debug.LogError("There is more than one instance of LevelManager");
            Destroy(this);
        }
    }

    void Start()
    {
        EndLevelUp();
    }

    void Update()
    {
        if (levelUpWalk <= TerrainGenerator.instance.actualWalk && !isLevelUp)
        {
            levelUpWalk *= 1.5f;
            isLevelUp = true;
            StartCoroutine(NewLevel());
        }
    }

    IEnumerator NewLevel()
    {
        yield return new WaitForSeconds(4);
        levelUpUI.SetActive(true);
        List<PowerUp> localListPowerUp = new List<PowerUp>(listPowerUp);
        for (int i = 0; i < listLevelUpChoice.Count; i++)
        {
            int indexRandom = Random.Range(0, localListPowerUp.Count);
            listLevelUpChoice[i].Instanciate(localListPowerUp[indexRandom]);
            listLevelUpChoice.RemoveAt(indexRandom);
        }
    }

    public void EndLevelUp()
    {
        levelUpUI.SetActive(false);
        isLevelUp = false;
    }
}
