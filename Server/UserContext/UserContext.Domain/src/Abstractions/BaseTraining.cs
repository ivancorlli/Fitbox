using SharedKernell.src.Entity;
using UserContext.Domain.src.Interface.Entity;

namespace UserContext.Domain.src.Abstractions;

public abstract class BaseTraining : AggregateRoot, IBaseTraining
{
    public string Name { get; protected set; }

    protected BaseTraining(string name) 
    {
        Name = name;
    }
}
