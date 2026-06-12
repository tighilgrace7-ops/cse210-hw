public class SimpleGoal : Goal
{
    private bool _IsComplete;

    public SimpleGoal(string name, string description, int points) 
        : base(name, description, points)
    {
        _IsComplete = false;
    }

    public SimpleGoal(string name, string description, int points, bool isComplete)
        : base(name, description, points)
    {
        _IsComplete = isComplete;
    }

    public override int RecordEvent()
    {
        if(!_IsComplete)
        {
            _IsComplete = true;
            return GetPoints();
        }

        return 0;
    }

    public override bool IsComplete()
    {
        return _IsComplete;
    }

    public override string GetDetailsString()
    {
        string status = _IsComplete ? "[X]" : "[ ]";

        return $"{status} {GetName()} ({GetDescription()})";
    }

    public override string GetStringRepresentation()
    {
        return $"SimpleGoal:{GetName()}, {GetDescription()}, {GetPoints()}, {_IsComplete}";
    }

}