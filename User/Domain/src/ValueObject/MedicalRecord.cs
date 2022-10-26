namespace Domain.src.ValueObject
{
    public record MedicalRecord
    {
        public MedicalRecord(string allergies, string disabilities, string aptitude){
            Allergies = allergies;
            Disabilities = disabilities;
            Aptitude = aptitude;
        }

        public string? Allergies {get;}
        public string? Disabilities {get;}
        public string? Aptitude {get;}
    }
}