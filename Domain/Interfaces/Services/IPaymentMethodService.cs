using CoreBase.Infra.Cross.DTO;
using System.Collections.Generic;

namespace CoreBase.Domain.Interfaces.Services
{
    public interface IPaymentMethodService : IBaseService<PaymentMethodDTO>
    {
        IEnumerable<PaymentMethodDTO> GetAllActive();
    }
}
