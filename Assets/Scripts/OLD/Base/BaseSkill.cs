using UnityEngine;

public abstract class BaseSkill : MonoBehaviour
{
    public int level = 1;
    public string skillName;
    public string SkillDescription;
    
    public abstract void Action();

    public abstract void OnLevelUp();
}