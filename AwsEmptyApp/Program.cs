using Amazon.DynamoDBv2;
using Amazon.DynamoDBv2.DocumentModel;
using Amazon.Runtime;
using System;

// Add using statements to access AWS SDK for .NET services. 
// Both the Service and its Model namespace need to be added 
// in order to gain access to a service. For example, to access
// the EC2 service, add:
// using Amazon.EC2;
// using Amazon.EC2.Model;

namespace AwsEmptyApp
{
    class Program
    {
        private static readonly AmazonDynamoDBClient Client = new AmazonDynamoDBClient();

        public static void Main(string[] args)
        {
            try
            {
                LoadSampleData();
                Console.WriteLine("Data is loaded.... To continue, press Enter");
                Console.ReadLine();
            }

            catch (AmazonDynamoDBException e)
            {
                Console.WriteLine(e.Message);
            }

            catch (AmazonServiceException e)
            {
                Console.WriteLine(e.Message);
            }
        }

        private static void LoadSampleData()
        {
            var personTable = Table.LoadTable(Client, "Person");

            var person1 = new Document { ["Name"] = "Pallab Nag", ["Id"] = 6 };
            personTable.PutItem(person1);

            var person2 = new Document { ["Name"] = "Bhaskar Goswami", ["Id"] = 7 };
            personTable.PutItem(person2);

            var person3 = new Document { ["Name"] = "Soham Das", ["Id"] = 8 };
            personTable.PutItem(person3);
        }
    }
}