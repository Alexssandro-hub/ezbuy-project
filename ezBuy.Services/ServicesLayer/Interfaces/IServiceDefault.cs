using ezBuy.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ezBuy.Services.ServicesLayer.Interfaces
{
    public interface IServiceDefault<TEntity>  where TEntity : class
    {
        public Tuple<string, TypeError> Messages { get; set; }
        public bool? Found { get; set; }

        //using fluent validation required!!!
        /// <summary>
        ///     Examples:
                //string SetMessage(string fieldName) => $"Campo '{fieldName}' é obrigatório.";
                //if (string.IsNullOrWhiteSpace(entity.Name)) errorList.Add(SetMessage("Nome"));
                //errorList.AddRange(_validationService.Validate<TEntity>(entity));
        /// </summary>
        /// <param name="entity"></param>
        /// <param name="errors"></param>
        void ValidateFields(TEntity entity, List<string> errors); 
        void ValidateBusinessCore(TEntity entity, List<string> errors);
    }
}
