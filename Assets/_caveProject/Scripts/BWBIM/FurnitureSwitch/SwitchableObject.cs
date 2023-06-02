using UnityEngine;

namespace Buildwise.BIM
{
    public class SwitchableObject : MonoBehaviour, ISwitchableObject
    {
        public GameObject Parent { get; set; }
    }
}
