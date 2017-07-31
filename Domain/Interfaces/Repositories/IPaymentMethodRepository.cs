using CoreBase.Domain.Entities;
using CoreBase.Infra.Cross.DTO;
using Domain.Interfaces.Repositories;
using System.Collections.Generic;

namespace CoreBase.Domain.Interfaces.Repositories
{
    public interface IPaymentMethodRepository : IBaseRepository<PaymentMethod, PaymentMethodDTO>
    {
        IEnumerable<PaymentMethodDTO> GetAllActive();
    }
}
