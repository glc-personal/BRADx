namespace Protocols;

public class Protocol : IProtocol
{
    private string _name;
    private string _description;
    private DateTime _creationDate;
    private DateTime _modificationDate;
    private DateTime _executionDate;
    private bool _isActive;
    private List<Step> _steps;

    public Protocol(string name, string description)
    {
        _name = name;
        _description = description;
        _steps = new List<Step>();
        _creationDate = DateTime.Now;
        _modificationDate = DateTime.Now;
        _isActive = false;
    }

    public void AddStep(Step step)
    {
        UpdateModificationDate();
        _steps.Add(step);
    }

    public void RemoveStepAt(int index)
    {
        UpdateModificationDate();
        _steps.RemoveAt(index);
    }

    public void InsertStepAt(int index, Step step)
    {
        UpdateModificationDate();
        _steps.Insert(index, step);
    }

    public void SwapStepsAt(int index1, int index2)
    {
        UpdateModificationDate();
        (_steps[index1], _steps[index2]) = (_steps[index2], _steps[index1]);
    }

    public void UpdateStepAt(int index, Step step)
    {
        UpdateModificationDate();
        _steps[index] = step;
    }

    public List<Step> GetSteps()
    {
        return _steps;
    }

    public DateTime GetCreationDateTime()
    {
        return _creationDate;
    }

    public DateTime GetLastUpdateDateTime()
    {
        return _modificationDate;
    }

    public DateTime GetExecutionDateTime()
    {
        return _executionDate;
    }

    private void UpdateModificationDate()
    {
        _modificationDate = DateTime.Now;
    }
}