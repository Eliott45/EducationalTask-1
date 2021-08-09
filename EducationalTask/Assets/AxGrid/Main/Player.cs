using System.Numerics;
using AxGrid.Base;
using AxGrid.Path;
using UnityEngine;
using Vector3 = UnityEngine.Vector3;

namespace AxGrid.Main
{
    public class Player : MonoBehaviourExt
    {
        [Header("Set in Inspector:")] 
        [SerializeField] private Transform _idlePlace;
        [SerializeField] private Transform _jobPlace;
        [SerializeField] private Transform _shopPlace;
        
        [OnAwake]
        private void StartAwake()
        {
            Settings.GlobalModel.EventManager.AddAction("Move", Move);
        }

        private void Move()
        {
            var currentPos = transform.position;
            var newPos = Settings.Fsm.CurrentStateName switch
            {
                "Ready" => _idlePlace.position,
                "Job" => _jobPlace.position,
                "Shop" => _shopPlace.position,
                _ => Vector3.zero
            };
            newPos.y = currentPos.y;
            Path = CPath.Create().Action(() =>
            {
                currentPos = transform.position;
            }).EasingLinear(1f,0f,  1f, value =>
            {
                transform.position = Vector3.Lerp(currentPos, newPos, value);
            });
        }

        [OnDestroy]
        private void Die()
        {
            Settings.GlobalModel.EventManager.RemoveAction(Move);
        }
    }
}
