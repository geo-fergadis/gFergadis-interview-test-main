using Smartwyre.DeveloperTest.Types;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Smartwyre.DeveloperTest.Handlers.Incentives
{
    public class IncentiveAmountPerUom : IncentiveBase, IIncentives
    {
        public IncentiveType Type { get { return IncentiveType.AmountPerUom; } }

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

            else if (!product.SupportedIncentives.HasFlag(SupportedIncentiveType.AmountPerUom))
            {
                return new IncentiveResult
                {
                    Success = false
                };
            }
            else if (rebate.Amount == 0 || Volume == 0)
            {
                return new IncentiveResult
                {
                    Success = false
                };
            }
            else
            {
                rebateAmount += rebate.Amount * Volume;
                return new IncentiveResult
                {
                    Amount = rebateAmount,
                    Success = true,
                };
            }
        }
    }
}
