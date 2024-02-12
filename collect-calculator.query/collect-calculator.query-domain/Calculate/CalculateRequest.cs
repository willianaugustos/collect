using collect_calculator.query_domain.Messages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace collect_calculator.query_domain.Calculate
{
    public record CalculateRequest(Guid ProjectId, DateTime TargetDate);
}
