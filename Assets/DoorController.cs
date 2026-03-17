using UnityEngine;

public class DoorController : MonoBehaviour
{
   [SerializeField] private Door door;
   private void OnMouseDown()
   {
      door.isOpen = !door.isOpen;
   } 
}
