using System;
using Common;
using Entity;
using UnityEngine;

namespace Game
{
    public class GameController : MonoBehaviour
    {
        private PlayerTurn _playerTurn;

        private GridSpace[] _gridSpaces;
        
        private readonly int[][] _checkPoints = new int[][]
        {
            new int[] {0, 1, 2}, new int[] {3, 4, 5}, new int[]{6, 7, 8},
            new int[] {0, 3, 6}, new int[] {1, 4, 7}, new int[] {2, 5, 8},
            new int[] {0, 4, 8}, new int[] {2, 4, 6}
        };

        private void Awake()
        {
            _gridSpaces = GetComponentsInChildren<GridSpace>();
        }

        private void Start()
        {
            ResetBoard();
            
            SetPlayerTurn(PlayerTurn.O);
        }

        private void ResetBoard()
        {
            foreach (var gridSpace in _gridSpaces)
            {
                gridSpace.Reset();
                
                gridSpace.SetGameController(this);
                
                gridSpace.SetOnClickButtonCallback(OnFinishTurn);
            }
        }

        private void OnFinishTurn()
        {
            if (IsWinGame(_playerTurn))
            {
                print("Player: " + _playerTurn + "win the game");
            }else if (IsEndGame())
            {
                print("Draw!");
            }
            else
            {
                SetNextPlayerTurn();
            }
        }

        private bool IsEndGame()
        {
            foreach (var gridSpace in _gridSpaces)
            {
                if (gridSpace.IsPlayerTurn(PlayerTurn.Null))
                {
                    return false;
                }
            }

            return true;
        }

        private bool IsWinGame(PlayerTurn playerTurn)
        {
            for (int i = 0; i < _checkPoints.Length; i++)
            {
                var count = 0;
                
                for (int j = 0; j < 3; j++)
                {
                    var point = _checkPoints[i][j];

                    if (!_gridSpaces[point].IsPlayerTurn(playerTurn))
                    {
                        break;
                    }
                    else
                    {
                        count++;
                    }
                }

                if (count == 3)
                {
                    return true;
                }
            }

            return false;
        }

        public void SetPlayerTurn(PlayerTurn playerTurn)
        {
            this._playerTurn = playerTurn;
        }

        public PlayerTurn GetCurrentPlayerTurn()
        {
            return this._playerTurn;
        }

        public void SetNextPlayerTurn()
        {
            this._playerTurn = _playerTurn == PlayerTurn.O ? PlayerTurn.X : PlayerTurn.O;
        }

    }
}
