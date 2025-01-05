using _Root.Scripts.Directions.Runtime;
using Unity.Entities;
using Unity.Physics;

namespace _Root.Scripts.Physics.Runtime.Movements
{
    public partial struct GoFrowardJobEntity : IJobEntity
    {
        public void Execute(
            in DirectionComponentData directionComponentData,
            in MoveSpeedComponentData moveSpeedComponentData,
            ref PhysicsVelocity physicsVelocity
            )
        {
            physicsVelocity.Linear += directionComponentData.Normalized * moveSpeedComponentData.MoveSpeed;
        }
    }
}