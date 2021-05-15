using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveCharacter : MonoBehaviour
{
    public float playerSpeed = 3.0f;
    bool holding;
    public Transform Dest;
    public GameObject food;
    private CharacterController controller;
    private Vector3 playerVelocity;
    private bool groundedPlayer;
    private float gravityValue = -9.81f;

    // Start is called before the first frame update
    void Start()
    {
        holding = false;
        controller = this.GetComponent<CharacterController>();
        controller.detectCollisions = false;
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

        if (move != Vector3.zero)
        {
            gameObject.transform.forward = move;
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
    }

    public void leaveFood()
    {
        food = null;
    }

    public GameObject getFood()
    {
        return food;
    }

    public void destroyFood()
    {
        Destroy(food);
        food = null;
        holding = false;
    }

    public bool checkHold() { return holding; }
}
