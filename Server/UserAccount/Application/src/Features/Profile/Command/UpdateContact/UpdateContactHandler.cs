using System.Reflection.Metadata;
using Application.src.Errors;
using Domain.src.Enum;
using Domain.src.Interface;
using Domain.src.ValueObject;
using Shared.src.Error;
using Shared.src.Interface.Command;

namespace Application.src.Features.Profile.Command.UpdateContact;

public class UpdateContactHandler : IHandler<UpdateContactCommand, Result>
{
    private readonly IUnitOfWork _UnitOfWork;

    public UpdateContactHandler(IUnitOfWork unitOfWork)
    {
        _UnitOfWork = unitOfWork;
    }

    public async Task<Result> Handle(UpdateContactCommand request, CancellationToken cancellationToken)
    {
        var input = request.Input;
        // Obtenemos perfil
        var profileFound = await _UnitOfWork.PersonReadRepository.GetById(input.Id);
        var profile = profileFound.Value;
        var contact = profile.EmergencyContact;

        if (contact != null)
        {
            // Creamos nombre
            PersonName? name = null;
            if(input.name != null && input.surname != null)
            {
                var newName = PersonName.Create(input.name,input.surname);
                name = newName.Value;
            }
            // Creamos relacion
            RelationShip? relationship = null;
            if(input.relationship != null)
            {
                relationship = (RelationShip)Enum.Parse(typeof(RelationShip),input.relationship);
            }
            // Creamos telefono
            ContactPhone? phone = null;
            if(input.areaCode != null && input.number != null)
            { 
                if(input.prefix != null)
                {
                var newPhone = ContactPhone.Create(input.areaCode.Value,input.number.Value,input.prefix);
                phone = newPhone.Value;
                }else {
                var newPhone = ContactPhone.Create(input.areaCode.Value,input.number.Value);
                phone = newPhone.Value;
                }
            }

            // Actualizamos contacto
            profile.CreateContact(
                name == null ? contact.Name : name,
                relationship == null ? contact.RelationShip : relationship.Value,
                phone == null ? contact.Phone : phone 
            );

            _UnitOfWork.PersonWriteRepository.Update(profile);
            await _UnitOfWork.SaveChangesAsync(cancellationToken);
            return Result.Ok();
        }else {
            return Result.Fail(new ContactNotExists());
        }
    }
}