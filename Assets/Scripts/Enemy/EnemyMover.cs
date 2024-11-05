using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class EnemyMover : MonoBehaviour
{
    [SerializeField] private Rigidbody rigidBody;
    
    [Range(150f, 300f)]
    [SerializeField] private float speed;

    [SerializeField] private float visionValue;

    void Update()
    {
        if (Vector3.Distance(transform.position, Player.Instance.transform.position) <= visionValue)
        {
            var direction = (Player.Instance.transform.position - transform.position).normalized;
            
            rigidBody.velocity = direction * (speed * Time.deltaTime);
        }
    }
}
