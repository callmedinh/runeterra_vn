using _Scripts.Players;
using _Scripts.Utilities;
using UnityEngine.Serialization;

namespace _Scripts.Cores
{
    public class TurnManager : Singleton<TurnManager>
    {
        public PlayerController player;
        public PlayerController enemy;
        private bool _isPlayerTurn;

        public void StartTurn(bool player)
        {
            _isPlayerTurn = player;
            var current = _isPlayerTurn ? this.player : enemy;
            
        }

        public void EndTurn()
        {
            StartTurn(!_isPlayerTurn);
        }
    }
}