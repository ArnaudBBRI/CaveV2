using UnityEngine;

namespace Buildwise.Switchable
{
    public class SwitchableObject : MonoBehaviour, ISwitchableObject
    {
        //public GameObject Parent { get; set; }
        [SerializeField]
        private int _groupID;

        public int GroupID { get => _groupID; set => _groupID = value; }
    }
}
