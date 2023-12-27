using BGSTask;
using UnityEngine;

namespace Cainos.PixelArtTopDown_Basic
{
    public class TopDownCharacterController : Singleton<TopDownCharacterController>
    {
        [SerializeField] float speed;
        private Animator animator;
        Vector2 dir = Vector2.zero;
        bool lockMovement = false;

        private void Start()
        {
            animator = GetComponent<Animator>();
            OutfitStoreManager.OnStoreOpen += DisableMovement;
            OutfitStoreManager.OnStoreClose += EnableMovement;
        }

        void DisableMovement() => lockMovement = true;
        void EnableMovement() => lockMovement = false;

        void MovePlayer()
        {
            //Made a simpler version of the movement code
            //The animator was no longer necessary
            
            dir = Vector2.zero;
            if (Input.GetKey(KeyCode.A))
                dir.x = -1;
            else if (Input.GetKey(KeyCode.D))
                dir.x = 1;
            if (Input.GetKey(KeyCode.W))
                dir.y = 1;
            else if (Input.GetKey(KeyCode.S))
                dir.y = -1;

            dir.Normalize();
            animator.SetBool("IsMoving", dir.magnitude > 0);
            GetComponent<Rigidbody2D>().velocity = speed * dir;
        }

        public Vector2 GetCurrentDirection()
        {
            return dir;
        }

        private void Update()
        {
            //If true, disable movement
            if(lockMovement) return;

            // CainosMoveCode_NotMine();
            MovePlayer();
        }

        // private void CainosMoveCode_NotMine()
        // {
        //     Vector2 dir = Vector2.zero;
        //     if (Input.GetKey(KeyCode.A))
        //     {
        //         dir.x = -1;
        //         animator.SetInteger("Direction", 3);
        //     }
        //     else if (Input.GetKey(KeyCode.D))
        //     {
        //         dir.x = 1;
        //         animator.SetInteger("Direction", 2);
        //     }

        //     if (Input.GetKey(KeyCode.W))
        //     {
        //         dir.y = 1;
        //         animator.SetInteger("Direction", 1);
        //     }
        //     else if (Input.GetKey(KeyCode.S))
        //     {
        //         dir.y = -1;
        //         animator.SetInteger("Direction", 0);
        //     }

        //     dir.Normalize();
        //     animator.SetBool("IsMoving", dir.magnitude > 0);

        //     GetComponent<Rigidbody2D>().velocity = speed * dir;
        // }


        // Remove link to events to avoid erros
        private void OnDisable() 
        {
            OutfitStoreManager.OnStoreOpen -= DisableMovement;
            OutfitStoreManager.OnStoreClose -= EnableMovement;
        }

        private void OnDestroy() 
        {
            OutfitStoreManager.OnStoreOpen -= DisableMovement;
            OutfitStoreManager.OnStoreClose -= EnableMovement;
        }
    }
}
