using Mancala.Domain.Entities;
using Mancala.Domain.Enum;

namespace Mancala.Test
{
    public class BuildPlayer
    {
        private BuildPlayer()
        {
        } 

        private string _username;
        private bool _isActive;
        private PlayerType _playerType;
        private int _playerInput;
        public BuildPlayer UserName(string username)
        {
            _username = username;
            return this;
        }
        public BuildPlayer IsActive(bool isActive)
        {
            _isActive = isActive;
            return this;
        }

        public BuildPlayer PlayerType(PlayerType playerType)
        {
            _playerType = playerType;
            return this;
        }

        public BuildPlayer PlayerInput(int playerInput)
        {
            _playerInput = playerInput;
            return this;
        }

        public static BuildPlayer With()
        {
            return new BuildPlayer();
        }

        public BuildPlayer Defaults()
        {
            return UserName("Murat").IsActive(true).PlayerType(Domain.Enum.PlayerType.Player1).PlayerInput(1);
        }
        public Player Build()
        {
            return new Player(_username, _isActive, _playerType, _playerInput);
        }
    }
}
