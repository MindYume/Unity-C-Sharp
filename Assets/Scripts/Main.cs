using System.Collections.Generic;
using System.Collections;
using UnityEngine;

namespace Maze
{
    public class Main : MonoBehaviour
    {
        private InputController _inputController;
        private ListExecuteObjectController _executeObject;
        [SerializeField] private Unit _Player;
        [SerializeField] private GameObject _WinBonuses;
        [SerializeField] private Bonus[] _BonusObj;

        IEnumerator interactiveEnum;


        private StreamData gameSaver;

        private void Awake()
        {
            _inputController = new InputController(_Player);
            _executeObject = new ListExecuteObjectController(_BonusObj);
            _executeObject.AddExecuteObject(_inputController);
            interactiveEnum = _executeObject.GetEnumerator();
            gameSaver = new StreamData((Player)_Player, _WinBonuses);
        }


        void Update()
        {
            while(_executeObject.MoveNext())
            {
                IExecute temp = (IExecute)_executeObject.Current;
                temp.Update();
            }
            _executeObject.Reset();

            gameSaver.Update();
        }
    }
}
