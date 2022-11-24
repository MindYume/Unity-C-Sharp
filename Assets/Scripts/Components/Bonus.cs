using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Maze
{
    public abstract class Bonus : MonoBehaviour, IExecute
    {
        private bool _isInteractable;
        protected Color _color;
        protected Renderer _renderer;
        protected Collider _collider;

        public float _heightFly;
        
        public bool IsInteractable
        {
            get => _isInteractable;
            set
            {
                _isInteractable = value;
                _renderer.enabled = value;
                _collider.enabled = value;
            }
        }

        public virtual void Awake()
        {
            if (!TryGetComponent<Renderer>(out _renderer))
            {
                Debug.Log("No Renderer Component!");
            }

            if (!TryGetComponent<Collider>(out _collider))
            {
                Debug.Log("No Collider Component!");
            }

            IsInteractable = true;
            /* _color = Random.ColorHSV();
            _renderer.sharedMaterial.color = _color; */
        }

        private void OnTriggerEnter(Collider other)
        {
            Interaction(other);
        }

        protected abstract void Interaction(Collider other);
        public abstract void Update();
    }
}
