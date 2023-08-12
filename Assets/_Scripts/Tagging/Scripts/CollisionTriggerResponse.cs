using UnityEngine;
using Tagging;
using UnityEngine.Events;

public class CollisionTriggerResponse : MonoBehaviour
{
    [SerializeField]
    private UnityEvent<GameObject> OnTriggerEnterResponse;

    [SerializeField]
    private UnityEvent<GameObject> OnTriggerExitResponse;

    [SerializeField]
    private UnityEvent<GameObject> OnTriggerEnterResponse2D;

    [SerializeField]
    private UnityEvent<GameObject> OnTriggerExitResponse2D;

    [SerializeField]
    private UnityEvent<GameObject> OnCollisonEnterResponse;

    [SerializeField]
    private UnityEvent<GameObject> OnCollisonExitResponse;

    [SerializeField]
    private UnityEvent<GameObject> OnCollisonEnterResponse2D;

    [SerializeField]
    private UnityEvent<GameObject> OnCollisonExitResponse2D;

    [SerializeField]
    private Tagger targetTag;

    private void OnTriggerEnter2D(Collider2D other)
    {
        CheckTag(other.gameObject, OnTriggerEnterResponse2D);
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        CheckTag(other.gameObject, OnTriggerExitResponse2D);
    }

    private void OnTriggerEnter(Collider other)
    {
        CheckTag(other.gameObject, OnTriggerEnterResponse);
    }

    private void OnTriggerExit(Collider other)
    {
        CheckTag(other.gameObject, OnTriggerExitResponse);
    }

    private void OnCollisionEnter(Collision collision)
    {
        CheckTag(collision.gameObject, OnCollisonEnterResponse);
    }

    private void OnCollisionExit(Collision collision)
    {
        CheckTag(collision.gameObject, OnCollisonExitResponse);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        CheckTag(collision.gameObject, OnCollisonEnterResponse2D);
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        CheckTag(collision.gameObject, OnCollisonExitResponse2D);
    }

    private void CheckTag(GameObject other, UnityEvent<GameObject> unityEvent)
    {
        if (other.TryGetComponent(out TagManager tagManager))
        {
            if (tagManager.tagList.Contains(targetTag))
            {
                unityEvent.Invoke(other.gameObject);
            }
        }
    }
}