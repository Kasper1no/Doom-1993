using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class PlayerMover : MonoBehaviour
{
    [SerializeField] private Rigidbody rigidBody;
    [Range(150f, 300f)]
    [SerializeField] private float speed;
    [Range(1f, 3f)]
    [SerializeField] private float mouseSensitivity;

    private Vector3 _movementVector;
    private float _yRotation;

    private void Update()
    {
        Move();

        Rotate();
    }

    private void Rotate()
    {
        _yRotation = Input.GetAxis("Mouse X") * mouseSensitivity;
        transform.Rotate(0f,_yRotation,0f);
    }

    private void Move()
    {
        _movementVector = new Vector3(Input.GetAxis("Horizontal"), 0f, Input.GetAxis("Vertical"));

        rigidBody.velocity = transform.TransformDirection(_movementVector * (speed * Time.deltaTime));
    }
}
