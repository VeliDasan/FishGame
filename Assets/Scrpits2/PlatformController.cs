using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformController : MonoBehaviour
{
    public Transform downPos, upperPos;
    public float speed;
    public Transform player;
    public Transform elevatorSwitch;
    bool isElevatorDown;
    bool isPlayerOnPlatform;

    private void Start()
    {
        isElevatorDown = true;
        isPlayerOnPlatform = false;
    }

    private void Update()
    {
        CheckElevatorActivation();

        if (isPlayerOnPlatform)
        {
            MovePlatform();
            MovePlayerWithPlatform();
        }
    }

    private void CheckElevatorActivation()
    {
        if (Vector2.Distance(player.position, elevatorSwitch.position) < 0.5f && Input.GetKeyDown(KeyCode.F))
        {
            isPlayerOnPlatform = true;
            isElevatorDown = !isElevatorDown;
        }
    }

    private void MovePlatform()
    {
        Vector3 targetPos = isElevatorDown ? downPos.position : upperPos.position;
        transform.position = Vector3.MoveTowards(transform.position, targetPos, speed * Time.deltaTime);

        // Platform hedefe ulaþtýðýnda hareketi durdur
        if (Vector3.Distance(transform.position, targetPos) < 0.05f)
        {
            isPlayerOnPlatform = false;
        }
    }

    private void MovePlayerWithPlatform()
    {
        if (player != null)
        {
            Vector3 platformMovement = transform.position - player.transform.position;
            player.transform.position += platformMovement;
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player2"))
        {
            isPlayerOnPlatform = true;
            collision.transform.parent = transform;
        }
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player2"))
        {
            isPlayerOnPlatform = false;
            collision.transform.parent = null;
        }
    }
}