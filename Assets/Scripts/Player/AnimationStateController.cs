using UnityEngine;

public class AnimationStateController : MonoBehaviour
{
    #region Variables

    [SerializeField] private PlayerMovement playerMovement;
    [SerializeField] private Animator animator;
    private static readonly int IsMoving = Animator.StringToHash("isMoving");

    #endregion

    #region Unity Methods

    // Start is called before the first frame update
    private void Start()
    {
        playerMovement = GetComponent<PlayerMovement>();
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    private void Update()
    {
        animator.SetBool(IsMoving, playerMovement.IsMoving());
    }
    
    #endregion
}
