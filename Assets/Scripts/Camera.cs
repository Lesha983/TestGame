using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Camera : MonoBehaviour
{
    [SerializeField] private Transform _player;
    private Vector3 _offset = new Vector3(0,6,-5);

    void LateUpdate()
    {
        transform.position = _player.position + _offset;
    }
}
