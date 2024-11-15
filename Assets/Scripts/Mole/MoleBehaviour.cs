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

    private bool _hasBeenHit = false;


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
            MoveUp();
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

    private void MoveUp()
    {
        if (_currentMole) 
        {
            Debug.Log("Move up");
            Tween myTween = _currentMole.transform.DOMove(_endPos.position, 0.5f).SetEase(Ease.Linear);
            myTween.OnComplete(() =>
            {
                _currentMole.GetComponentInChildren<MeshCollider>().enabled = true;
                Debug.Log("Mesh Enabled");
                StartCoroutine(MoveDown());
            });
            Debug.Log("is Up");
            myTween.OnKill(() => 
            {
                Debug.LogError("Tween Was Killed !");
            });
            
        }
    }

    private IEnumerator MoveDown()
    {
        yield return new WaitForSeconds(2f);
        if (!_hasBeenHit) 
        {
            Debug.Log("Move down");
            _currentMole.GetComponentInChildren<MeshCollider>().enabled = false;
            _currentMole.transform.DOMove(_startPos.position, 0.5f).SetEase(Ease.Linear).OnComplete(() => 
            {
                Destroy(_currentMole); 
                _isSpawned = false; 
                _MoleManager._scoreBoard.HasNotWhacked();
            });
        }
    }

    public void Hit()
    {
        if (_currentMole && _MoleManager._gameRunning)
        {
            _currentMole.GetComponentInChildren<MeshCollider>().enabled = false;
            _hasBeenHit = true;
            _MoleManager._scoreBoard.Whacked();
            _currentMole.transform.DOMove(_startPos.position, 0.25f).SetEase(Ease.Linear).OnComplete(() => {Destroy(_currentMole); _isSpawned = false; _hasBeenHit = false;});
            Debug.Log("hit");
        }
    }

    public bool CanSpawn(){
        return !_isSpawned;
    }
}
