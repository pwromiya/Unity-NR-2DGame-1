using UnityEngine;

public class ButonOpen : MonoBehaviour
{
    public HeroHealth target;

    [SerializeField] private GameObject buton;

    // Метод, который будет вызываться при нажатии кнопки
    public void OnButtonClick()
    {
        Debug.Log("Кнопка нажата! Наносим урон.");
        if (target != null)
        {
            target.TakeDamage(12.6f);
        }
        else
        {
            Debug.LogWarning("Target не установлен!");
        }
    }
}
 