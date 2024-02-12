using collect_calculator.query_domain.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace collect_calculator.query_domain.Calculate
{
    public interface ICalculateHandler
    {
        Task<Response<CalculateResponse>> Handle(CalculateRequest request, Guid correlationId, CancellationToken cancellationToken);
    }
}
