using UnityEngine;
using DG.Tweening;

public class Kup : MonoBehaviour
{
    private Vector3 offset;
    private bool isDragging = false;
    private float delay = 0.5f; // Hareket gecikme süresi (0.5 saniye)

    private void OnMouseDown()
    {
        if (Input.GetMouseButtonDown(0))
        {
            offset = transform.position - GetMouseWorldPosition();
            isDragging = true;
        }
    }

    private void OnMouseDrag()
    {
        if (isDragging)
        {
            // Mouse pozisyonunu alýn ve objeyi sürüklerken offset'i kullanarak yeni pozisyonu ayarlayýn.
            Vector3 targetPosition = GetMouseWorldPosition() + offset;
            transform.DOMove(new Vector3(targetPosition.x, targetPosition.y, transform.position.z), delay);
        }
    }

    private Vector3 GetMouseWorldPosition()
    {
        Vector3 mousePoint = Input.mousePosition;
        mousePoint.z = transform.position.z - Camera.main.transform.position.z;
        return Camera.main.ScreenToWorldPoint(mousePoint);
    }
}