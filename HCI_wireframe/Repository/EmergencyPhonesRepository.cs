/***********************************************************************
 * Module:  EmergencyPhonesRepository.cs
 * Purpose: Definition of the Class Repository.EmergencyPhonesRepository
 ***********************************************************************/

using Class_diagram.Model.Patient;
using System;

namespace Class_diagram.Repository
{
   public class EmergencyPhonesRepository : GenericFileRepository<PhoneNumber>
   {
        public EmergencyPhonesRepository(string filePath) : base(filePath)  { }

        public EmergencyPhonesRepository() : base()   { }

    }
}