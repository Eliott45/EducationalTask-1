using UnityEngine;

namespace AxGrid.AbstractPractice
{
    public abstract class Unit: MonoBehaviour
    {
        [Header("Set in Unit")] 
        public string unitName;

        public virtual void Move()
        {
            Debug.Log($"{unitName} is moving...");
        }
    }
}
