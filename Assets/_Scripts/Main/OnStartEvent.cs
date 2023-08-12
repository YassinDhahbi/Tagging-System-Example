using UnityEngine;
using UnityEngine.Events;

namespace Utilities
{
    public class OnStartEvent : MonoBehaviour
    {
        [SerializeField]
        private UnityEvent<GameObject> OnGameStart;

        // Start is called before the first frame update
        private void Start()
        {
            OnGameStart.Invoke(gameObject);
        }
    }
}