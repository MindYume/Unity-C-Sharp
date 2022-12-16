using System.Collections.Generic;
using System.Collections;
using System.Linq;
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


        public int test(KeyValuePair<string, int> pair)
        {
            return pair.Value;
        }

        private void Awake()
        {
            _inputController = new InputController(_Player);
            _executeObject = new ListExecuteObjectController(_BonusObj);
            _executeObject.AddExecuteObject(_inputController);
            interactiveEnum = _executeObject.GetEnumerator();


            // Homework 7
            // Lambda
            Dictionary<string, int> dict1 = new Dictionary<string, int>()
            {
                {"four", 4},
                {"two", 2},
                {"one", 1},
                {"three", 3}
            };

            var d1 = dict1.OrderBy(pair => pair.Value);

            foreach (var pair in d1)
            {
                Debug.Log($"{pair.Key} - {pair.Value}");
            }


            // Delegate
            Dictionary<string, int> dict2 = new Dictionary<string, int>()
            {
                {"four", 4},
                {"two", 2},
                {"one", 1},
                {"three", 3}
            };

            var d2 = dict2.OrderBy(delegate(KeyValuePair<string, int> pair)
            {
                return pair.Value;
            });

            foreach (var pair in d2)
            {
                Debug.Log($"{pair.Key} - {pair.Value}");
            }
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
