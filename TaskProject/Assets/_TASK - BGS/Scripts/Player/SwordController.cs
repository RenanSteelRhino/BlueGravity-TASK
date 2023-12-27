using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace BGSTask
{
    public class SwordController : MonoBehaviour
    {
        Camera mainCam;
        [SerializeField] float swordTurnSpeed;

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
        }
    }
}
