using Smartwyre.DeveloperTest.Types;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Smartwyre.DeveloperTest.Handlers.Incentives
{
    public class IncentiveFixedRateRebate : IncentiveBase, IIncentives
    {

        public IncentiveType Type { get { return IncentiveType.FixedRateRebate; } }


        public IncentiveResult CalculateRebate(Rebate rebate, Product product, decimal Volume)
        {
            var rebateAmount = 0m;
            if (!isRebateValid(rebate, product))
            {
                return new IncentiveResult
                {
                    Success = false
                };
            }
            else if (!product.SupportedIncentives.HasFlag(SupportedIncentiveType.FixedRateRebate))
            {
                return new IncentiveResult
                {
                    Success = false
                };
            }
            else if (rebate.Percentage == 0 || product.Price == 0 || Volume == 0)
            {
                return new IncentiveResult
                {
                    Success = false
                };
            }
            else
            {
                rebateAmount += product.Price * rebate.Percentage * Volume;

                return new IncentiveResult
                {
                    Amount = rebateAmount,
                    Success = true,
                };
            }

        }
    }
}
