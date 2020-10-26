using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class Breakable : MonoBehaviour
{
    public Tilemap BreakableMap;

    private void Start()
    {
        BreakableMap = GetComponent<Tilemap>();
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Projectile"))
        {
            Vector3 hitPos = Vector3.zero;
            foreach (ContactPoint2D hitPoint in collision.contacts)
            {
                hitPos.x = hitPoint.point.x - 0.01f * hitPoint.normal.x;
                hitPos.y = hitPoint.point.y - 0.01f * hitPoint.normal.y;
                BreakableMap.SetTile(BreakableMap.WorldToCell(hitPos), null);
            }
        }
    }
}
