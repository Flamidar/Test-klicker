using UnityEngine;

public class BillController : MonoBehaviour
{
    public GameObject billPrefab;  // ������ ������
    public Transform clickButtonTransform; // ������� ����������� ������

    public void CreateBill()
    {
        // ������� ������ �� ����� ������� �� ������
        GameObject bill = Instantiate(billPrefab, clickButtonTransform.transform.position, Quaternion.identity);
        Rigidbody2D rb = bill.GetComponent<Rigidbody2D>();

        // ��������� ����������� � ���� ������ ������
        Vector2 forceDirection = new Vector2(Random.Range(-1f, 1f), 1f).normalized;
        float forceMagnitude = Random.Range(4f, 10f);
        rb.AddForce(forceDirection * forceMagnitude, ForceMode2D.Impulse);

        // ��������� �������� ������
        float torque = Random.Range(-100f, 100f);
        rb.AddTorque(torque);

        // ���������� ������ ����� ����, ��� ��� ���������� �� �������
        Destroy(bill, 5f);
    }
}
