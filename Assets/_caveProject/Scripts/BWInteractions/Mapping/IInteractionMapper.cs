namespace Buildwise.Interactions
{
    /// <summary>
    /// Interface allowing to identify what action should be triggered based on the input received.
    /// </summary>
    internal interface IInteractionMapper
    {
        InteractionsEnums IdentifyAction();
    }
}