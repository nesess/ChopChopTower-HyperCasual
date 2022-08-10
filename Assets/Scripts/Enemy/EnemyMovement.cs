using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    #region Variables

    public float speed;
    [SerializeField] private Rigidbody enemyRigidBody;
    public Transform targetTransform;
    
    private float _turnSmoothVelocity;
    public float smoothTime = .1f;
    private float _prevTargetAngle;

    #endregion

    #region Unity Methods

    private void Awake()
    {
        enemyRigidBody = GetComponent<Rigidbody>();
    }

    private void FixedUpdate()
    {
        var direction = targetTransform.position - transform.position;

        var targetAngle = Mathf.Atan2(direction.x, direction.z) * Mathf.Rad2Deg;
        var angle = Mathf.SmoothDampAngle(transform.eulerAngles.y, targetAngle, ref _turnSmoothVelocity, smoothTime);

        transform.rotation = Quaternion.Euler(0f, angle, 0f);

        enemyRigidBody.AddForce(direction.normalized * (speed * Time.fixedDeltaTime), ForceMode.VelocityChange);
    }

    #endregion
}