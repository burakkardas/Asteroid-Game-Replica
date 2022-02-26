using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Astreoid_Controller : MonoBehaviour
{
    [SerializeField] private Rigidbody2D _rigidBody = null;
    void Aweke()
    {
        _rigidBody = GetComponent<Rigidbody2D>();
    }

    public void Move(Vector3 _direction, float _speed) {
        _rigidBody.AddForce(_direction * _speed);
    }
}
