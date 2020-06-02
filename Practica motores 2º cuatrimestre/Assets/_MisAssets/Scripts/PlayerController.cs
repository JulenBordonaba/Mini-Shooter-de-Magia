using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class PlayerController : MonoBehaviour
{
    [Header("CAMERA")]
    public Camera mainCamera;
    [Header("MOVEMENT")]
    public float velocity = 4f;
    public float stoppingDistance = 8f;
    public Animator playerAnimator;


    private Vector3 inputDirection;
    private Vector3 movement;

    private Rigidbody rb;

    private Plane playerPlane;
    private Vector3 playerToMouse;

    private PlayerManager playerManager;

    //private NavMeshAgent agent;


    private void Awake()
    {
        //agent = GetComponent<NavMeshAgent>();
        playerManager = GetComponent<PlayerManager>();
        rb = GetComponent<Rigidbody>();
        if(playerAnimator==null)
        {

            playerAnimator = GetComponent<Animator>();
        }
        playerPlane = new Plane(transform.up, transform.position );
        //agent.speed = velocity;
    }

    private void FixedUpdate()
    {
        if (playerManager.Freezed) return;
        float h = Input.GetAxis("Horizontal"); //izquierda/derecha
        float v = Input.GetAxis("Vertical"); //alante/atrás

        inputDirection = new Vector3(h, 0, v);

        //if(Input.GetKeyDown(KeyCode.Mouse1))
        //{
        //    SetObjective();
        //}

        //mover el personaje
        MovePlayer(inputDirection);
        //girar el personaje
        RotatePlayer();
        //animar el personaje
        AnimatePlayer(inputDirection);
    }

    //void SetObjective()
    //{
    //    Vector3 mouseScreenPosition = Input.mousePosition;
    //    bool isTargeteable = false;

    //    Vector3 targetPosition = ScreenPointToWorldPointOnPlane(mouseScreenPosition, playerPlane, mainCamera, out isTargeteable);

    //    if(isTargeteable)
    //    {
    //        agent.stoppingDistance = stoppingDistance;
    //    }
    //    else
    //    {
    //        agent.stoppingDistance = 0;
    //    }

    //    agent.SetDestination(targetPosition);

    //}

    void RotatePlayer()
    {
        Vector3 mouseScreenPosition = Input.mousePosition;
        //bool isTargeteable = false;

        Vector3 mouseWorldPosition = ScreenPointToWorldPointOnPlane(mouseScreenPosition, playerPlane, mainCamera);

        mouseWorldPosition.y = 1;

        playerToMouse = mouseWorldPosition - transform.position;

        //playerToMouse = agent.steeringTarget - transform.position;

        playerToMouse.y = transform.position.y;
        playerToMouse.Normalize();

        Quaternion rot = Quaternion.LookRotation(playerToMouse);

        transform.rotation=rot;
    }

    void AnimatePlayer(Vector3 direction)
    {
        

        Vector3 localDirectionForward = transform.TransformDirection(new Vector3(-direction.x, direction.y, direction.z)).normalized;
        Vector3 localDirectionStrafe = transform.TransformDirection(new Vector3(direction.x, direction.y, -direction.z)).normalized;

        //print(localDirectionForward);
        /*if(Mathf.Abs(transform.forward.x)>Mathf.Abs(transform.forward.z))
        {
            localDirection.x = -localDirection.x;
        }*/
        

        playerAnimator.SetFloat("Forward", localDirectionForward.z);
        playerAnimator.SetFloat("Strafe", localDirectionStrafe.x);
    }

    void MovePlayer(Vector3 direction)
    {


        movement = (direction.normalized * velocity * Time.fixedDeltaTime);
        rb.MovePosition(rb.position + movement);
    }

    Vector3 ScreenPointToWorldPointOnPlane(Vector3 screenPoint, Plane plane, Camera camera)
    {
        Ray ray = camera.ScreenPointToRay(screenPoint);

        //RaycastHit hit;

        //if(Physics.Raycast(ray, out hit, Mathf.Infinity, LayerMask.GetMask("Targeteable")))
        //{
        //    isTargetteable = true;
        //    return hit.point;
        //}
        //else
        {
            float rayDistance = 0;
            plane.Raycast(ray, out rayDistance);
            return ray.GetPoint(rayDistance);
        }

        

    }



}
