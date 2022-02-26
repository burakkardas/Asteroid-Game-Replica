using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[RequireComponent(typeof(Rigidbody2D))]
public class Bullet_Controller : MonoBehaviour
{
    [SerializeField] private Rigidbody2D _rigidBody = null;
    [SerializeField] private float _moveSpeed = 0;
    private bool _isLive = true;

    void Awake()
    {
        _rigidBody = GetComponent<Rigidbody2D>();
        StartCoroutine(nameof(DestroyBullet));
    }

    public void Move(Vector3 _direction) {
        _rigidBody.AddForce(_direction * _moveSpeed);
    }

    IEnumerator DestroyBullet() {
        while(_isLive) {
            yield return new WaitForSeconds(3);
            Destroy(gameObject);
        }
    }
}
