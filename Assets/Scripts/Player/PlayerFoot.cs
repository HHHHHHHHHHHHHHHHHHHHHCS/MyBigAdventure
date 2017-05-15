using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerFoot : MonoBehaviour
{
    private LayerMask layer;
    private List<string> tagList;
    private Vector2 box;



    [SerializeField]
    private bool isFloat;

    public bool IsFloat
    {
        get
        {
            Vector3 start1 = transform.position;
            start1.x += box.x * 1.5f;
            Vector3 start2 = transform.position;
            start2.x -= box.x * 1.5f;
            Vector3 end1 = start1;
            end1.y -= box.y * 1.5f;
            Vector3 end2 = start2;
            end2.y -= box.y * 1.5f;
            RaycastHit2D ray1 = Physics2D.Linecast(start1, end1, layer);
            RaycastHit2D ray2 = Physics2D.Linecast(start2, end2, layer);
            if (ray1.collider != null || ray2.collider != null)
            {

                isFloat = false;
            }
            else
            {
                isFloat = true;
            }

            return isFloat;
        }

        private set
        {
            isFloat = value;
        }
    }

    private void Awake()
    {
        box = GetComponent<BoxCollider2D>().size;
    }

    public void SetTagsLayer(List<string> tags, LayerMask _layer)
    {
        if (tags == null)
        {
            tags = new List<string>();
        }
        tagList = tags;
        layer = _layer;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {

        GameObject go = collision.gameObject;
        foreach (var i in tagList)
        {
            if (go.CompareTag(i))
            {

                IsFloat = false;
                break;
            }
        }



    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        GameObject go = collision.gameObject;
        foreach (var i in tagList)
        {
            if (go.CompareTag(i))
            {
                IsFloat = true;
                break;
            }
        }


    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Vector3 start1 = transform.position;
        start1.x += box.x * 1.5f;
        Vector3 start2 = transform.position;
        start2.x -= box.x * 1.5f;
        Vector3 end1 = start1;
        end1.y -= 1.5f * box.y * 100;
        Vector3 end2 = start2;
        end2.y -= 1.5f * box.y * 100;
        Gizmos.DrawLine(start1, end1);
        Gizmos.DrawLine(start2, end2);
    }
}
