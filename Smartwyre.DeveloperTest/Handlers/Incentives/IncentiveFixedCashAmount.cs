using Smartwyre.DeveloperTest.Types;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Smartwyre.DeveloperTest.Handlers.Incentives
{
    public class IncentiveFixedCashAmount : IncentiveBase, IIncentives
    {
        public IncentiveType Type { get { return IncentiveType.FixedCashAmount; } }

        public IncentiveResult CalculateRebate(Rebate rebate, Product product, decimal Volume)
        { 
            if (!isRebateValid(rebate,product))
            {
                return new IncentiveResult
                {
                    Success = false
                };
            }
            else if (!product.SupportedIncentives.HasFlag(SupportedIncentiveType.FixedCashAmount))
            {

                return new IncentiveResult
                {
                    Success = false
                };
            }
            else if (rebate.Amount == 0)
            {

                return new IncentiveResult
                {
                    Success = false
                };
            }
            else
            {
                return new IncentiveResult
                {
                    Amount = rebate.Amount,
                    Success = true
                };
            } 
        }
    }
}
