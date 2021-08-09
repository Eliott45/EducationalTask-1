using System.Numerics;
using AxGrid.Base;
using AxGrid.Model;
using AxGrid.Path;
using UnityEngine;
using Vector3 = UnityEngine.Vector3;

namespace AxGrid.Main
{
    public class Player : Unit
    {
        private protected override void Move()
        {
            var currentPos = transform.position;
            var newPos = Settings.GlobalModel.Get("Action") switch
            {
                EStates.idle => _idlePlace.position,
                EStates.working => _jobPlace.position,
                EStates.shopping => _shopPlace.position,
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
        
    }
}
