using UnityEngine;

namespace Maze
{
    public class Main : MonoBehaviour
    {
        private InputController _inputController;
        private ListExecuteObjectController _executeObject;
        [SerializeField] private Unit _player;

        private void Awake()
        {
            _inputController = new InputController(_player);
            _executeObject = new ListExecuteObjectController();
            _executeObject.AddExecuteObject(_inputController);
        }


        void Update()
        {
            for (int i = 0; i < _executeObject.Length; i++)
            {
                if ( _executeObject.InteractiveObject[i] == null )
                {
                    continue;
                }
                _executeObject.InteractiveObject[i].Update();
            }
        }
    }
}
