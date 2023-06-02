using UnityAtoms.BaseAtoms;
using UnityEngine;

namespace Buildwise.Interactions
{
    public class InteractionMapper : MonoBehaviour
    {
        public IntEvent ActionIntEvent;

        private void Update()
        {
            if (Input.GetButtonDown("Action0")) 
            {
                ActionIntEvent.Raise(0);
            }
            else if (Input.GetButtonDown("Action1"))
            {
                ActionIntEvent.Raise(1);
            }
            else if (Input.GetButtonDown("Action2"))
            {
                ActionIntEvent.Raise(2);
            }
            else if (Input.GetButtonDown("Action3"))
            {
                ActionIntEvent.Raise(3);
            }
            else if (Input.GetButtonDown("Action4"))
            {
                ActionIntEvent.Raise(4);
            }
            else if (Input.GetButtonDown("Action5"))
            {
                ActionIntEvent.Raise(5);
            }
        }
    }
}