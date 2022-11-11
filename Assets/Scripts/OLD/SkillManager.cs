// using System;
// using System.Collections.Generic;
// using UnityEngine;
//
// public class SkillManager : SingletonMonoBehavior<SkillManager>
// {
//     public List<BaseSkill> availableSkills = new List<BaseSkill>();
//     private List<BaseSkill> _currentActiveSkills = new List<BaseSkill>();
//     private PlayerCharacter _player;
//     
//     // public UIContainerUIAnimator container;
//
//     public SkillButtonUI skillButtonPrefab;
//     public Transform skillButtonSpawnTransform;
//     
//     private int _level = 1;
//     private int _currentExp = 0;
//     private int _nextExpToLevelUp = 25;
//
//     public void AddExp(int exp)
//     {
//         _currentExp += exp;
//         if (_currentExp > _nextExpToLevelUp * _level)
//         {
//             ShowAvailableSkills();
//             _currentExp = 0;
//             _level++;
//         }
//     }
//
//     public override void Awake()
//     {
//         base.Awake();
//         _player = GameObject.FindObjectOfType<PlayerCharacter>();
//     }
//
//     private void Start()
//     {
//         InitAvailableSkills();
//         ShowAvailableSkills();
//     }
//
//     public void InitAvailableSkills()
//     {
//         foreach (var sk in availableSkills)
//         {
//             var btn = Instantiate(skillButtonPrefab, skillButtonSpawnTransform);
//             btn.SkillToAdd = sk;
//             btn.Init();
//         }
//     }
//
//     public void AddSkill(BaseSkill skill)
//     {
//         var find = _currentActiveSkills.Find(x => x.skillName == skill.skillName);
//         if (find != null)
//         {
//             find.OnLevelUp();
//         }
//         else
//         {
//             var skillClone = Instantiate(skill, _player.transform);
//             _currentActiveSkills.Add(skillClone);
//         }
//
//         HideAvailableSkills();
//     }
//
//     public void ShowAvailableSkills()
//     {
//         container.Show();
//         Time.timeScale = 0;
//     }
//
//     public void HideAvailableSkills()
//     {
//         container.Hide();
//         Time.timeScale = 1f;
//     }
// }