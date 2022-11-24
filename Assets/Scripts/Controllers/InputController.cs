
using UnityEngine;

namespace Maze 
{
    public class InputController : IExecute
    {
        private readonly Unit _player;

        private float horizontal;
        private float vertical;

        public InputController(Unit player)
        {
            _player = player;
        }

        public void Update()
        {
            horizontal = Input.GetAxisRaw("Horizontal");
            vertical = Input.GetAxisRaw("Vertical");
            _player.Move(horizontal, 0, vertical);
        }
    }
}
