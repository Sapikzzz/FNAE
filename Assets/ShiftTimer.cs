using TMPro;
using UnityEngine;

public class ShiftTimer : MonoBehaviour
{
    [SerializeField] private float timer;
    [SerializeField] private int shiftEndTime = 6;
    [SerializeField] private string digitalClock;
    [SerializeField] private bool gameWon = false;
    
    [SerializeField] private float timeMultiplier = 2f;

    [SerializeField] private TextMeshProUGUI clockText;

    [SerializeField] private GameObject winScreen;

    [SerializeField] private EnemySystem[] enemies;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        digitalClock = "";
    }

    // Update is called once per frame
    void Update()
    {
        if (!gameWon)
        {
            timer += Time.deltaTime * timeMultiplier;
            var hours = Mathf.FloorToInt(timer / 60);
            var minutes = Mathf.FloorToInt(timer - hours * 60);

            if (minutes == 0)
            {
                for (int i = 0; i < enemies.Length; i++)
                {
                    enemies[i].ChangeAggressionByHour(hours);
                }
            }

            if (hours >= shiftEndTime)
            {
                winScreen.SetActive(true);
                gameWon = true;
            }        
        
            digitalClock = string.Format("{0:00}:{1:00}", hours, minutes);
        
            clockText.text = digitalClock;
        } 
    }
}
