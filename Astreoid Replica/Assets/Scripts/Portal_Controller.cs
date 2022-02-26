using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Portal_Controller : MonoBehaviour
{
    [SerializeField] private enum Portal {
        X,
        Y
    }

    [SerializeField] private Portal _portal;

    private void OnTriggerEnter2D(Collider2D other) {
        if(other.gameObject.CompareTag("Player")) {
            var _currentPos = other.gameObject.transform.position;
            
            if(_portal == Portal.X) {
                _currentPos.x *= -1; 
            }
            else {
                _currentPos.y *= -1;
            }

            other.gameObject.transform.position = _currentPos;
        } 
    }
}
