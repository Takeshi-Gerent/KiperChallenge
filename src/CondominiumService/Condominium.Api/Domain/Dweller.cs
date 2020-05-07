using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Threading.Tasks;

namespace Condominium.Api.Domain
{
    public class Dweller
    {
        public virtual int Id { get; protected set; }
        public virtual string Name { get; protected set; }
        public virtual DateTime BirthDate { get; protected set; }
        public virtual string Telephone { get; protected set; }
        public virtual string CPF { get; protected set; }
        public virtual string Email { get; protected set; }
        public virtual Apartment Apartment { get; protected set; }

        protected Dweller() { }

        private Dweller(int id, string name, DateTime birthDate, string telephone, string cpf, string email)
        {
            Id = id;
            Name = name;
            BirthDate = birthDate;
            Telephone = telephone;
            CPF = cpf;
            Email = email;
        }

        public static Dweller New(string name, DateTime birthDate, string telephone, string cpf, string email)
        {
            return new Dweller(0, name, birthDate, telephone, cpf, email);
        }

        public static Dweller FromId(int id, string name, DateTime birthDate, string telephone, string cpf, string email, Apartment apartment)
        {
            var dweller = new Dweller(id, name, birthDate, telephone, cpf, email);
            dweller.SetApartment(apartment);
            return dweller;
        }

        public virtual void SetApartment(Apartment apartment)
        {
            Apartment = apartment;
        }

        public virtual void UpdateData(string name, DateTime birthDate, string telephone, string cpf, string email, Apartment apartment)
        {
            Name = name;
            BirthDate = birthDate;
            Telephone = telephone;
            CPF = cpf;
            Email = email;
            SetApartment(apartment);
        }
    }

    public class DwellerIdComparer : IEqualityComparer<Dweller>
    {
        public bool Equals([AllowNull] Dweller x, [AllowNull] Dweller y)
        {
            return x.Id == y.Id;
        }

        public int GetHashCode([DisallowNull] Dweller obj)
        {
            return obj.Id.GetHashCode();
        }
    }
}
