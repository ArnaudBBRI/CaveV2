/*
using UnityEngine;
using UVRPN.Core;
using ScriptableObjectArchitecture;

namespace Buildwise.Interactions
{
    public class BuildwiseLaserInteractionMapper : MonoBehaviour, IInteractionMapper
    {
        private InteractionsEnums _currentAction = InteractionsEnums.NoAction;
        private Coroutine setCurrentAction;
        private VRPN_Button[] _buttons;
        public IntGameEvent ActionIntEvent;
        
        private void Start()
        {
            var flystick = FindObjectOfType<VRPN_Button>().gameObject;
            _buttons = flystick.GetComponents<VRPN_Button>();
            foreach (var button in _buttons)
            {
                Debug.Log($"Added SetCurrentAction listener to {button}");
                button.OnButtonDown.AddListener(SetCurrentAction);
            }
        }
        
        public InteractionsEnums IdentifyAction()
        {
            return _currentAction;
        }
        
        private void SetCurrentAction(int buttonIndex)
        {
            if (setCurrentAction != null)
                StopCoroutine(setCurrentAction);
            _currentAction = InteractionsEnums.NoAction;
            Debug.Log($"Now raising ActionIntEvent from SetCurrentAction, with button index {buttonIndex}");
            ActionIntEvent.Raise(buttonIndex);
            // TODO: input manager for all inputs could solve the menu Onclick?
        }
    }
}
*/