using UnityEngine;

namespace Buildwise.Switchable
{
    internal interface ISwitchableObject
    {
        //GameObject Parent { get; set; }
        public int GroupID { get; set; }
    }
}