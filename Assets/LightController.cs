using UnityEngine;

public class LightController : MonoBehaviour
{
    [SerializeField] private Door door;
    [SerializeField] private AudioSource audioSource;
    [SerializeField] private AudioClip clickSound;

    private void OnMouseDown()
    {
        audioSource.PlayOneShot(clickSound); 
        door.ChangeLight();                  
    }
}
