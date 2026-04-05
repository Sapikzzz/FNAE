using UnityEngine;

public class DoorController : MonoBehaviour
{
   [SerializeField] private Door door;
   [SerializeField] private PowerSystem power;
   private void OnMouseDown()
   {
      door.isOpen = !door.isOpen;
      if (door.isOpen)
      {
         power.systemsOn -= 1;
      }
      else
      {
         power.systemsOn += 1;
      }
   } 
}
