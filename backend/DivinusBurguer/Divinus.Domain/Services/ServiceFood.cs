using Divinus.Domain.Arguments.Base;
using Divinus.Domain.Arguments.Food;
using Divinus.Domain.Entities;
using Divinus.Domain.Interfaces.Repositories;
using Divinus.Domain.Interfaces.Services;
using prmToolkit.NotificationPattern;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Divinus.Domain.Services
{
    public class ServiceFood : Notifiable, IServiceFood
    {
        private readonly IRepositoryFood _repositoryFood;

        public ServiceFood(IRepositoryFood repositoryFood)
        {
            _repositoryFood = repositoryFood;
        }

        public AddFoodResponse AddFood(AddFoodRequest request)
        {
            if(request == null)
            {
                AddNotification("AddFoodRequest", "request inválido");
                return null;
            }

            var food = new Food(request.Name, request.Description, request.Price, request.ImageName, request.Category);

            if(this.IsInvalid())
            {
                return null;
            }

            return (AddFoodResponse)_repositoryFood.Adicionar(food);
        }

        public ResponseBase DeleteFood(Guid id)
        {
            if(id == null)
            {
                AddNotification("Id", "Obrigatório");
                return null;
            }

            var food = _repositoryFood.ObterPorId(id);

            if(food == null)
            {
                AddNotification("Item", "Não encontrado");
                return null;
            }

            _repositoryFood.Remover(food);

            return new ResponseBase();
        }

        public IEnumerable<FoodResponse> GetAllFood()
        {
           return _repositoryFood.Listar().ToList().Select(food => (FoodResponse)food).ToList();
        }

        public FoodResponse GetFoodById(Guid id)
        {
            return (FoodResponse)_repositoryFood.ObterPorId(id);
        }

        public FoodResponse UpdateFood(UpdateFoodRequest request)
        {
            if(request == null)
            {
                AddNotification("UpdateFoodRequest", "Requisição inválida");
                return null;
            }

            Food food = _repositoryFood.ObterPorId(request.Id);

            if(food == null)
            {
                AddNotification("Id", "Dados não encontrados");
                return null;
            }

            food.Update(food.Name, food.Description, food.Price, food.ImageName,food.Category);

            AddNotifications(food);

            if(IsInvalid())
            {
                return null;
            }

            return (FoodResponse)_repositoryFood.Editar(food);
        }


    }
}
