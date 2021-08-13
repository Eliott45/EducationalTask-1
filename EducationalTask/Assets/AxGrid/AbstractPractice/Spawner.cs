using System;
using UnityEngine;

namespace AxGrid.AbstractPractice
{
    public class Spawner : MonoBehaviour
    {
        private Unit _unit;
        
        private void Start()
        {
            _unit = gameObject.AddComponent<Enemy>();
        }

        private void FixedUpdate()
        {
            _unit.Move();
        }
    }
}
