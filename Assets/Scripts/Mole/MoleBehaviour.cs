using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class MoleBehaviour : MonoBehaviour
{
    [SerializeField]
    private Transform _startPos;

    [SerializeField]
    private Transform _endPos;
    private MoleManager _MoleManager;

    public GameObject _currentMole {get; private set;} = null;
    public bool _canSpawnHere = false;
    private bool _isSpawned = false;


    private void Start() 
    {
        _MoleManager = GetComponentInParent<MoleManager>();
    }

    private void Update() 
    {
        if (_canSpawnHere && _MoleManager._canSpawn)
        {
            _isSpawned = true;
            Debug.Log("BeforeSpawn");
            SpawnMole();
            StartCoroutine(MoveMole());
            _canSpawnHere = false;
            _MoleManager._canSpawn = false;
        }
    }

    private void SpawnMole()
    {
        _currentMole = Instantiate(_MoleManager.GetRandomMole(), transform, true);
        _currentMole.transform.localPosition = _startPos.localPosition;
        _currentMole.transform.Rotate( 0, 0, 90);

    }

    private IEnumerator MoveMole()
    {
        if (_currentMole) 
        {
            _currentMole.transform.DOMove(_endPos.position, 0.5f).SetEase(Ease.Linear).OnComplete(() => _currentMole.GetComponentInChildren<MeshCollider>().enabled = true);
        }
        yield return new WaitForSeconds(2f);
        if (_currentMole) 
        {
            _currentMole.GetComponentInChildren<MeshCollider>().enabled = false;
            _currentMole.transform.DOMove(_startPos.position, 0.5f).SetEase(Ease.Linear).OnComplete(() => {Destroy(_currentMole); _isSpawned = false; _MoleManager._scoreBoard.HasNotWhacked();});
        }
    }

    public void Hit()
    {
        if (_currentMole)
        {
            StopCoroutine(MoveMole());
            _MoleManager._scoreBoard.Whacked();
            _currentMole.GetComponentInChildren<MeshCollider>().enabled = false;
            _currentMole.transform.DOMove(_startPos.position, 0.25f).SetEase(Ease.Linear).OnComplete(() => {Destroy(_currentMole); _isSpawned = false;});
            Debug.Log("hit");
        }
    }

    public bool CanSpawn(){
        return !_isSpawned;
    }
}
