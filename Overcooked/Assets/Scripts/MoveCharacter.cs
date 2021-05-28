using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveCharacter : MonoBehaviour
{
    public float playerSpeed = 3.0f;
    bool holding;
    public Transform Dest;
    public GameObject food;
    private GameObject hand;
    private CharacterController controller;
    private Vector3 playerVelocity;
    private bool groundedPlayer;
    private float gravityValue = -9.81f;
    private animationsChef anim;
    private bool isMove;
    private int currentAnim;
    private Transform leftArm;
    private Transform rightArm;

    // Start is called before the first frame update
    void Start()
    {
        holding = false;
        controller = GetComponent<CharacterController>();
        controller.detectCollisions = false;
        anim = GetComponent<animationsChef>();
        isMove = false;
        currentAnim = 2;
        leftArm = transform.Find("leftArm");
        rightArm = transform.Find("rightArm");
}

    // Update is called once per frame
    void Update()
    {
        groundedPlayer = controller.isGrounded;
        if (groundedPlayer && playerVelocity.y < 0)
        {
            playerVelocity.y = 0f;
        }

        Vector3 move = new Vector3(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical"));
        controller.Move(move * Time.deltaTime * playerSpeed);
        if (checkHold())
        {
            if (move == Vector3.zero)
            {
                if (isMove)
                {
                    isMove = false;
                    anim.IdleArms();
                    currentAnim = 0;
                }
                else if (currentAnim != 0)
                {
                    anim.IdleArms();
                    currentAnim = 0;
                }
            }
            else
            {
                gameObject.transform.forward = move;
                if (!isMove)
                {
                    isMove = true;
                    anim.MoveArms();
                    currentAnim = 1;
                }
                else if (currentAnim != 1)
                {
                    currentAnim = 1;
                    anim.MoveArms();
                }
            }     
        }
        else
        {
            if (move == Vector3.zero)
            {
                if (isMove)
                {
                    isMove = false;
                    anim.Relax();
                    currentAnim = 2;
                }
                else if (currentAnim != 2)
                {
                    anim.Relax();
                    currentAnim = 2;
                }
            }
            else
            {
                gameObject.transform.forward = move;
                if (!isMove)
                {
                    isMove = true;
                    anim.Move();
                    currentAnim = 3;
                }
                else if (currentAnim != 3)
                {
                    currentAnim = 3;
                    anim.Move();
                }
            }
        }
        playerVelocity.y += gravityValue * Time.deltaTime;
        controller.Move(playerVelocity * Time.deltaTime);
    }

    public void changeHold(bool state)
    {
        holding = state;
    }

    public void holdFood(GameObject f)
    {
        food = f;
        /*rightArm.localEulerAngles = new Vector3(-90, 0, 0);
        rightArm.localPosition = new Vector3(-0.137f, 0.486f, 0.637f);
        leftArm.localEulerAngles = new Vector3(-90, 0, 0);
        leftArm.localPosition = new Vector3(0.196f, 0.486f, 0.637f);
        if (food.tag == "Tool") leftArm.localPosition = new Vector3(0.256f, 0.66f, 0.637f);*/
    }

    public void objectHand(GameObject obj)
    {
        obj.transform.position = rightArm.Find("Hand").position;
        obj.transform.eulerAngles = rightArm.Find("Hand").eulerAngles;
        obj.transform.parent = rightArm.Find("Hand").transform;
        hand = obj;
    }

    public GameObject leaveObjectHand()
    {
        GameObject obj = hand;
        hand = null;
        return obj;
    }

    public void leaveFood()
    {
        food = null;
        /*rightArm.localEulerAngles = new Vector3(0, 0, 0);
        rightArm.localPosition = new Vector3(0.048f, 0.105f, -0.006f);
        leftArm.localEulerAngles = new Vector3(0, 0, 0);
        leftArm.localPosition = new Vector3(0.056f, 0.105f, -0.006f);*/
    }

    public GameObject getFood()
    {
        return food;
    }

    public void destroyFood()
    {
        Destroy(food, 0.2f);
        food = null;
        holding = false;
        Debug.Log(food);
        Debug.Log(holding);
    }

    public bool checkHold() { return holding; }
}
