using UnityEngine;

public class DoorController : MonoBehaviour
{
   [SerializeField] private Door door;
   [SerializeField] private PowerSystem power;
   [SerializeField] private AudioSource audioSource;
   [SerializeField] private AudioClip openSound;
   private void OnMouseDown()
   {
      door.isOpen = !door.isOpen;
      if (door.isOpen)
      {
         power.systemsOn -= 1;
         audioSource.PlayOneShot(openSound);
      }
      else
      {
         power.systemsOn += 1;
         audioSource.PlayOneShot(openSound);
      }
   } 
}
