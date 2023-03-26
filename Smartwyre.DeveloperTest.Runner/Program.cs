using Smartwyre.DeveloperTest.Handlers.Incentives;
using Smartwyre.DeveloperTest.Services;
using Smartwyre.DeveloperTest.Types;
using System;

namespace Smartwyre.DeveloperTest.Runner;

class Program
{
    static void Main(string[] Args)
    {
        try
        {
            RebateService rebService= new RebateService();

            CalculateRebateRequest rebReq;
            CalculateRebateResult rebRes = new CalculateRebateResult();

            rebReq = getCmdLineArgs();

            if (rebReq != null)                 // If user provided the right data
            {
                rebRes= rebService.Calculate(rebReq);
            }
            Console.WriteLine(rebRes.Success ? "Rebate was successful..." : "Rebate Failed!");
            Console.WriteLine("Press any key to Close...");
            Console.ReadLine();
        }
        catch (Exception e)
        {
            Console.WriteLine(e.ToString());
        }
    }

    /// <summary>
    /// It promts the user for 3 comma separated arguments, where the 3rd one must be a decimal.
    /// It will stop asking for data, when the user types exit, or provide the right data to continue 
    /// with the rebate process
    /// </summary>
    /// <returns>a Calculate Rebate Request object or null if the user wishes to stop the process</returns>
    private static CalculateRebateRequest getCmdLineArgs()
    {
        string args = "";
        bool askParams = true;
        while (true)
        {
            string[] argsArray = args.Replace(" ", "").Split(',');
            if (argsArray.Length == 1 && argsArray[0].ToLower() == "exit")
                return null;
               // askParams = false;
            else
                if (argsArray.Length == 3)
            {
                decimal volume;
                if (decimal.TryParse(argsArray[2], out volume))     // First check that a decimal has been passed
                {
                    // And create the Rebate object
                    CalculateRebateRequest rebReq = new CalculateRebateRequest();
                    rebReq.Volume = volume;
                    rebReq.RebateIdentifier = argsArray[0];
                    rebReq.ProductIdentifier = argsArray[1];
                    
                    askParams = false;
                    return rebReq;

                }// Otherwise, keep asking for the right parameters


            }
            if (askParams)
            { // If Parameters are still needed, then let the users know, how they can input them correctly

                // Display message to user to provide parameters.
                System.Console.WriteLine("Please enter the following parameters: RebateIdentifier,ProductIdentifier,Volume as decimal (separated by commas).");

                System.Console.WriteLine(" -- Alternatively, type 'exit' to close console");

                args = Console.ReadLine();
            }

        }
    }


}
