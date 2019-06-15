using Divinus.Domain.Arguments.Address;
using Divinus.Domain.Entities;
using Divinus.Domain.Interfaces.Repositories;
using Divinus.Domain.Interfaces.Services;
using Newtonsoft.Json;
using prmToolkit.NotificationPattern;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace Divinus.Domain.Services
{
    public class ServiceAddress : Notifiable, IServiceAddress
    {
        private readonly IRepositoryAddress _repositoryAddress;

        public ServiceAddress(IRepositoryAddress repositoryAddress)
        {
            _repositoryAddress = repositoryAddress;
        }

        public AddAddressResponse Add(AddAddressRequest request)
        {
            if(request == null)
            {
                AddNotification("SearchAddressRequest", "request inválido");
                return null;
            }

            var address = new Address(request.ZipCode,request.PublicPlace,request.Neighborhood,
                            request.State,
                            request.Locality,
                            request.Gia,
                            request.Ibge,
                            request.Complement
                            );

            if(this.IsValid())
            {
                return null;
            }

            return (AddAddressResponse)_repositoryAddress.Adicionar(address);
            
        }

        public SearchAddressResponse Search(SearchAddressRequest request)
        {
            if(request == null)
            {
                AddNotification("SearchAddressRequest", "request inválido");
                return null;
            }

            if(_repositoryAddress.Existe(x => x.ZipCode == request.ZipCode))
            {
                var address = _repositoryAddress.ObterPor(p => p.ZipCode == request.ZipCode);

                return (SearchAddressResponse)address;
            }
            else
            {
                var address = GetAddress(request.ZipCode);
                if(address != null)
                {
                    _repositoryAddress.Adicionar(address);
                }
                return (SearchAddressResponse)address;
            }
        }

        public Address GetAddress(string zipCode)
        {
            string url = $"https://viacep.com.br/ws/{zipCode}/json/";
            var request = new HttpClient();
            var response = request.GetAsync(url).Result;
            

            if (response.StatusCode == HttpStatusCode.BadRequest)
                throw new ArgumentException();

            var json = response.Content.ReadAsStringAsync().Result;

            var endereco = JsonConvert.DeserializeObject<Endereco>(json);

            if(endereco != null)
            {
               var  address = new Address(endereco.CEP.Replace("-",""), 
                    endereco.Logradouro, 
                    endereco.Bairro, 
                    endereco.UF, 
                    endereco.Localidade, 
                    Convert.ToInt64(endereco.Gia), 
                    Convert.ToInt64(endereco.Ibge), 
                    endereco.Complemento);

                return address;
            }

            return null;
        }
    }

    public class Endereco
    {
        public string CEP { get; set; }
        public string Logradouro { get; set; }
        public string Complemento { get; set; }
        public string Bairro { get; set; }
        public string Localidade { get; set; }
        public string UF { get; set; }
        public string Unidade { get; set; }
        public string Ibge { get; set; }
        public string Gia { get; set; }
    }
}
