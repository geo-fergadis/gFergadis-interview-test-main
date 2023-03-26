using Smartwyre.DeveloperTest.Types;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Smartwyre.DeveloperTest.Handlers.Incentives
{
    // Interface that'll allow us to call the right class per Incentive type
    public interface IIncentives
    {
        IncentiveType Type { get; }
        IncentiveResult CalculateRebate(Rebate rebate, Product product, decimal Volume);
    }
}
