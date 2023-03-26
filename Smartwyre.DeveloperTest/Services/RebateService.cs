using Smartwyre.DeveloperTest.Data;
using Smartwyre.DeveloperTest.Handlers.Incentives;
using Smartwyre.DeveloperTest.Types;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Smartwyre.DeveloperTest.Services;

public class RebateService : IRebateService
{

    public readonly List<IIncentives> _incentivesList;

    // Use dependency injection to get the different classes
    public RebateService(List<IIncentives> incentivesList) => _incentivesList = incentivesList;

    public RebateService()
    {
        _incentivesList = new List<IIncentives>{
                new IncentiveFixedCashAmount(), new IncentiveFixedRateRebate() , new IncentiveAmountPerUom()
            };
    }


    public CalculateRebateResult Calculate(CalculateRebateRequest request)
    {
        try
        {

            var rebateDataStore = new RebateDataStore();
            var productDataStore = new ProductDataStore();

            Rebate rebate = rebateDataStore.GetRebate(request.RebateIdentifier);
            Product product = productDataStore.GetProduct(request.ProductIdentifier);
            if (rebate!=null && product != null) { 
                var result = new IncentiveResult();

                var Incentive = _incentivesList.Single(x => x.Type == rebate.Incentive);

                result = Incentive.CalculateRebate(rebate, product, request.Volume);

                if (result.Success)
                {
                    var storeRebateDataStore = new RebateDataStore();
                    storeRebateDataStore.StoreCalculationResult(rebate, result.Amount);
                }

                return new CalculateRebateResult { Success = result.Success };
            }
           
        }
        catch(Exception e) 
            {
            // Let the main call handle the exceptions for the moment
        }
        
        // Until we short out a better way to communicate messages and results between functions
        return new CalculateRebateResult { Success = false };
            
    }
}
