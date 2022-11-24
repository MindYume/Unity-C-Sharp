using UnityEngine;

namespace Maze
{
    public abstract class Unit : MonoBehaviour
    {
        public Transform _transform;
        public Rigidbody _rb;

        private float _speed = 5f;
        private int _health = 100;
        private bool _isDead;

        public int Health
        {
            get => _health;
            set
            {
                _health = Mathf.Clamp(value, 0, 100);
            }
        }

        public virtual void Awake()
        {
            if (!TryGetComponent<Transform>(out _transform))
            {
                Debug.Log("No Transform Component!");
            }

            if (!TryGetComponent<Rigidbody>(out _rb))
            {
                Debug.Log("No Rigidbody Component!");
            }
        }

        public abstract void Move(float x, float y, float z);
    }
}
