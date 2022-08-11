using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    #region Variables

    public bool isCutting = false;

    public float speed;
    [SerializeField] private FloatingJoystick floatingJoystick;
    [SerializeField] private Rigidbody playerRigidBody;

    private float _turnSmoothVelocity;
    public float smoothTime = .1f;
    private float _prevTargetAngle;

    private bool _isMoving;

    #endregion

    #region Unity Methods

    private void Awake()
    {
        floatingJoystick = GameObject.Find("Floating Joystick").GetComponent<FloatingJoystick>();
        playerRigidBody = GetComponent<Rigidbody>();
    }

    private void FixedUpdate()
    {
        var direction = Vector3.forward * floatingJoystick.Vertical + Vector3.right * floatingJoystick.Horizontal;
        playerRigidBody.AddForce(direction * (speed * Time.fixedDeltaTime), ForceMode.VelocityChange);

        if (direction.x != 0 || direction.y != 0 || direction.z != 0)
        {
            _isMoving = true;
        }
        else if (direction.x == 0 && direction.y == 0 && direction.z == 0)
        {
            _isMoving = false;
        }

        var targetAngle = Mathf.Atan2(direction.x, direction.z) * Mathf.Rad2Deg;
        var angle = Mathf.SmoothDampAngle(transform.eulerAngles.y, targetAngle, ref _turnSmoothVelocity, smoothTime);

        if (targetAngle == 0)
        {
            angle = _prevTargetAngle;
        }

        _prevTargetAngle = angle;
        if(!isCutting)
        {
            transform.rotation = Quaternion.Euler(0f, angle, 0f);
        }
    }

    #endregion

    public bool IsMoving()
    {
        return _isMoving;
    }
}