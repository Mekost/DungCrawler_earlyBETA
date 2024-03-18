using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

// [RequireComponent(typeof(BoxCollider2D))] // tworzy automatycznie BoxCollider2D
public class Collidable : MonoBehaviour
{
    public ContactFilter2D filter;
    private BoxCollider2D boxCollider;
    private Collider2D[] hits = new Collider2D[10]; // mówi z czym siê zderzy³a postaæ

    protected virtual void Start()
    {
        boxCollider = GetComponent<BoxCollider2D>();

    }

    protected virtual void Update()
    {
        //kolizje
        boxCollider.OverlapCollider(filter, hits);
        for (int i = 0; i < hits.Length; i++)
        {
            if (hits[i] == null)
                continue;
            OnCollide(hits[i]);
            
            hits[i] = null; // czyszczenie tablicy
        }
    }

    protected virtual void OnCollide(Collider2D coll)
    {
        Debug.Log(coll.name);
    }
}
