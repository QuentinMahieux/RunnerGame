using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class ChoiceUpgrade : MonoBehaviour
{
    public Image icon;
    public TMP_Text priceText;
    
    [Header("Data")]
    public PowerUp actualPowerUp;
    
    public void Instanciate(PowerUp newPowerUp)
    {
        actualPowerUp = newPowerUp;
        
        icon.sprite = newPowerUp.icon;
        priceText.text = newPowerUp.price.ToString();
    }

    public void BuyLevelUp()
    {
        if (PlayerRunner.instance.goldNumber >= actualPowerUp.price)
        {
            PlayerRunner.instance.goldNumber -= actualPowerUp.price;
            
            LevelManager.instance.EndLevelUp();
        }
    }
    
    
}
