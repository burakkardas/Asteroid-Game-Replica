using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[RequireComponent(typeof(Rigidbody2D))]
public class Player_Controller : MonoBehaviour
{
    [SerializeField] private Bullet_Controller _bullet = null;
    [SerializeField] private Rigidbody2D _rigidBody = null;

    [SerializeField] private float _moveSpeed = 0f;
    [SerializeField] private float _rotateSpeed = 0f;
    [SerializeField] private float _time = 0f;
    private float _currentTime = 0;

    private bool _isPressFront => Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.UpArrow);
    private bool _isPressLeft => Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.LeftArrow);
    private bool _isPressRight => Input.GetKey(KeyCode.D) || Input.GetKey(KeyCode.RightArrow);
    private bool _isPressShoot => Input.GetMouseButton(0);
    
    void Start()
    {
        _rigidBody = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        if(_isPressFront) {
            _rigidBody.AddForce(transform.up * _moveSpeed * Time.deltaTime);
        }

        if(_isPressRight || _isPressLeft) {

            var _currentRotateSpeed = _isPressRight ? -_rotateSpeed : _rotateSpeed;

            transform.Rotate(Vector3.forward * _currentRotateSpeed * Time.deltaTime);
        }

        if(_isPressShoot && _currentTime <= 0) {
            _currentTime = _time;
            Shoot();
        }
        else {
            _currentTime -= Time.deltaTime;
        }
    }
    
    private void Shoot() {
        var _newBullet = Instantiate(_bullet, transform.position, Quaternion.identity);
        _newBullet.transform.SetParent(GameObject.Find("Bullets").transform);
        _newBullet.Move(transform.up);
    }

    private void OnCollisionEnter2D(Collision2D other) {
        if(other.gameObject.CompareTag("Asteroid")) {
            Debug.Log("Game Over!");
        }
    }
}
