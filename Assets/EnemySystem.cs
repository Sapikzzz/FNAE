using UnityEngine;
using UnityEngine.AI;

public class EnemySystem : MonoBehaviour
{
    [SerializeField] private NavMeshAgent NMA;
    [SerializeField] private GameObject[] targets;
    [SerializeField] private int currentTarget;

    [SerializeField] private float cooldownTimer;
    [SerializeField] private int minCooldownTime;
    [SerializeField] private int maxCooldownTime;
    
    [SerializeField] private int minChanceToMove = 1;
    [SerializeField] private int maxChanceToMove = 20;

    [SerializeField] private int thresholdToPass = 3;

    [SerializeField] private int[] AggresionByHour;
    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        NMA = GetComponent<NavMeshAgent>();
    }

    // Update is called once per frame
    void Update()
    {
        if (cooldownTimer <= 0){
            var chanceCheck = Random.Range(minChanceToMove, maxChanceToMove);
            if (chanceCheck <= thresholdToPass)
            {
                if (!NMA.pathPending && NMA.remainingDistance <= NMA.stoppingDistance)
                {
                    if (targets[currentTarget].GetComponent<DestinationPoint>().isDoor)
                    {
                        if (targets[currentTarget].GetComponent<DestinationPoint>().door.isOpen)
                        {
                            currentTarget = targets.Length - 1;
                        }
                        else
                        {
                            currentTarget = 1;
                        }
                    }
                    // need to change enemy movement to random weighted movement
                    else
                    {
                        currentTarget += 1;
                        if (currentTarget >= targets.Length)
                        {
                            currentTarget = 0;
                        }
                    }
                }
            }
            var cooldownTime = Random.Range(minCooldownTime, maxCooldownTime);
            cooldownTimer = cooldownTime;
        }
        else
        {
            cooldownTimer -= Time.deltaTime;
        }
        if (targets[currentTarget].GetComponent<DestinationPoint>().isOffice)
        {
            Debug.Log("you died"); //jumpscare place
        }
        NMA.destination = targets[currentTarget].transform.position;
    }

    public void ChangeAggressionByHour(int hour)
    {
        thresholdToPass = AggresionByHour[hour];   
    }
}
