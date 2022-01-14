using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAi : MonoBehaviour
{
    [SerializeField] Vector2 StartPos;
    [SerializeField] float radius = 15f;
    [SerializeField] CircleCollider2D EnemyColl;
    [SerializeField] LayerMask PlayerL;
    [SerializeField] Rigidbody2D EnemyRig;
    [SerializeField] Transform player;
    [SerializeField] float MoveSpeed = 1.5f;

    void Awake()
    {
        StartPos = transform.position;
        EnemyRig = GetComponent<Rigidbody2D>();
        EnemyColl = GetComponent<CircleCollider2D>();
        EnemyColl.radius = radius;
    }

    // Update is called once per frame
    void Update()
    {
        if(EnemyColl.IsTouchingLayers(PlayerL))
        {
            Vector2 Velocity = new Vector2((transform.position.x - player.position.x) * MoveSpeed, (transform.position.y - player.position.y) * MoveSpeed);
            EnemyRig.velocity = -Velocity;
        }
        else
        {
            StartCoroutine(GetToStartPos(1));
        }
    }
    IEnumerator GetToStartPos(float time)
    {
        yield return new WaitForSeconds(time);
        Vector2 Velocity = new Vector2(transform.position.x - StartPos.x, transform.position.y - StartPos.y);
        EnemyRig.velocity = -Velocity;
    }
}
