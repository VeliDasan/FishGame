using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonsterMovement2 : MonoBehaviour
{
    public Transform[] patrolPoints;
    public float moveSpeed;
    public int patrolDestination;

    public Transform playerTransform;
    public bool isChasing;
    public float chaseDistance;

    void Update()
    {
        if (isChasing)
        {
            Vector3 playerDirection = (playerTransform.position - transform.position).normalized;

            if (playerDirection.x > 0)
            {
                transform.localScale = new Vector3(-5, 5, 5);
            }
            else if (playerDirection.x < 0)
            {
                transform.localScale = new Vector3(5, 5, 5);
            }

            transform.position += playerDirection * moveSpeed * Time.deltaTime;
        }
        else
        {
            if (Vector3.Distance(transform.position, playerTransform.position) < chaseDistance)
            {
                isChasing = true;
            }

            if (patrolDestination == 0)
            {
                transform.position = Vector3.MoveTowards(transform.position, patrolPoints[0].position, moveSpeed * Time.deltaTime);
                if (Vector3.Distance(transform.position, patrolPoints[0].position) < .2f)
                {
                    transform.localScale = new Vector3(5, 5, 5);
                    patrolDestination = 1;
                }
            }
            else
            {
                transform.position = Vector3.MoveTowards(transform.position, patrolPoints[1].position, moveSpeed * Time.deltaTime);
                if (Vector3.Distance(transform.position, patrolPoints[1].position) < .2f)
                {
                    transform.localScale = new Vector3(-5, 5, 5);
                    patrolDestination = 0;
                }
            }
        }
    }
}
