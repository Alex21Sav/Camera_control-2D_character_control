using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using GG.Infrastructure.Utils.Swipe;


public class PlayerController : MonoBehaviour
{
    [SerializeField] private SwipeListener _swipeListener;
    [SerializeField] private Transform _transformPlayer;
    [SerializeField] private float _speed;

    private Vector2 _playerDerection = Vector2.zero ;

    private void OnEnable()
    {
        _swipeListener.OnSwipe.AddListener(OnSwipe);
    }
    private void OnSwipe(string swipe)
    {        
        Debug.Log(swipe);
        switch (swipe)
        {
            case "Left":
                _playerDerection = Vector2.left;
                break;
            case "Right":
                _playerDerection = Vector2.right;
                break;
            case "Up":
                _playerDerection = Vector2.up;
                break;
            case "Down":
                _playerDerection = Vector2.down;
                break;
            //----------------
            case "UpLeft":
                _playerDerection =new Vector2(-1f, 1f);
                break;
            case "UpRight":
                _playerDerection = new Vector2(1f, 1f);
                break;
            case "DownLeft":
                _playerDerection = new Vector2(-1f, -1f);
                break;
            case "DownRight":
                _playerDerection = new Vector2(1f, -1f);
                break;
        }
    }

    private void Update()
    {
        _transformPlayer.position += (Vector3)_playerDerection * _speed * Time.deltaTime;
    }

    private void OnDisable()
    {
        _swipeListener.OnSwipe.RemoveListener(OnSwipe);
    }
}
