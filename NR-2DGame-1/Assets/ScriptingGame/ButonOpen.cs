using UnityEngine;

public class ButonOpen : MonoBehaviour
{
    public HeroHealth target;

    [SerializeField] private GameObject buton;

    // �����, ������� ����� ���������� ��� ������� ������
    public void OnButtonClick()
    {
        Debug.Log("������ ������! ������� ����.");
        if (target != null)
        {
            target.TakeDamage(12.6f);
        }
        else
        {
            Debug.LogWarning("Target �� ����������!");
        }
    }
}
 