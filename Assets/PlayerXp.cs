using UnityEngine;
using UnityEngine.UI;

public class PlayerXP : MonoBehaviour
{
    public Slider xpSlider;
    public int xpAmount = 5;
    public GameObject levelUpPanel;

    private int currentXP = 0;
    private int maxXP = 100;

    void Start()
    {
        xpSlider.maxValue = maxXP;
        xpSlider.value = currentXP;
        levelUpPanel.SetActive(false);
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("XP"))
        {
            CollectXP();
            Destroy(collision.gameObject);
        }
    }

    void CollectXP()
    {
        currentXP += xpAmount;
        xpSlider.value = currentXP;

        if (currentXP >= maxXP)
        {
            LevelUp();
        }
    }

    void LevelUp()
    {
        Time.timeScale = 0f;
        levelUpPanel.SetActive(true);
        currentXP = 0;
        xpSlider.value = currentXP;
    }

    public void SelectSpecial()
    {
        Time.timeScale = 1f;
        levelUpPanel.SetActive(false);
        //özellik veya silah seçmek için gerekli dizinler lazým
    }
}
