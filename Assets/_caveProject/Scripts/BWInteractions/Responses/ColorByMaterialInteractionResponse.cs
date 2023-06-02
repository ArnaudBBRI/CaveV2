using UnityEngine;
using Buildwise.Materials;
using Buildwise.Core;
using Buildwise.Hovering;

namespace Buildwise.Interactions
{
    public class ColorByMaterialInteractionResponse : MonoBehaviour, IInteractionResponse
    {
        [SerializeField] private GameObject _hoveringManager;
        [SerializeField] private BIMColorStateVariable _bimColorState;
        private HelperFunctions _helper;
        private IHoveringResponse[] _hoveringResponses;

        private void Start()
        {
            _helper = new HelperFunctions();

            if (_hoveringManager == null)
            {
                Debug.LogError("Missing HoveringManager on ColorCategoryByNextMaterialInteractionResponse");
                return;
            }
            else
            {
                _hoveringResponses = _hoveringManager.GetComponents<IHoveringResponse>();
                if (_hoveringResponses == null)
                {
                    Debug.LogError("Missing IHoveringResponse Component on the HoveringManager");
                    return;
                }
            }
        }
        
        public void OnAction(Transform selection, RaycastHit hit)
        {
            if (_bimColorState.Value != BIMColorState.NoBIMColor) return;
            int index = _helper.GetMaterialIndex(selection, hit);
            
            if (selection.TryGetComponent(out IObjectMaterialHandler bo))
            {
                foreach (var hoveringResponse in _hoveringResponses)
                {
                    hoveringResponse.ClearResponse(selection);
                }
                Material mat = bo.GetNextMaterial(index);
                bo.ApplyMaterialOnSubmesh(index, mat);
            }
        }
    }
}