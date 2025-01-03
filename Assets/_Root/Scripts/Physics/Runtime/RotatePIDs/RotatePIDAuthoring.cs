using Unity.Entities;
using UnityEngine;

namespace _Root.Scripts.Physics.Runtime.Rotates
{
    public class RotatePIDAuthoring : MonoBehaviour
    {
        public float proportionalGainDelta=3; // kp is the proportional gain
        public float integralGainDelta; // ki is the integral gain
        public float derivativeGainDelta=.5f; // kd is the derivative gain
        public float errorThreshold=0.1f;
        public float low = -100;
        public float high = 100;
        
        public class RotateDampingStrengthBaker : Baker<RotatePIDAuthoring>
        {
            public override void Bake(RotatePIDAuthoring authoring)
            {
                var entity = GetEntity(TransformUsageFlags.Dynamic);
                AddComponent(entity,
                    new RotatePIDComponentData
                    {
                        PropertionalGainDelta = authoring.proportionalGainDelta,
                        IntegralGainDelta = authoring.integralGainDelta,
                        DeriativeGainDelta = authoring.derivativeGainDelta,
                        ErrorThreshold = authoring.errorThreshold,
                        Low = authoring.low,
                        High = authoring.high
                    });
            }
        }
    }
}