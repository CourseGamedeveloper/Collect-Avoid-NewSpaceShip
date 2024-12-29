using UnityEngine;

public class Laser : MonoBehaviour
{

    private void Update()
    {
        // תנועה למעלה
        float movementSpeed =Constants.Laser_speed * Time.deltaTime;
        transform.Translate(Vector3.up * movementSpeed);

        // אם הלייזר יוצא מגבולות המסך, השבת אותו
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
        // בדיקה אם הלייזר עדיין בגבולות המסך
        Vector3 viewportPosition = Camera.main.WorldToViewportPoint(transform.position);
        return viewportPosition.y >= 0 && viewportPosition.y <= 1;
    }
}
