using Smartwyre.DeveloperTest.Types;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.Json;

namespace Smartwyre.DeveloperTest.Data;

public class ProductDataStore
{
    public Product GetProduct(string productIdentifier)
    {
        // Access database to retrieve account, code removed for brevity 


        List<Product> source = new List<Product>();
        string path = Environment.CurrentDirectory + @"/MockData/ProductData.json";
        using (StreamReader r = new StreamReader(path))
        {
            string json = r.ReadToEnd();
            source = JsonSerializer.Deserialize<List<Product>>(json);
        }

        return source.FirstOrDefault(r => r.Identifier == productIdentifier);

        //return (toReturn!=null)?toReturn: new Product();

         
    }
}
