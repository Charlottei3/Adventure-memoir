using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MeleeEnemyBoss : MonoBehaviour
{
    [SerializeField] private float _attackCountDown, _distance, _radius;
    [SerializeField] private float _damage;
    [SerializeField] private float _timeCountDown = Mathf.Infinity;
    [SerializeField] private CircleCollider2D _circleCollider;
    [SerializeField] private LayerMask _layerPlayer;
    [SerializeField] private Animator _anim;

    private EnemyPatrol _enemyPatrol;
    private void Start()
    {
        _enemyPatrol = GetComponentInParent<EnemyPatrol>();
    }
    private void Update()
    {
        _timeCountDown += Time.deltaTime;

        if (PlayerIntheRegion())
        {
            if (_timeCountDown >= _attackCountDown)
            {
                _timeCountDown = 0;
                _anim.SetTrigger("Attack");
            }
        }
        if (_enemyPatrol != null)
        {
            _enemyPatrol.enabled = !PlayerIntheRegion();
        }
    }

    private bool PlayerIntheRegion()
    {
        RaycastHit2D region = Physics2D.CircleCast(_circleCollider.bounds.center + transform.right * _distance * transform.localScale.x,
            _radius, Vector2.left, 0, _layerPlayer);

        return region.collider != null;
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(_circleCollider.bounds.center + transform.right * _distance * transform.localScale.x, _radius);
    }
}
