using System.Collections;
using System.Collections.Generic;
using GameEnums;
using UnityEngine;

namespace BGSTask
{
    public class SwordController : MonoBehaviour
    {
        Camera mainCam;
        [SerializeField] float swordTurnSpeed;
        public float difference;
        float audioTime = 0.1f;
        float currentDelay;

        private void Start() {
            mainCam = Camera.main;
        }

        void Update()
        {
            //Get the mouse position then convert to 2D
            Vector3 mousePos = Input.mousePosition;
            mousePos.z = mainCam.nearClipPlane;
            //Align the Y axis to the mouse position (direction)
            transform.up = Vector2.Lerp(transform.up, ((Vector2)mainCam.ScreenToWorldPoint(mousePos)-(Vector2)transform.position).normalized, swordTurnSpeed * Time.deltaTime);

            //Difference from were the sword is at compared to were it is going
            //Used to determinate if the woosh sound shoul be played
            difference = ((Vector2)transform.up - ((Vector2)mainCam.ScreenToWorldPoint(mousePos)-(Vector2)transform.position).normalized).magnitude;

            //Create a delay for playing a woosh sound with the sword
            currentDelay += Time.deltaTime;
            currentDelay = Mathf.Clamp(currentDelay, 0, 0.3f);

            if(currentDelay >= audioTime && difference > 0.8f)
            {
                SoundManager.Instance.SpawnAudioFor(Enum_AudioTypes.sword);
                currentDelay = 0;
            }
        }
    }
}
