using UnityEngine;

public class BillController : MonoBehaviour
{
    public GameObject billPrefab;  // Префаб купюры
    public Transform clickButtonTransform; // Позиция центральной кнопки

    public void CreateBill()
    {
        // Создаем купюру на месте нажатия на кнопку
        GameObject bill = Instantiate(billPrefab, clickButtonTransform.transform.position, Quaternion.identity);
        Rigidbody2D rb = bill.GetComponent<Rigidbody2D>();

        // Случайное направление и сила полета купюры
        Vector2 forceDirection = new Vector2(Random.Range(-1f, 1f), 1f).normalized;
        float forceMagnitude = Random.Range(4f, 10f);
        rb.AddForce(forceDirection * forceMagnitude, ForceMode2D.Impulse);

        // Случайное вращение купюры
        float torque = Random.Range(-100f, 100f);
        rb.AddTorque(torque);

        // Уничтожаем купюру после того, как она скрывается за экраном
        Destroy(bill, 5f);
    }
}
