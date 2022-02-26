using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Astreoid_Manager : MonoBehaviour
{
    [SerializeField] private Astreoid_Controller _astreoidPrefab;
    [SerializeField] private Vector2[] _spawnPoints;
    void Start()
    {
        StartCoroutine(nameof(RandomSpawn));   
    }
    IEnumerator RandomSpawn() {
        while(true) {
            yield return new WaitForSeconds(2);
            int _randomSpawnPoint = Random.Range(0, 4);

            switch(_randomSpawnPoint) {
                case 0 : CreateAsteroid(_spawnPoints[0], new Vector2(Random.Range(0, 15), -5f));
                    break;
                case 1 : CreateAsteroid(_spawnPoints[1], new Vector2(Random.Range(-15, 0), -5f));
                    break;
                case 2 : CreateAsteroid(_spawnPoints[2], new Vector2(Random.Range(-15, 0), 5f));
                    break;
                case 3 : CreateAsteroid(_spawnPoints[3], new Vector2(Random.Range(15, 0), 5f));
                    break;
            }
        }
    }

    private void CreateAsteroid(Vector3 _spawnPoint, Vector2 _direction) {
        var _newAsteroid = Instantiate(_astreoidPrefab, _spawnPoint, Quaternion.identity);
        _newAsteroid.transform.SetParent(GameObject.Find("Asteroids").transform);
        RandomSize(_newAsteroid.transform);
        var _speed = 20;
        if(_newAsteroid.transform.localScale.x >= 1f) {
            _speed /= 2;
        }
        _newAsteroid.Move(_direction, _speed);
    }


    private void RandomSize(Transform _asteroidScale) {
        var _scale = _asteroidScale.localScale;
        _scale.x = Random.Range(0.8f, 1.7f);
        _scale.y = _scale.x;
        _asteroidScale.localScale = _scale;
    }
}
