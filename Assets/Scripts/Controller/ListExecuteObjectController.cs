using System.Collections.Generic;
using System.Collections;
using System;
using UnityEngine;

namespace Maze
{
    public class ListExecuteObjectController: IEnumerable, IEnumerator, IDisposable
    {
        private int _index = -1;
        private IExecute[] _interactiveObject;
        public int Length => _interactiveObject.Length;

        public object Current => _interactiveObject[_index];


        public IExecute this[int current] 
        { 
            get => _interactiveObject[current]; 
            private set => _interactiveObject[current] = value; 
        }


        public ListExecuteObjectController(Bonus[] bonuses)
        {
            for(int i = 0; i < bonuses.Length; i++)
            {
                if (bonuses[i] is IExecute)
                {
                    AddExecuteObject(bonuses[i]);
                }
            }
        }

        public void AddExecuteObject(IExecute execute)
        {
            if ( _interactiveObject == null )
            {
                _interactiveObject = new[] {execute};
                return;
            }

            Array.Resize(ref _interactiveObject, Length + 1);
            _interactiveObject[Length - 1] = execute;
        }

        // IEnumerator
        public bool MoveNext()
        {
            _index++;
            return _index < Length;
        }

        public void Reset()
        {
            _index = -1;
        }

        public IEnumerator GetEnumerator()
        {
            return this;
        }

        //IDisposable
        public void Dispose()
        {
            
        }

    }
}
