namespace Protocols;

public interface IProtocol
{
    /// <summary>
    /// Add a step to the end of the protocol
    /// </summary>
    /// <param name="step">Step to be added</param>
    void AddStep(Step step);
    
    /// <summary>
    /// Remove a step at a provided index in the list of steps
    /// </summary>
    /// <param name="index">Index at which step will be removed</param>
    void RemoveStepAt(int index);
    
    /// <summary>
    /// Insert a step at a certain place in the protocol (moves the step at that index up by one)
    /// </summary>
    /// <param name="index">Index for where the step will be placed</param>
    /// <param name="step">Step to be added at the index</param>
    void InsertStepAt(int index, Step step);
    
    /// <summary>
    /// Swap two steps in the protocol by their indices
    /// </summary>
    /// <param name="index1">Index of one of the steps</param>
    /// <param name="index2"></param>
    void SwapStepsAt(int index1, int index2);
    
    /// <summary>
    /// Update a step within the protocol at the provided index
    /// </summary>
    /// <param name="index">Index of the step which is to be updated</param>
    /// <param name="step">Content which will be used to update the step</param>
    void UpdateStepAt(int index, Step step);
    
    /// <summary>
    /// Get the steps as a list
    /// </summary>
    /// <returns></returns>
    List<Step> GetSteps();

    /// <summary>
    /// Get the date time this protocol was createed
    /// </summary>
    /// <returns></returns>
    DateTime GetCreationDateTime();
    
    /// <summary>
    /// Get the date time this protocol was last modified
    /// </summary>
    /// <returns></returns>
    DateTime GetLastUpdateDateTime();
    
    /// <summary>
    /// Get the date time this protocol was executed at
    /// </summary>
    /// <returns></returns>
    DateTime GetExecutionDateTime();
}