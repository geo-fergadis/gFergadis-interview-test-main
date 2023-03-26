using Smartwyre.DeveloperTest.Types;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text.Json;
using static System.Net.Mime.MediaTypeNames;

namespace Smartwyre.DeveloperTest.Data;

public class RebateDataStore
{
    public Rebate GetRebate(string rebateIdentifier)
    {
        // Access database to retrieve account, code removed for brevity 
        // -- I guess the removed code, would define the proper type or Rebate according to the rebateIdentifier?
        // -- In that case I'd leave it as is but, since I need some data to run the tests, I made a jSon file with some random ones...

        List<Rebate> source = new List<Rebate>();
        string path = Environment.CurrentDirectory + @"/MockData/RebateData.json";
        using (StreamReader r = new StreamReader(path))
        {
            string json = r.ReadToEnd();
            source = JsonSerializer.Deserialize<List<Rebate>>(json);
        }

        
        return source.FirstOrDefault(r => r.Identifier == rebateIdentifier);

        //return (toReturn != null) ? toReturn : new Rebate();
       
    }

    public void StoreCalculationResult(Rebate account, decimal rebateAmount)
    {

        Rebate destination = new Rebate
        {
            Amount = rebateAmount,
            Identifier = account.Identifier,
            Incentive = account.Incentive,
            Percentage = account.Percentage
        };
        // Update account in database, code removed for brevity
        string jsonString = JsonSerializer.Serialize(destination, new JsonSerializerOptions() { WriteIndented = true });
        using (StreamWriter outputFile = new StreamWriter("dataReady.json"))            // Different location for the example, as we wouldn't like to overwrite any files
        {
            outputFile.WriteLine(jsonString);
        }
    }
}
