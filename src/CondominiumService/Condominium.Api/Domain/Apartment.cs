using Condominium.Application.Extensions;
using NHibernate.Util;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Condominium.Api.Domain
{
    public class Apartment
    {
        public virtual int Id { get; protected set; }
        public virtual int Number { get; protected set; }
        public virtual string Block { get; protected set; }
        public virtual ICollection<Dweller> Dwellers { get; protected set; } = new List<Dweller>();

        protected Apartment() { }

        private Apartment(int id, int number, string block)
        {
            Id = id;
            Number = number;
            Block = block;            
        }

        public static Apartment New(int number, string block, IEnumerable<Dweller> dwellers) 
        {
            var apartment = new Apartment(0, number, block);
            apartment.SetDwellers(dwellers);
            return apartment;
        }

        public static Apartment FromId(int id, int number, string block, IEnumerable<Dweller> dwellers)
        {
            var apartment = new Apartment(id, number, block);
            apartment.SetDwellers(dwellers);
            return apartment;
        }

        public virtual void UpdateData(int number, string block, IEnumerable<Dweller> dwellers)
        {
            Number = number;
            Block = block;            
            SetDwellers(dwellers);
        }

        private void SetDwellers(IEnumerable<Dweller> dwellers)
        {
            Dwellers.RemoveAll(r => !dwellers.Select(p => p.Id).Contains(r.Id));
            Dwellers.Intersect(dwellers, new DwellerIdComparer()).ToList().ForEach(p =>
            {
                var updatedDweller = dwellers.FirstOrDefault(d => d.Id == p.Id);
                p.UpdateData(
                    updatedDweller.Name,
                    updatedDweller.BirthDate,
                    updatedDweller.Telephone,
                    updatedDweller.CPF,
                    updatedDweller.Email
                    );
            });
            dwellers.Where(p => p.Id == 0).ToList().ForEach(p => {
                p.SetApartment(this);
                Dwellers.Add(p);
            });
        }

    }

    
}
