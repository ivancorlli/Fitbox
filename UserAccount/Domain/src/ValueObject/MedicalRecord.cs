namespace Domain.src.ValueObject
{
    public record MedicalRecord
    {   

        /// <summary>
        /// Crea una historia medica 
        /// </summary>
        /// <param name="allergies"></param>
        /// <param name="disabilities"></param>
        /// <param name="aptitude"></param>
        public MedicalRecord(string allergies, string disabilities, Uri aptitude){
            Allergies = allergies;
            Disabilities = disabilities;
            Aptitude = aptitude;
        }

        public string? Allergies {get;private set;}
        public string? Disabilities {get;private set;}
        public Uri? Aptitude {get;private set;}

        /// <summary>
        /// Cambia las alergias
        /// </summary>
        /// <param name="allergies"></param>
        public void ChangeAllergies(string allergies){
            Allergies = allergies;
        }

        /// <summary>
        /// Cambia las discapacidades
        /// </summary>
        /// <param name="disabilities"></param>
        public void ChangeDisabilities(string disabilities){
            Disabilities = disabilities;
        }

        /// <summary>
        /// Cambia la aptitud medica
        /// </summary>
        /// <param name="aptitude"></param>
        public void ChangeAptitude(Uri aptitude){
            Aptitude = aptitude;
        }
    }
}