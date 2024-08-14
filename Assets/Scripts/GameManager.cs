using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    // Ссылки на UI-элементы
    public TMP_Text moneyCounter;          // Текстовый элемент для отображения текущего баланса игрока
    public TMP_Text upgradeLevelCounter;   // Текстовый элемент для отображения уровня апгрейда
    public Button clickButton;             // Кнопка, по которой нужно кликать для получения денег
    public Button upgradeButton;           // Кнопка для апгрейда, увеличивающего доход за клик

    // Внутренние параметры игры
    private int money = 0;                 // Текущий баланс игрока
    private int upgradeLevel = 1;          // Текущий уровень апгрейда
    private int incomePerClick = 1;        // Доход за один клик
    private int upgradeCost = 10;          // Стоимость следующего апгрейда

    // Метод инициализации, вызывается при старте игры
    void Start()
    {
        UpdateUI(); // Обновляем интерфейс при старте

        // Добавляем слушатели на кнопки
        upgradeButton.onClick.AddListener(OnUpgradeButtonClick);
        clickButton.onClick.AddListener(OnClickButtonPress);
    }

    // Метод, вызываемый при нажатии на центральную кнопку
    void OnClickButtonPress()
    {
        money += incomePerClick; // Увеличиваем баланс игрока на сумму дохода за клик
        UpdateUI();              // Обновляем интерфейс

        SpawnBill(); // Создаем анимацию купюры
    }

    // Метод, вызываемый при нажатии на кнопку апгрейда
    void OnUpgradeButtonClick()
    {
        if (money >= upgradeCost) // Проверяем, достаточно ли денег для апгрейда
        {
            money -= upgradeCost; // Списываем деньги за апгрейд
            upgradeLevel++;       // Увеличиваем уровень апгрейда
            incomePerClick++;     // Увеличиваем доход за клик
            upgradeCost *= 2;     // Увеличиваем стоимость следующего апгрейда (в два раза)

            UpdateUI();           // Обновляем интерфейс
        }
    }

    // Метод обновления интерфейса
    void UpdateUI()
    {
        // Обновляем текстовые элементы интерфейса
        moneyCounter.text = "Money: $" + money;
        upgradeLevelCounter.text = "Level: " + upgradeLevel;

        // Обновляем текст на кнопке апгрейда
        upgradeButton.GetComponentInChildren<TMP_Text>().text = $"Upgrade: ${upgradeCost}";

        // Обновляем текст на кнопке клика
        clickButton.GetComponentInChildren<TMP_Text>().text = $"+{incomePerClick}";

        // Проверяем, достаточно ли денег для апгрейда и обновляем состояние кнопки апгрейда
        upgradeButton.interactable = money >= upgradeCost;
    }

    // Метод для спавна и анимации купюры
    void SpawnBill()
    {
        GetComponent<BillController>().CreateBill();
    }
}
