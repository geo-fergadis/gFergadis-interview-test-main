using Smartwyre.DeveloperTest.Types;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Smartwyre.DeveloperTest.Handlers.Incentives
{
    // A class to include functions, common to all Incentive types classes
    public class IncentiveBase
    {
        /// <summary>
        /// If there are no rebates or products there will be no calculation. Centralize
        /// validation for all inheriting classes to avoid code repetition
        /// </summary>
        /// <param name="rebate"></param>
        /// <param name="product"></param>
        /// <returns></returns>
        protected bool isRebateValid(Rebate rebate, Product product)
        {
            if (rebate == null || product == null)
            {
                return false;
            }
            
            // All else
            return true;
        }
    }
}
