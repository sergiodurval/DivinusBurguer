using Divinus.Domain.Entities.Base;
using prmToolkit.NotificationPattern;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Divinus.Domain.Entities
{
    public class Address : EntityBase
    {
        public Address(string zipCode, string publicPlace, string neighborhood, string state, string locality, long gia, long ibge, string complement)
        {
            ZipCode = zipCode;
            PublicPlace = publicPlace;
            Neighborhood = neighborhood;
            State = state;
            Locality = locality;
            Gia = gia;
            Ibge = ibge;
            Complement = complement;


            new AddNotifications<Address>(this)
                .IfNullOrEmpty(x => x.ZipCode, "Cep obrigatório")
                .IfNullOrEmpty(x => x.PublicPlace, "Logradouro obrigatório")
                .IfNullOrEmpty(x => x.Neighborhood, "Bairro obrigatório")
                .IfNullOrEmpty(x => x.State, "Estado obrigatório");
        }

 

        protected Address()
        {

        }

        


        public string ZipCode { get; private set; }
        public string PublicPlace { get; private set; }
        public string Neighborhood { get; private set; }
        public string State { get; private set; }
        public string Locality { get; private set; }
        public long Gia { get; private set; }
        public long Ibge { get; private set; }
        public string Complement { get; private set; }
    }
}
