using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttack : MonoBehaviour
{
    #region Attack1
    public Transform attack1Pos;
    public GameObject attack1Prefab;
    private float _desireAngle;
    #endregion

    public bool _isAttack1 = false;

    private void Awake()
    {
    }

    private void Update()
    {
        Attack();       
    }

    public virtual void AimWeapon(Vector2 pointerPos)
    {
        Vector3 aimDirection = (Vector3)pointerPos - transform.position; //마우스 방향 벡터 구하기

        _desireAngle = Mathf.Atan2(aimDirection.y, aimDirection.x) * Mathf.Rad2Deg; //디그리 각도를 구한다

        transform.rotation = Quaternion.AngleAxis(_desireAngle, Vector3.forward); //z축 기준으로 회전
    }

    private void Attack()
    {
        if (Input.GetKeyDown(KeyCode.Q))
        {
            _isAttack1 = true;
        }

        if (_isAttack1 && Input.GetMouseButtonDown(0))
        {
            StartCoroutine(Attack1());
        }
    }

    private IEnumerator Attack1()
    {
        Instantiate(attack1Prefab, attack1Pos);
        _isAttack1 = false;
        yield return null;
    }
}
