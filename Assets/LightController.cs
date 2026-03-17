using UnityEngine;

public class LightController : MonoBehaviour
{
    [SerializeField] private Door door;
    private void OnMouseDown()
    {
        door.ChangeLight();
    } 
}
