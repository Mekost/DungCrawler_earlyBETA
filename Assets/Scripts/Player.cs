using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    private BoxCollider2D boxCollider;
    private Vector3 moveDelta;
    private RaycastHit2D hit;
    // tu mo¿na deklarowaæ swoje rzeczy

    private void Start()
    {
        boxCollider = GetComponent<BoxCollider2D>();
    }

    private void FixedUpdate()
    {
        float x = Input.GetAxisRaw("Horizontal"); // kontrola wasd
        float y = Input.GetAxisRaw("Vertical");

        moveDelta = new Vector3(x, y, 0); // resetowanie moveDelta

        // zmiana kierunku sprite'a w zale¿noœci od kierunku (lewo, prawo)
        // odpowiada za "Scale" w zak³adce "transform"
        if (moveDelta.x > 0)
            transform.localScale = Vector3.one;
        else if (moveDelta.x < 0)
            transform.localScale = new Vector3(-1, 1, 1); // odpowiada za obrót - przy (-1, 0, 0) ziomek znika

        hit = Physics2D.BoxCast(transform.position, boxCollider.size, 0, new Vector2(0, moveDelta.y), Mathf.Abs(moveDelta.y * Time.deltaTime), LayerMask.GetMask("Actor", "Blocking"));
        if (hit.collider == null)
        {
            // odpowiada za poruszanie siê postaci
            transform.Translate(0, moveDelta.y * Time.deltaTime, 0);
        }

        hit = Physics2D.BoxCast(transform.position, boxCollider.size, 0, new Vector2(moveDelta.x, 0), Mathf.Abs(moveDelta.x * Time.deltaTime), LayerMask.GetMask("Actor", "Blocking"));
        if (hit.collider == null)
        {
            // odpowiada za poruszanie siê postaci
            transform.Translate(moveDelta.x * Time.deltaTime, 0, 0);

        }
    }
}
