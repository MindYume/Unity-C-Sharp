using System.Collections;
using UnityEngine;

namespace Maze
{
    public class Main : MonoBehaviour
    {
        private InputController _inputController;
        private ListExecuteObjectController _executeObject;
        [SerializeField] private Unit _Player;
        [SerializeField] private Bonus[] _BonusObj;


        IEnumerator interactiveEnum;


        private void Awake()
        {
            _inputController = new InputController(_Player);
            _executeObject = new ListExecuteObjectController(_BonusObj);
            _executeObject.AddExecuteObject(_inputController);
            interactiveEnum = _executeObject.GetEnumerator();
        }


        void Update()
        {
            while(_executeObject.MoveNext())
            {
                IExecute temp = (IExecute)_executeObject.Current;
                temp.Update();
            }
            _executeObject.Reset();
        }
    }
}
