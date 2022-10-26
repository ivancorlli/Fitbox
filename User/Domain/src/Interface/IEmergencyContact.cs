using Domain.src.Entity;

namespace Domain.src.Interface
{
    public interface IEmergencyContact
    {
          void Add(EmergencyContact user);
        void Remove(EmergencyContact user);
        EmergencyContact GetById(Guid Id);
        IEnumerable<EmergencyContact> Find();     
    }
}