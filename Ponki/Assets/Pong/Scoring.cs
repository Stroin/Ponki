using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class Scoring : MonoBehaviour
{
    public EventTrigger.TriggerEvent scoreTrigger;

   private void OnCollisionEnter2D(Collision2D collision)
    {
        BallController ballController = collision.gameObject.GetComponent<BallController> ();

        if (ballController != null)
        {
            BaseEventData eventData = new BaseEventData(EventSystem.current);

            this.scoreTrigger.Invoke(eventData);
        }

    }

}
