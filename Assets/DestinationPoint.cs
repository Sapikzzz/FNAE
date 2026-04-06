using UnityEngine;

public class DestinationPoint : MonoBehaviour
{
   [SerializeField] private int[] destinationPoints; // Points that are available for the enemy

   public bool isDoor;
   public bool isOffice;

   public Door door;
}
