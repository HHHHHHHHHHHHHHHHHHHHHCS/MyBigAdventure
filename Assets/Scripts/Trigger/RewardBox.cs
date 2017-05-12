using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RewardBox : MonoBehaviour
{
    [SerializeField]
    private Sprite rewardSprite;
    [SerializeField]
    private Sprite getRewardSprite;

    private bool canGet = true;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (canGet)
        {
            if (collision.transform.position.y <= transform.position.y)
            {
                canGet = false;
                transform.GetComponent<SpriteRenderer>().sprite = getRewardSprite;
            }
        }
    }

}
