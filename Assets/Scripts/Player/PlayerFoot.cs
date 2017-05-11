using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerFoot : MonoBehaviour
{

    private List<string> tagList;
    private Vector2 box;

    private void Awake()
    {
        box = GetComponent<BoxCollider2D>().size * 1.1f;
    }

    public bool IsFloat
    {
        get;
        private set;
    }

    public void SetTags(List<string> tags)
    {
        if (tags == null)
        {
            tags = new List<string>();
        }
        tagList = tags;

    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (IsFloat)
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


    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (!IsFloat)
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

    }




}
