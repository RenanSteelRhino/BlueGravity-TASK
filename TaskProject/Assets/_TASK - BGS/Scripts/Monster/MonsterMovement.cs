using System.Collections;
using UnityEngine;

namespace BGSTask
{
    public class MonsterMovement : MonoBehaviour
    {
        [SerializeField] float speed = 2;
        [SerializeField] float moveRadius;
        Vector2 dir;
        Vector2 startPoint;

        private void Start()
        {
            startPoint = transform.position;
            StartMovement();
        }

        public void StartMovement()
        {
            StopAllCoroutines();
            StartCoroutine(GetNewPoint());
        }

        IEnumerator GetNewPoint()
        {
            while(true)
            {
                yield return new WaitForSeconds(Random.Range(1f,5f));
                Vector2 newPosition = startPoint + Random.insideUnitCircle * moveRadius;
                dir = (newPosition - startPoint).normalized;
            }

        }

        private void Update() {
            Move();
        }

        void Move()
        {
            dir.Normalize();
            GetComponent<Rigidbody2D>().velocity = speed * dir;
        }

        private void OnDrawGizmos() {
            Gizmos.DrawWireSphere(transform.position, moveRadius);
        }
    }
}
