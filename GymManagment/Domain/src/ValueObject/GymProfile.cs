using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Domain.src.ValueObject
{
    public record GymProfile
    {
        public string Name {get;private set;}
        public List<string>? Trainings {get;private set;}
        public string? Biography {get;private set;}
        public Uri? ProfileImage {get;private set;}
        public Uri? FrontImage {get;private set;}


        /// <summary>
        /// Crea el perfil del gimnasio
        /// </summary>
        /// <param name="name"></param>
        public GymProfile(string name){
            Name = name;

        }


    }



}