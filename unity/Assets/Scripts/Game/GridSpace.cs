using System;
using Entity;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace Game
{
    [RequireComponent(typeof(Button))]
    public class GridSpace : MonoBehaviour
    {
        private Button _button;
    
        private TextMeshProUGUI _text;

        private PlayerTurn _playerTurn;

        private GameController _gameController;

        private Action _onClickButtonCallback = delegate { };

        private void Awake()
        {
            _playerTurn = PlayerTurn.Null;
            
            _button = GetComponent<Button>();
    
            _text = GetComponentInChildren<TextMeshProUGUI>();
        }
    
        private void OnEnable()
        {
            Reset();
        }
    
        private void Start()
        {
            _button.onClick.AddListener(OnClickButton);
        }

        private void OnClickButton()
        {
            SetPlayerTurn();
            
            _onClickButtonCallback?.Invoke();
        }

        public bool IsPlayerTurn(PlayerTurn playerTurn)
        {
            return _playerTurn == playerTurn;
        }

        public void SetGameController(GameController gameController)
        {
            this._gameController = gameController;
        }

        public void SetOnClickButtonCallback(Action callback)
        {
            this._onClickButtonCallback = callback;
        }
        
        public void Reset()
        {
            _text.text = "";

            _playerTurn = PlayerTurn.Null;
            
            SetInteractable(true);
        }
    
        public void SetPlayerTurn()
        {

            _playerTurn = _gameController.GetCurrentPlayerTurn();
            
            _text.text = _playerTurn == PlayerTurn.X ? "X" : "O";
            
            SetInteractable(false);
        }
    
        private void SetInteractable(bool interactable)
        {
            _button.interactable = interactable;
        }
        
        // private void OnValidate()
        // {
        //     if (_button == null)
        //     {
        //         throw new NullReferenceException("Button is null");
        //     }
        //     
        //     if (_text == null)
        //     {
        //         throw new NullReferenceException("Text is null");
        //     }
        // }
    }

}

