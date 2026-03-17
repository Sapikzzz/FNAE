using UnityEngine;

public class Door : MonoBehaviour
{
    [SerializeField] private GameObject Light;

    [SerializeField] private Vector3 openPos;
    [SerializeField] private Vector3 closedPos;

    [SerializeField] private float doorSpeed = 5f;
    
    public bool isOpen;
    public bool isOn;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        transform.position = openPos;
        isOpen = true;
        
        ChangeLight();
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 target = isOpen ? openPos : closedPos;
        if (Vector3.Distance(transform.position, target) > 0.01f)
        {
            transform.position = Vector3.Lerp(transform.position, target, doorSpeed * Time.deltaTime);
        }
        else
        {
            transform.position = target;
        } 
    }

    public void ChangeLight()
    {
        isOn = !isOn;

        if (isOn)
        {
            Light.SetActive(true);
        }
        else
        {
            Light.SetActive(false);
        }
    }
}
