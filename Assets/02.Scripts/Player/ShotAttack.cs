using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShotAttack : MonoBehaviour
{
    private Rigidbody2D _rigid;

    [SerializeField]
    private float _speed = 5f;

    private void Awake()
    {
        _rigid = GetComponent<Rigidbody2D>();
    }

    private void FixedUpdate()
    {
        _rigid.MovePosition(transform.position + transform.right * _speed * Time.fixedDeltaTime);
    }
}
