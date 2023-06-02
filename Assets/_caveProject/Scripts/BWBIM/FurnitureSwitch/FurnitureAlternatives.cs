using UnityEngine;

namespace Buildwise.BIM
{
    [CreateAssetMenu(fileName = "FurnitureAlternatives", menuName = "Buildwise/Furniture Alternatives")]
    public class FurnitureAlternatives : ScriptableObject
    {
        public AlternativesList[] Alternatives;
    }
}