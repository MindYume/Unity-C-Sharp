using System.Collections;
using System;
using UnityEngine;

namespace Maze
{
    public class ListExecuteObjectController
    {
        private IExecute[] _interactiveObject;
        public int Length => _interactiveObject.Length;

        public IExecute[] InteractiveObject { get => _interactiveObject; set => _interactiveObject = value; }

        public ListExecuteObjectController()
        {

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
    }
}
