/// <summary>
/// Interface for objects that can be interacted with.
/// </summary>
/// <typeparam name="T">The type of the main interaction data.</typeparam>
public interface IInteractable<T>
{
    /// <summary>
    /// Method called when the object is interacted with.
    /// </summary>
    /// <param name="interactionData">The main interaction data.</param>
    /// <param name="interactMessage">Optional message related to the interaction.</param>
    /// <param name="otherInteractionData">Optional additional interaction data.</param>
    /// <param name="anotherInteractionData">Another optional additional interaction data.</param>
    void Interact(T interactionData, string interactMessage = null, object otherInteractionData = null, object anotherInteractionData = null);
}