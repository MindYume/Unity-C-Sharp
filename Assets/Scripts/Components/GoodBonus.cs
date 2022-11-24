using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Maze
{
    public class GoodBonus : Bonus
    {
        public override void Awake()
        {
            base.Awake();
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
            }
            
        }
    }
}
