using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyPatrol : MonoBehaviour
{
    [SerializeField] private Transform _leftEgde;
    [SerializeField] private Transform _rightEgde;

    [Header("Enemy")]
    [SerializeField] private Transform _enemy;
    [SerializeField] private float _speed;
    [SerializeField] private Animator _anim;
    [SerializeField] private float _idleDuration;
    private float _idleTime;
    private bool _egde = false;

    private void Update()
    {
        if (!_egde)
        {
            if (_enemy.position.x <= _rightEgde.position.x)
            {
                _enemy.transform.localScale = new Vector2(-1, 1);
                MoveDirection(1);
            }
            else Edge();
        }
        else
        {
            if (_enemy.position.x >= _leftEgde.position.x)
            {
                _enemy.transform.localScale = Vector2.one;
                MoveDirection(-1);
            }
            else Edge();
        }
    }

    private void OnDestroy()
    {
        _anim.SetInteger("AnimState", 0);
    }

    private void MoveDirection(float _dir)
    {
        _idleTime = 0;
        _enemy.position = new Vector2(_enemy.position.x + Time.deltaTime * _dir * _speed, _enemy.position.y);
        _anim.SetInteger("AnimState", 2);

    }

    private void Edge()
    {
        _anim.SetInteger("AnimState", 0);
        _idleTime += Time.deltaTime;
        if (_idleTime >= _idleDuration)
            _egde = !_egde;
    }

}
