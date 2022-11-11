using UnityEngine;

[CreateAssetMenu(menuName = "Character/Character Data", fileName = "Character data")]
public class CharacterData : ScriptableObject
{
    [Header("Character Description")]
    public string characterName;
    [TextArea(5, 10)]
    public string description;
    
    [Header("Base Status")] 
    public int baseHealth;
    public int baseDamage;
    public float baseSpeed;
    public float baseRotate;

    [Header("Game Object")] 
    public GameObject characterPrefab;
}
