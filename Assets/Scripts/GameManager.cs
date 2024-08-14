using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    // ������ �� UI-��������
    public TMP_Text moneyCounter;          // ��������� ������� ��� ����������� �������� ������� ������
    public TMP_Text upgradeLevelCounter;   // ��������� ������� ��� ����������� ������ ��������
    public Button clickButton;             // ������, �� ������� ����� ������� ��� ��������� �����
    public Button upgradeButton;           // ������ ��� ��������, �������������� ����� �� ����

    // ���������� ��������� ����
    private int money = 0;                 // ������� ������ ������
    private int upgradeLevel = 1;          // ������� ������� ��������
    private int incomePerClick = 1;        // ����� �� ���� ����
    private int upgradeCost = 10;          // ��������� ���������� ��������

    // ����� �������������, ���������� ��� ������ ����
    void Start()
    {
        UpdateUI(); // ��������� ��������� ��� ������

        // ��������� ��������� �� ������
        upgradeButton.onClick.AddListener(OnUpgradeButtonClick);
        clickButton.onClick.AddListener(OnClickButtonPress);
    }

    // �����, ���������� ��� ������� �� ����������� ������
    void OnClickButtonPress()
    {
        money += incomePerClick; // ����������� ������ ������ �� ����� ������ �� ����
        UpdateUI();              // ��������� ���������

        SpawnBill(); // ������� �������� ������
    }

    // �����, ���������� ��� ������� �� ������ ��������
    void OnUpgradeButtonClick()
    {
        if (money >= upgradeCost) // ���������, ���������� �� ����� ��� ��������
        {
            money -= upgradeCost; // ��������� ������ �� �������
            upgradeLevel++;       // ����������� ������� ��������
            incomePerClick++;     // ����������� ����� �� ����
            upgradeCost *= 2;     // ����������� ��������� ���������� �������� (� ��� ����)

            UpdateUI();           // ��������� ���������
        }
    }

    // ����� ���������� ����������
    void UpdateUI()
    {
        // ��������� ��������� �������� ����������
        moneyCounter.text = "Money: $" + money;
        upgradeLevelCounter.text = "Level: " + upgradeLevel;

        // ��������� ����� �� ������ ��������
        upgradeButton.GetComponentInChildren<TMP_Text>().text = $"Upgrade: ${upgradeCost}";

        // ��������� ����� �� ������ �����
        clickButton.GetComponentInChildren<TMP_Text>().text = $"+{incomePerClick}";

        // ���������, ���������� �� ����� ��� �������� � ��������� ��������� ������ ��������
        upgradeButton.interactable = money >= upgradeCost;
    }

    // ����� ��� ������ � �������� ������
    void SpawnBill()
    {
        GetComponent<BillController>().CreateBill();
    }
}
