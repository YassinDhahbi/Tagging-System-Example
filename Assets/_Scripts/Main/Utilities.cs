using System.Collections;
using UnityEngine;

namespace Utilities
{
    [CreateAssetMenu(fileName = "Utilities Manager", menuName = "Managers/Utilities")]
    public class Utilities : ScriptableObject
    {
        public void Destroy(GameObject target)
        {
            Destroy(target);
        }

        public void Enable(GameObject target)
        {
            target.SetActive(true);
        }

        public void Disable(GameObject target)
        {
            target.SetActive(false);
        }

        public void AnimateUpDownLoop(GameObject target)
        {
            var targetPos = target.transform.localPosition;
            LeanTween.moveLocalY(target, targetPos.y + 0.05f, 1f).setLoopPingPong();
        }
    }
}