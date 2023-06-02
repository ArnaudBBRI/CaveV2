using System.Collections;
using UnityEngine;

namespace Buildwise.Interactions
{
    public class FlystickInteractionMapper : MonoBehaviour, IInteractionMapper
    {
        private InteractionsEnums _currentAction = InteractionsEnums.NoAction;
        public InteractionsEnums IdentifyAction()
        {
            return _currentAction;
        }
        
        public void SetCurrentAction(InteractionsEnums interaction)
        {
            _currentAction = interaction;
            StartCoroutine(ResetActionOnNextFrameCoroutine());
        }

        private IEnumerator ResetActionOnNextFrameCoroutine()
        {
            yield return new WaitForEndOfFrame();
            _currentAction = InteractionsEnums.NoAction;
        }
    }
}