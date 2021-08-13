using UnityEngine;

namespace AxGrid.AbstractPractice
{
    public class Enemy : Unit
    {
        [Header("Set in Enemy")] 
        [SerializeField] private string _weapon = "Gold Sword";

        public override void Move()
        {
            Debug.Log($"{unitName} with {_weapon}");
            base.Move();
        }
    }
}
