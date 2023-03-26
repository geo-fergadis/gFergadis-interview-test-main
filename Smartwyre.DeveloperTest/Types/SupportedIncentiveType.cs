namespace Smartwyre.DeveloperTest.Types;


// Not sure why we have a different enum for the supported Incentive Types from the IncentiveType,
// If that's done with a scope for a future functionality which I can't think of, I'd try to at least,
// have incentives with the same names, maintain same numerical value.
// Saying that, it reveals the flaw of this strategy, as new developers might introduce new unecessary
// enums instead of using the existing ones
public enum SupportedIncentiveType
{
    FixedRateRebate = 1 << 0,
    AmountPerUom = 1 << 1,
    FixedCashAmount = 1 << 2,
}
