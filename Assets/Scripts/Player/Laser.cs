using UnityEngine;

public class Laser : MonoBehaviour
{

    private void Update()
    {
        // ����� �����
        float movementSpeed =Constants.Laser_speed * Time.deltaTime;
        transform.Translate(Vector3.up * movementSpeed);

        // �� ������ ���� ������� ����, ���� ����
        if (!IsInBounds())
        {
            Deactivate();
        }
    }

    private void Deactivate()
    {
        gameObject.SetActive(false);
    }

    private bool IsInBounds()
    {
        // ����� �� ������ ����� ������� ����
        Vector3 viewportPosition = Camera.main.WorldToViewportPoint(transform.position);
        return viewportPosition.y >= 0 && viewportPosition.y <= 1;
    }
}
