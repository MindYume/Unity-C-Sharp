using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Maze
{
    public class WinBonus : Bonus
    {
        public override void Awake()
        {
            base.Awake();
            
            _color = GetRandomColor();
            _renderer.material.color = _color;
        }

        public override void Update()
        {
            // fly
            // flick
        }

        protected override void Interaction(Collider other)
        {
            if(other.CompareTag("Player"))
            {
                IsInteractable = false;
                other.GetComponent<Player>().GetScore(1);
            }
        }

        private Color GetRandomColor()
        {
            switch(Random.Range(1,7))
            {
                case 1:
                    return Color.red;

                case 2:
                    return Color.green;

                case 3:
                    return Color.blue;
                
                case 4:
                    return Color.yellow;
                
                case 5:
                    return new Color(0.5f, 0.5f, 0);
                
                case 6:
                    return new Color(0.5f, 0, 0.5f);
                
                case 7:
                    return new Color(0, 0.5f, 0.5f);
            }

            return Color.white;
        }
    }
}
