using System;
using UnityEngine;
using UnityEngine.UI;

public abstract class BaseCharacter : MonoBehaviour
{
    [Header("Dependencies")]
    [SerializeField] protected CharacterController characterController;
    [SerializeField] protected Animator charAnimator;

    [Header("Status")] 
    [SerializeField] protected int baseHealth = 100;
    [SerializeField] protected int currentHealth;
    
    [SerializeField] protected int baseDamage = 10;
    
    [SerializeField] protected float movementSpeed = 10f;
    [SerializeField] protected float rotationSpeed = 180f;

    public GameObject healthCanvas;
    public Image healthFill;
    public Gradient healthFillColor;
    public event Action OnUpdateUI;

    public bool isDead = false;

    public abstract void Move();
    public abstract void OnDead();

    private void OnEnable()
    {
        currentHealth = baseHealth;
        isDead = false;

        OnUpdateUI += UpdateUI;
        
        UpdateUI();
    }

    private void OnDisable()
    {
        OnUpdateUI -= UpdateUI;
    }

    public virtual void TakeDamage(int damageAmount)
    {
        OnUpdateUI?.Invoke();
        currentHealth -= damageAmount;
        if (currentHealth <= 0)
        {
            OnUpdateUI?.Invoke();
            currentHealth = 0;
            if (!isDead)
            {
                OnDead();
                isDead = true;
            }
        }
    }

    public virtual void Heal(int healAmount)
    {
        currentHealth += healAmount;
        if (currentHealth > baseHealth) currentHealth = baseHealth;
    }
    
    protected virtual void Update()
    {
        Move();
        healthCanvas.transform.LookAt(Camera.main.transform.position);
    }

    public void UpdateUI()
    {
        healthFill.fillAmount = (float)currentHealth / (float)baseHealth;
        healthFill.color = healthFillColor.Evaluate(healthFill.fillAmount);
    }
}
