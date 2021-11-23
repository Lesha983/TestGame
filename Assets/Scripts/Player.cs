using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] private float _speed;
    [SerializeField] private float _speedRotation;
    [SerializeField] private Transform _startPosition;
    private Vector3 _moveVector;
    private bool _lumberingAnim;

    private CharacterController _chController;
    private Animator _animator;

    [SerializeField] private Joystick _joystick;

    private void Start()
    {
        _chController = GetComponent<CharacterController>();
        _animator = GetComponent<Animator>();
    }

    private void Update()
    {
        Move();
    }

    private void Move()
    {
        _moveVector = Vector3.zero;
        _moveVector.x = _joystick.VectorMove().x;
        _moveVector.z = _joystick.VectorMove().y;

        if (_moveVector.x != 0 || _moveVector.z != 0)
            _animator.SetBool("Move", true);
        else
            _animator.SetBool("Move", false);

        if (Vector3.Angle(Vector3.forward, _moveVector) > 1f || Vector3.Angle(Vector3.forward, _moveVector) == 0)
        {
            Vector3 direct = Vector3.RotateTowards(transform.forward, _moveVector, _speedRotation, 0.0f);
            transform.rotation = Quaternion.LookRotation(direct);
        }
        _chController.Move(_moveVector * Time.deltaTime * _speed);
    }

    public void Lumbering()
    {
        _lumberingAnim = !_lumberingAnim;
        _animator.SetBool("Lumbering", _lumberingAnim);
    }

    public void ReloadLevel()
    {
        transform.Translate(_startPosition.position);
    }
}
