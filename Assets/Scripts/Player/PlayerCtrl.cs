using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCtrl : MonoBehaviour
{
    private static PlayerCtrl _instance;

    public static PlayerCtrl Instance { get { return _instance; } }

    private List<string> tagList = new List<string>() { Tags.floor };

    private Rigidbody2D rigi;
    private PlayerFoot foot;

    [SerializeField]
    private LayerMask layer;
    [SerializeField]
    private float moveSpeed = 10;
    [SerializeField]
    private float jumpSpeed = 8.5f;



    private bool isJumpAndMove;


    void Awake()
    {
        _instance = this;
        rigi = GetComponent<Rigidbody2D>();
        foot = transform.Find("Foot").GetComponent<PlayerFoot>();
        foot .SetTagsLayer(tagList,layer);
    }

    private void Update()
    {
        Move();
    }

    public bool GetIsFloat()
    {
        return foot.IsFloat;
    }

    void Move()
    {
        bool isfloat = GetIsFloat();
        bool isJumping = PlayerAnimator.Instance.GetIsJumping;
        float deltaTime = Time.deltaTime;
        if (!isJumping && !isfloat)
        {
            bool jumpAndMove = false;
            Vector3 endPos = transform.position;
            if (Input.GetKey(KeyCode.A))
            {
                PlayerAnimator.Instance.TurnLeft();
                PlayerAnimator.Instance.SetIsRun(true);
                jumpAndMove = true;
                endPos += Vector3.left * moveSpeed * Time.fixedDeltaTime;
            }
            else if (Input.GetKey(KeyCode.D))
            {
                PlayerAnimator.Instance.TurnRight();
                PlayerAnimator.Instance.SetIsRun(true);
                jumpAndMove = true;
                endPos += Vector3.right * moveSpeed * Time.deltaTime;
            }
            else
            {
                PlayerAnimator.Instance.SetIsRun(false);
            }
            if (Input.GetKey(KeyCode.Space))
            {
                if (jumpAndMove)
                {
                    isJumpAndMove = true;
                }
                else
                {
                    isJumpAndMove = false;
                }
                PlayerAnimator.Instance.SetIsRun(false);
                PlayerAnimator.Instance.SetJumpTrigger();
                endPos += Vector3.up * jumpSpeed * Time.deltaTime;
            }
            if (endPos != transform.position)
            {
                rigi.MovePosition(endPos);
            }
        }
        else if (isfloat)
        {
            Vector3 endPos = transform.position;
            if (isJumpAndMove)
            {
                if (PlayerAnimator.Instance.GetIsRight)
                {
                    endPos += Vector3.right * moveSpeed * Time.deltaTime / 2;
                }
                else
                {
                    endPos += Vector3.left * moveSpeed * Time.deltaTime / 2;
                }
            }
            if (isJumping)
            {
                endPos += Vector3.up * jumpSpeed * Time.deltaTime;
            }
            else
            {
                endPos += Vector3.down * 2 * jumpSpeed * Time.deltaTime;
            }
            if (endPos != transform.position)
            {
                rigi.MovePosition(endPos);
            }
        }
        else if (!isJumpAndMove)
        {
            isJumpAndMove = false;
        }

    }

    public void OnDestroy()
    {
        _instance = null;
    }

}
