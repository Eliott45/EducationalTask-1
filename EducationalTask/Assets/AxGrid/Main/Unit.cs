using AxGrid.Base;
using AxGrid.Model;
using UnityEngine;

namespace AxGrid.Main
{
    public abstract class Unit : MonoBehaviourExtBind
    {
        [Header("Set in Inspector:")] 
        [SerializeField] private protected Transform _idlePlace;
        [SerializeField] private protected Transform _jobPlace;
        [SerializeField] protected Transform _shopPlace;

        [Bind("OnActionChanged")]
        private protected abstract void Move();
    }
}