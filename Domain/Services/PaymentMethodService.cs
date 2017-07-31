using CoreBase.Domain.Entities;
using CoreBase.Domain.Interfaces.Repositories;
using CoreBase.Domain.Interfaces.Services;
using CoreBase.Infra.Cross.DTO;
using System.Collections.Generic;

namespace CoreBase.Domain.Services
{
    public class PaymentMethodService : BaseService<PaymentMethod, PaymentMethodDTO>, IPaymentMethodService
    {
        private readonly IPaymentMethodRepository _paymentMethodRepository;

        public PaymentMethodService(IPaymentMethodRepository paymentMethodRepository) : base(paymentMethodRepository)
        {
            _paymentMethodRepository = paymentMethodRepository;
        }

        public IEnumerable<PaymentMethodDTO> GetAllActive()
        {
            return _paymentMethodRepository.GetAllActive();
        }
    }
}
