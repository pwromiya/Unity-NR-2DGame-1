using UnityEngine;

public class HeroHealth : MonoBehaviour
{
    public float currentHealth;
    public float maxHealth = 100f;
  
    public Sprite[] frames;
    private SpriteRenderer sr;

    void Start()
    {
        currentHealth = maxHealth;
        sr = GetComponent<SpriteRenderer>();
    }


    void Update()
    {
        int index = Mathf.Clamp(7 - Mathf.FloorToInt(currentHealth / 12.5f), 0, 7);
        sr.sprite = frames[index];
    }
    public void TakeDamage(float amount)
    {
        currentHealth -= amount;
        currentHealth = Mathf.Clamp(currentHealth, 0f, 100f);
        Debug.Log("Çהמנמגüו: " + currentHealth);
    }
}
