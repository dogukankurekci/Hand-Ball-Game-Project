using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Controller_UP : MonoBehaviour
{
    LineRenderer lineRenderer;
    public Transform player1, player2, anglePoint;

    public GameObject bullet;
    public float bulletSpeed;

    Animator player1Anim;
    Animator player2Anim;

    private float speedModifier;

    public GameManager_UP gameManager_UP;

    private int numPoints = 25;
    private Vector3[] positions = new Vector3[25];

    private int currentPositionIndex = 0;

    public GameObject[] forward;
    private int fc = 0;
    public  int forwardLimit;


    void Start()
    {
        MiddlePoint();

        lineRenderer = GetComponent<LineRenderer>();
        lineRenderer.positionCount = numPoints;   
        
        speedModifier = 0.05f;
        lineRenderer.enabled = false;
        player2.transform.position = forward[0].transform.position;

        player1Anim = player1.GetComponent<Animator>();
        player2Anim = player2.GetComponent<Animator>();

    }

    void Update()
    {
        DrawQuadraticCurve();

        if (gameManager_UP.canMove)
        {

            if (Input.touchCount == 1)
            {
                Touch touch = Input.GetTouch(0);

                if (touch.phase == TouchPhase.Moved)
                {
                    anglePoint.transform.position = new Vector3(anglePoint.transform.position.x + touch.deltaPosition.x * speedModifier, 0, anglePoint.transform.position.z);
                    lineRenderer.enabled = true;
                    Camera.main.GetComponent<cameraFollow_UP>().zoomActive = true;
                }

                if (touch.phase == TouchPhase.Ended)
                {
                    player1Anim.SetBool("shoot", true);
                    InvokeRepeating("bulletFire", 0.5f, 0.015f);
                    Camera.main.GetComponent<cameraFollow_UP>().zoomActive = false;
                }
            }
        }


    }

    private void DrawQuadraticCurve()
    {
        for (int i = 1; i < numPoints + 1; i++)
        {
            float t = i / (float)numPoints;
            positions[i - 1] = CalculateQuadraticBezierPoint(t, player1.position, anglePoint.position, player2.position);
        }
        lineRenderer.SetPositions(positions);
    }
    private Vector3 CalculateQuadraticBezierPoint(float t, Vector3 p0, Vector3 p1, Vector3 p2)
    {
        float u = 1 - t;
        float tt = t * t;
        float uu = u * u;
        Vector3 p = uu * p0;
        p += 2 * u * t * p1;
        p += tt * p2;
        return p;
    }
    private void MiddlePoint()
    {

        Vector3 ortaNokta = new Vector3((player1.transform.position.x + player2.transform.position.x) / 2,
                                         (player1.transform.position.y + player2.transform.position.y) / 2,
                                         (player1.transform.position.z + player2.transform.position.z) / 2);

        anglePoint.transform.position = ortaNokta;
    }
    private bool nextStep(Vector3 nextPosition)
    {
        if (Vector3.Distance(bullet.transform.position, nextPosition) < 0.1f && currentPositionIndex < 24)
        {
            currentPositionIndex++;

            return true;
        }

        else
        {
            return false;
        }
    }
    private void goOn()
    {
        for (int i = 0; i < 1; i++)
        {
            if (fc == forwardLimit)
                break;

            for (int k = 0; k < fc + 1; k++)
            {
                forward[k].transform.position = player2.transform.position;
            }

            fc += 2;

            for (int j = 0; j < fc; j++)
            {
                player1.transform.position = forward[j].transform.position;
                j++;
                player2.transform.position = forward[j].transform.position;
            }

            bullet.transform.position = player1.transform.position;
        }
        
        MiddlePoint();
    }
    void bulletFire()
    {
        if (!nextStep(positions[currentPositionIndex]))
        {
            bullet.transform.position = Vector3.MoveTowards(bullet.transform.position, positions[currentPositionIndex], bulletSpeed * Time.deltaTime);
            if (!gameManager_UP.canMove)
                bullet.transform.position = positions[currentPositionIndex - 1] - new Vector3(0.5f,  0.5f, 0.5f);

        }

        if (bullet.transform.position == positions[24])
        {
            CancelInvoke("bulletFire");
            currentPositionIndex = 0;
            Camera.main.GetComponent<cameraFollow_UP>().target[0] = new Vector3(0,30, player1.transform.position.z + 25);
            Camera.main.GetComponent<cameraFollow_UP>().target[1] = new Vector3(0,40, player1.transform.position.z + 25);
            anglePoint.transform.position = new Vector3(0, 0, anglePoint.transform.position.z);

            goOn();

            player1Anim.SetBool("shoot", false);
        }

        if (!gameManager_UP.canMove)
            bulletSpeed = 0f;

        lineRenderer.enabled = false;

        if (bullet.transform.position == forward[forwardLimit - 1].transform.position)
        {
            player2Anim.SetBool("dance", true);
            bullet.SetActive(false);
            gameManager_UP.canMove = false;

            Camera.main.GetComponent<cameraFollow_UP>().target[2] = new Vector3(0, -20, bullet.GetComponent<Bullet_UP>().bulletTransform.position.z - 15);
            Camera.main.GetComponent<cameraFollow_UP>().transform.eulerAngles = new Vector3(0,0,0);

            Camera.main.GetComponent<cameraFollow_UP>().zoomTarget = true;

        }
    }


}

