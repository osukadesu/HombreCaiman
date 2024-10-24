using UnityEngine;
public class PlayerController : MonoBehaviour
{
    public Animator characterAnim;
    public Rigidbody playerRB;
    public Vector3 moveDirection;
    public CapsuleCollider human, caiman;
    public GameObject[] humanBody;
    public GameObject caimanBody;
    public float horizontalMove, verticalMove, playerSpeed;
    public bool canJump, isWalk, canRun, isRun, isCaiman = false, canSwim, canMove;
    void Start()
    {
        playerSpeed = 2.5f;
        canMove = true;
        canJump = true;
        canRun = true;
        canSwim = false;
        human.enabled = true;
        caiman.enabled = false;
        humanBody[0].SetActive(true);
        humanBody[1].SetActive(true);
        caimanBody.SetActive(false);
        characterAnim.SetBool("walk", false);
        characterAnim.SetBool("run", false);
    }
    void Update()
    {
        if (canMove)
        {
            horizontalMove = Input.GetAxisRaw("Horizontal");
            verticalMove = Input.GetAxisRaw("Vertical");
        }
        else
        {
            horizontalMove = 0;
            verticalMove = 0;
        }
        moveDirection = new Vector3(horizontalMove, 0, verticalMove).normalized;
        /* 
        transform.Rotate(0, horizontalMove * Time.deltaTime * 50f, 0);
        if (moveDirection != Vector3.zero)
        {
        Quaternion targetRotation = Quaternion.LookRotation(moveDirection);
        transform.rotation = Quaternion.Slerp(transform.rotation, targetRotation, 5f * Time.deltaTime);
        } 
        */
        if (canJump)
        {
            if (Input.GetKeyDown(KeyCode.Space))
            {
                playerRB.AddForce(new(0, 4f, 0), ForceMode.Impulse);
            }
        }
        SetAnimations();
        if (isRun)
        {
            characterAnim.SetFloat("animSpeed", 1.7f);
        }
        else characterAnim.SetFloat("animSpeed", 1f);
        characterAnim.SetBool("swimming", canSwim && moveDirection != Vector3.zero);
        characterAnim.SetBool("caimaniando", isCaiman && moveDirection != Vector3.zero);
    }
    void FixedUpdate()
    {
        /*
        Vector3 movement = moveDirection * playerSpeed * Time.fixedDeltaTime;
        playerRB.MovePosition(playerRB.position + movement);
        */
        Quaternion deltaRotation = Quaternion.Euler(0, horizontalMove * Time.fixedDeltaTime * 100f, 0);
        playerRB.MoveRotation(playerRB.rotation * deltaRotation);
        Vector3 movement = transform.forward * verticalMove * Time.fixedDeltaTime * playerSpeed;
        playerRB.MovePosition(playerRB.position + movement);
    }
    void SetAnimations()
    {
        isWalk = horizontalMove != 0f || verticalMove != 0f;
        isRun = isWalk && canRun && Input.GetKey(KeyCode.LeftShift);
        characterAnim.SetBool("walk", isWalk);
        characterAnim.SetBool("run", isRun);
        playerSpeed = isRun ? 4f : 2.5f;
    }
}