using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SubTurret : MonoBehaviour
{
    [SerializeField] private Transform bulletPos;
    [SerializeField] private Transform target;
    [SerializeField] private float shootingDistance = 10.0f;

    public float shootingCooldown = 1.0f;
    private float shootingTimer = 0.0f;

    void Update()
    {
        // Ate� etme i�lemi
        shootingTimer -= Time.deltaTime;

        if (target != null)
        {
            float distanceToTarget = Vector3.Distance(transform.position, target.position);
            if (distanceToTarget <= shootingDistance && shootingTimer <= 0.0f)
            {
                TryToShoot();
            }
        }
    }

    void TryToShoot()
    {
        GameObject bullet = SubPool.instance.GetObjectFromPool();
        if (bullet != null)
        {
            bullet.transform.position = bulletPos.position;
            bullet.transform.rotation = bulletPos.rotation;
            bullet.SetActive(true);

            shootingTimer = shootingCooldown;
        }
    }

    // Oyuncuyu taretin g�rmesi durumunda �a�r�lacak
    public void SetTarget(Transform newTarget)
    {
        target = newTarget;
    }

    // Taretin g�rmemesi durumunda �a�r�lacak
    public void ClearTarget()
    {
        target = null;
    }
}

