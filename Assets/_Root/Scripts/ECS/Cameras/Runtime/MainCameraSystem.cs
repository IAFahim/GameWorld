using Unity.Entities;
using Unity.Transforms;

namespace _Root.Scripts.ECS.Cameras.Runtime
{
    [UpdateInGroup(typeof(PresentationSystemGroup))]
    public partial class MainCameraSystem : SystemBase
    {
        protected override void OnUpdate()
        {
            if (MainGameObjectCamera.Instance != null && SystemAPI.HasSingleton<MainEntityCamera>())
            {
                Entity mainEntityCameraEntity = SystemAPI.GetSingletonEntity<MainEntityCamera>();
                LocalToWorld targetLocalToWorld = SystemAPI.GetComponent<LocalToWorld>(mainEntityCameraEntity);
                MainGameObjectCamera.Instance.transform.SetPositionAndRotation(targetLocalToWorld.Position, targetLocalToWorld.Rotation);
            }
        }
    }
}