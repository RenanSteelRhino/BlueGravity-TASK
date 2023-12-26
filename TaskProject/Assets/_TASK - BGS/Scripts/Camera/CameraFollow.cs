using UnityEngine;

namespace BGSTask
{
    // Script resposible for moving the camera to the target possition
    // Made to follow the player with a smooth effect
    public class CameraFollow : MonoBehaviour
    {
        [SerializeField] private Transform target;

        [Range(0.01f, 10)]
        [SerializeField] private float speed;
        Transform cameraTransform;

        // Cache the transform for easy access
        private void Start() => cameraTransform = transform;

        void MoveCameraToTarget()
        {
            //Here I maintain the Z position the same, that way I prevent problems with camera Z fight
            Vector3 formatedPosition = new(cameraTransform.position.x, cameraTransform.position.y, -10);
            Vector3 targetPosition = new(target.position.x, target.position.y, -10);

            //Lerp the camera position to the new target position, using the speed
            cameraTransform.position = Vector3.Lerp(formatedPosition, targetPosition, speed * Time.deltaTime);
        }

        private void Update() 
        {
            //Null check to prevent errors
            if(target == null) return;

            MoveCameraToTarget();
        }
    }


}
