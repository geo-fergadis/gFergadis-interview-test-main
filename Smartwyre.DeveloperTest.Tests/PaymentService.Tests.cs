using Smartwyre.DeveloperTest.Services;
using Smartwyre.DeveloperTest.Types;
using System;
using System.Security.Principal;
using Xunit;

namespace Smartwyre.DeveloperTest.Tests;

public class PaymentServiceTests
{
    [Fact]
    public void AmountPerUom_True()
    {

        RebateService rebService = new RebateService();

        CalculateRebateRequest rebReq = new CalculateRebateRequest
        {
            Volume = 40,
            RebateIdentifier = "Rebate2",
            ProductIdentifier = "Product2",
        };
        Assert.True(rebService.Calculate(rebReq).Success);
         
    }
    [Fact]
    public void AmountPerUom_False()
    {
        RebateService rebService = new RebateService();

        CalculateRebateRequest rebReq = new CalculateRebateRequest
        {
            Volume = 40,
            RebateIdentifier = "Rebate1",
            ProductIdentifier = "Product2",
        };
        Assert.False(rebService.Calculate(rebReq).Success);

    }
    [Fact]
    public void FixedCashAmount_True()
    {
        RebateService rebService = new RebateService();

        CalculateRebateRequest rebReq = new CalculateRebateRequest
        {
            Volume = 40,
            RebateIdentifier = "Rebate3",
            ProductIdentifier = "Product3",
        };
        Assert.True(rebService.Calculate(rebReq).Success);

    }
    [Fact]
    public void FixedCashAmount_False()
    {
        RebateService rebService = new RebateService();

        CalculateRebateRequest rebReq = new CalculateRebateRequest
        {
            Volume = 40,
            RebateIdentifier = "Rebate3",
            ProductIdentifier = "Product1",
        };
        Assert.False(rebService.Calculate(rebReq).Success);

    }
    [Fact]
    public void FixedRateRebate_True()
    {
        RebateService rebService = new RebateService();

        CalculateRebateRequest rebReq = new CalculateRebateRequest
        {
            Volume = 40,
            RebateIdentifier = "Rebate1",
            ProductIdentifier = "Product1",
        };
        Assert.True(rebService.Calculate(rebReq).Success);

    }
    [Fact]
    public void FixedRateRebate_False()
    {
        RebateService rebService = new RebateService();

        CalculateRebateRequest rebReq = new CalculateRebateRequest
        {
            Volume = 40,
            RebateIdentifier = "Rebate1",
            ProductIdentifier = "Product2",
        };
        Assert.False(rebService.Calculate(rebReq).Success);

    }
}
