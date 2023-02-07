using Application.Exceptions;
using Domain.Entities;
using Domain.Enums;

namespace Application.Validators
{
    public class DeliveriesDataValidator
    {
        public void EvaluateIfIsPairDataList(IEnumerable<string> data, DeliveryEntities kindOfEntity)
        {
            if (data.Count() % 2 != 0)
                throw new BadRequestCustomException($"A {kindOfEntity}´s name or weigth is missing.");
        }

        public string ValidateDeliveryEntityName(string name, DeliveryEntities kindOfEntity)
        {
            if(string.IsNullOrWhiteSpace(name))
                throw new BadRequestCustomException($"A {kindOfEntity}´s name can´t be null, empty or white space.");
            return name;
        }

        public double ValidateDeliveryEntityWeight(string weigthInString, DeliveryEntities kindOfEntity)
        {
            if (!double.TryParse(weigthInString, out double weigth))
                throw new BadRequestCustomException($"A {kindOfEntity}´s weigth can´t be converted to double value.");
            return weigth;
        }

        public void ValidateMissingDeliveryData(string data, DeliveryEntities kindOfEntity)
        {
            if(string.IsNullOrWhiteSpace(data))
                throw new BadRequestCustomException($"{kindOfEntity}'s data is missing or a white line has been found.");
        }

        public void ValidateNullOrEmptyDeliveryData(IEnumerable<CommonDeliveryData> data, DeliveryEntities kindOfEntity)
        {
            if (data.Any(x => string.IsNullOrWhiteSpace(x.Name)))
                throw new BadRequestCustomException($"There are null or empty values in the {kindOfEntity} data.");
        }
    }
}
