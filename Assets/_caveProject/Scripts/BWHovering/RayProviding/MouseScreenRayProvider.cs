using UnityEngine;

namespace Buildwise.Hovering
{
    public class MouseScreenRayProvider : BaseRayProvider
    {
        public override Ray CreateRay()
        {
            return Camera.main.ScreenPointToRay(Input.mousePosition);
        }
    }
}