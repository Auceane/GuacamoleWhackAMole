using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

public class UIController : MonoBehaviour
{

    [SerializeField]
    TMP_Text _Score;

    [SerializeField]
    TMP_Text _Combos;

    [SerializeField]
    Transform _HeartContainer;

    [SerializeField]
    GameObject _HeartPrefab;

    [SerializeField]
    MoleManager _moleManager;



    int _score=0;

    int _combos = 0;

    public int _numberHearts = 3;

    int _numberOfCombosToGetAHeart = 20;


    //float _timePassedBeforeLosingACombos=0;

    //float _maxTimeForLosingACombos = 5;


    //float _timePassedBeforeLosingAHeart=0;

   // float _maxTimeForLosingAHeart=5;

    //bool _whacked = false;


    // Start is called before the first frame update
    void Start()
    {
        _Combos.text = "" + _combos;

        _Score.text = "" + _score;
    }



    // Update is called once per frame
    /*void Update()
    {
        if(_numberHearts> 0)
        {

            //_timePassedBeforeLosingAHeart += Time.deltaTime;
            _timePassedBeforeLosingACombos += Time.deltaTime;


            if (_timePassedBeforeLosingACombos >= _maxTimeForLosingACombos && _combos!=0)
            {
                _combos = 0;
                UpadteCombos();

            }
            if (_timePassedBeforeLosingAHeart >= _maxTimeForLosingAHeart)
            {
                Debug.Log("Destroy Heart");
                GameObject heart = _HeartContainer.GetChild(0).gameObject;
                Destroy(heart);
                _numberHearts--;
                _timePassedBeforeLosingAHeart = 0;

            }
        }


    }*/


    private void UpadteCombos()
    {
        if (_combos >= 20)
        {
            _Combos.color = Color.cyan;
        }
        else if (_combos >= 10)
        {

            _Combos.color = Color.magenta;
        }
        else if (_combos >= 5)
        {
            _Combos.color = Color.red;
        } else
        {
            _Combos.color = Color.black;
        }

        if(_combos!=0 && _combos % _numberOfCombosToGetAHeart==0 && _HeartContainer.childCount < 5)
        {

            //var heart = Instantiate(_HeartPrefab,_HeartContainer);
            //heart.transform.localScale = Vector3.one;
            AddHeart();
            //heart.transform.SetParent(_HeartContainer);

            _numberHearts++;

        }

        _Combos.text = ""+_combos;
    }




    private void UpdateScore()
    {
        int scoreAdded = 1;
        if (_combos >= 20)
        {
            scoreAdded += 9;
        }
        else if (_combos >= 10)
        {

            scoreAdded += 4;
        }
        else if (_combos >= 5)
        {
            scoreAdded++ ;
        } 

        _score += scoreAdded;

        _Score.text = "" + _score;
    }



    public void Whacked()
    {
        if (_numberHearts > 0)
        {
            //_timePassedBeforeLosingACombos = 0;

            //_timePassedBeforeLosingAHeart = 0;

            _combos++;

            UpadteCombos();
            UpdateScore();
        }

    }


    public void HasNotWhacked()
    {
        if (_numberHearts > 0)
        {
            Debug.Log("Destroy Heart");
            //GameObject heart = _HeartContainer.GetChild(0).gameObject;
            //Destroy(heart);
            DestroyHeart();
            _numberHearts--;

            _combos = 0;
            UpadteCombos();
            //_timePassedBeforeLosingAHeart = 0;
        }
        /*if(_numberHearts == 0)
        {
            
            _moleManager.StopGame();
        }*/
    }


    public void Restart()
    {
        _combos = 0;
        _score = 0;
        _Combos.text = "" + _combos;

        _Score.text = "" + _score;
        _numberHearts = 3;
        LoadHearts();

        // Restart the game

        //SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }


    private void LoadHearts()
    {
        int childCount = _HeartContainer.childCount;
        if (childCount < 3)
        {
            while (childCount < 3)
            {
                AddHeart();
                childCount++;
            }
        }else if(childCount > 3)
        {
            while (childCount > 3)
            {
                DestroyHeart();
                childCount--;
            }
        }


    }

    private void AddHeart()
    {
        var heart = Instantiate(_HeartPrefab, _HeartContainer);
        heart.transform.localScale = Vector3.one;
    }


    private void DestroyHeart()
    {
        GameObject heart = _HeartContainer.GetChild(0).gameObject;
        Destroy(heart);
    }


}
