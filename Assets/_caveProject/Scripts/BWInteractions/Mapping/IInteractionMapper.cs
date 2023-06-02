namespace Buildwise.Interactions
{
    /// <summary>
    /// Interface allowing to identify what action should be triggered based on the input received.
    /// </summary>
    internal interface IInteractionMapper
    {
        void RaiseAction(int action);
    }
}