using System;
using _Scripts.Constants;
using _Scripts.Players;
using _Scripts.UI;
using _Scripts.Utilities;

namespace _Scripts.Game
{
    public class GameManager : Singleton<GameManager>
    {
        public PlayerController player1;
        public PlayerController player2;
        private PlayerController _currentPlayer;

        private void Start()
        {
            StartGame();
        }

        void StartGame()
        {
            UIManager.Instance.ShowUIView(ViewsType.GameplayView);
            player1.Init();
            player2.Init();
            _currentPlayer = player1;
        }

        void StartTurn()
        {
            _currentPlayer.StartTurn(1);
        }
    }
}