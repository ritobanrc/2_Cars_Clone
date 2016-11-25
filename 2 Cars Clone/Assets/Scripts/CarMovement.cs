using UnityEngine;
using System.Collections;
using System.Collections.Generic;

[RequireComponent(typeof(Rigidbody2D))]
public class CarMovement : MonoBehaviour
{
    public float speed;
    public string axisSuffix;
    public Rigidbody2D otherCar;
    public int negatePositions;

    public int lane; //0 is left lane
    bool isChangingLanes = false;
    Rigidbody2D rb;
    int laneChangeModifier;
    Vector2 movement;

    int h;
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        h = (int)Input.GetAxisRaw("Horizontal" + axisSuffix);

    }

    public void Move(Vector2 _movement)
    {
        movement += _movement;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (h == -1 && lane > 0 && !isChangingLanes)
        {
            laneChangeModifier = -1;
            StartCoroutine(ChangeLane((negatePositions < 0) ? 40 : -40, 0.4f, negatePositions * 2f));
        }
        if (h == 1 && lane < 1 & !isChangingLanes)
        {
            laneChangeModifier = +1;
            StartCoroutine(ChangeLane((negatePositions < 0) ? -40 : 40, 0.4f, negatePositions * 0.6f));
        }
        //rb.MovePosition(rb.position + Vector2.up * speed * Time.fixedDeltaTime);
        Move(Vector2.up * speed * Time.fixedDeltaTime);
        rb.MovePosition(movement + rb.position);
        movement = Vector2.zero;
    }

    void OnCollisionEnter(Collision col)
    {
        Debug.Log(col.collider.name);
    }



    IEnumerator ChangeLane(float angle, float time, float finalXPos)
    {
        float turn = 0;
        if (isChangingLanes)
            yield break;
        isChangingLanes = true;
        float t = 0;
        while (t < 1)
        {
            t += 2 * Time.deltaTime / time;
            turn = Mathf.Lerp(turn, angle, t / 2);
            //rb.MovePosition(new Vector2(Mathf.Lerp(rb.position.x, finalXPos, t/2), 0));
            //transform.position = new Vector3(Mathf.Lerp(rb.position.x, finalXPos, t / 2), 0, 0);
            Move(new Vector2(Mathf.Lerp(0, finalXPos - rb.position.x, t / 2), 0));
            transform.eulerAngles = new Vector3(0, 0, turn / 2);
            yield return null;
        }
        t = 0;
        while (t < 1)
        {
            t += 2 * Time.deltaTime / time;
            turn = Mathf.Lerp(turn, 0, t / 2 + 0.5f);
            //rb.MovePosition(new Vector2(Mathf.Lerp(rb.position.x, finalXPos, t / 2), 0));
            //transform.position = new Vector3(Mathf.Lerp(rb.position.x, finalXPos, t / 2 + 0.5f), 0, 0);
            Move(new Vector2(Mathf.Lerp(0, finalXPos - rb.position.x, t / 2 + 0.5f), 0));
            transform.eulerAngles = new Vector3(0, 0, turn);
            yield return null;
        }
        lane += laneChangeModifier;
        isChangingLanes = false;
    }

}
