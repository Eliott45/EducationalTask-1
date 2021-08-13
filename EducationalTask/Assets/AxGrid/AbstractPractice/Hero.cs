using UnityEngine;

namespace AxGrid.AbstractPractice
{
    public class Hero : Unit
    {
        [Header("Set in Enemy")] 
        [SerializeField] private string _skill = "Thunder";
        
        public override void Move()
        {
            Debug.Log($"{unitName} with {_skill}");
            base.Move();
        }
    }
}
