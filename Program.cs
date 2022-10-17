using System;
using RestSharp;
using System.Text.Json;

namespace HelloWorldApplication {
  class HelloWorld {
    static void Main(string[] args) {
        Console.WriteLine("Enter Postcode:");
        int postcode = Convert.ToInt32(Console.ReadLine());
        var client = new RestClient("https://api.zippopotam.us/us/" + postcode);

        var request = new RestRequest(Method.GET);
        IRestResponse response = client.Execute(request);
        
        // Console.WriteLine(response.Content);

        // string data = @" [ {""name"": ""John Doe"", ""occupation"": ""gardener""}, 
        // {""name"": ""Peter Novak"", ""occupation"": ""driver""} ]";

        using JsonDocument doc = JsonDocument.Parse(response.Content);
        JsonElement root = doc.RootElement;

        // Console.WriteLine(root);

        var u1 = root;
        // Console.WriteLine(u1);

        Console.WriteLine(u1.GetProperty("country"));
    }
  }
}
