using System.Collections;
using System.Collections.Generic;
using UnityEditor.AppleTV;
using UnityEngine;

public class EnemyAttacks : MonoBehaviour
{
    [SerializeField]
    Transform playerTransform;
    Transform gunTransform;
    float maxDistanceToTarget = 6f;
    float distanceToTarget;

    [SerializeField]
    float rawDamage = 10f;

    [SerializeField]
    float delayTimer = 2f;
    float tick;
    bool attackReady = true;

    // Start is called before the first frame update
    void Start()
    {
        tick = delayTimer;
        gunTransform = gameObject.transform.Find("Gun");
    }

    // Update is called once per frame
    void Update()
    {
        Attack();
    }

    bool IsReadyToAttack()
    {
        if (tick < delayTimer)
        {
            tick += Time.deltaTime;
            return false;
        }
    }

    void LookAtTarget()
    {
        Vector3 lookVector = playerTransform.position - transform.position;
        lookVector.y = transform.position.y;
        Quaternion rotation = Quaternion.LookRotation(lookVector);
        transform.rotation = Quaternion.Slerp(transform.rotation, rotation, 0.1f);
    }

    void Attack()
    {
        distanceToTarget = Vector3.Distance(playerTransform.position, gunTransform.position);
        attackReady = IsReadyToAttack();

        if (distanceToTarget <= maxDistanceToTarget)
        {
            LookAtTarget();

            if (attackReady)
            {
                tick = 0f;
                
            }
        }
    }
}
