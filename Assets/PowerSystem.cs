using TMPro;
using UnityEngine;

public class PowerSystem : MonoBehaviour
{
    public int systemsOn;
    public float power = 100;
    [SerializeField] private TextMeshProUGUI powerText;
    
    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (systemsOn < 0)
        {
            systemsOn = 0;
        }
        if (systemsOn == 1)
        {
            power -= 0.1f * Time.deltaTime;
        }
        else if (systemsOn == 2)
        {
            power -= 0.5f * Time.deltaTime;
        }
        else if (systemsOn == 3)
        {
            power -= 1.0f * Time.deltaTime;
        }
        else if (systemsOn == 4)
        {
           power -= 1.5f * Time.deltaTime; 
        }
        else if (systemsOn == 5)
        {
            power -= 2.0f * Time.deltaTime;
        }
        var powerString = string.Format("{0:0}%", power);
        powerText.text = powerString;
    }
}
