using UnityEngine;

[CreateAssetMenu(fileName = "PowerUp", menuName = "Scriptable Objects/PowerUp")]
public class PowerUp : ScriptableObject
{
    [Header("UI Elements")]
    public string name;
    public string description;
    
    public Sprite icon;
    
    [Header("Price")]
    public int price;
    
}
