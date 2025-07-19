using System;
using _Scripts.Constants;
using _Scripts.Cores;
using _Scripts.Players;
using _Scripts.UI;
using _Scripts.Utilities;

namespace _Scripts.Game
{
    public class GameManager : Singleton<GameManager>
    {
        public PlayerController player;
        public PlayerController opponent;
        private PlayerController _currentPlayer;

        private void Start()
        {
            StartGame();
        }

        void StartGame()
        {
            UIManager.Instance.ShowUIView(ViewsType.GameplayView);
            player.Init();
            opponent.Init();
            TurnManager.Instance.StartTurn(true);
        }
    }
}