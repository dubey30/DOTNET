using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using tflstore.Models;
using System.Collections.Generic;
using System.IO;
using System.Text.Json;
using System.Text.Json.Serialization;
namespace tflstore.Controllers;

public class HomeController : Controller
{
    private readonly ILogger<HomeController> _logger;

    public HomeController(ILogger<HomeController> logger)
    {
        Console.WriteLine("Home Controller instance initialized......");
        _logger = logger;
    }

    //Action Methods

    public IActionResult Index()
    {
        Console.WriteLine("Invoking Home Controller index method.. ");
        return View();
    }

    public IActionResult Privacy()
    {
        Console.WriteLine("Invoking Home Controller Privacy method. ");
        return View();
    }

    public IActionResult Login(){
         Console.WriteLine("Invoking Home Controller Login method. ");
       

        return View();
    }

    public IActionResult Validate(string email, string password){

         Console.WriteLine("Validating User credentials.... ");
       

        if(email =="ravi.tambade@transflower.in" && 
           password=="seed"){
             Console.WriteLine("successfull validation of user..... ");
             Console.WriteLine("Redirecting to welcome..... ");   
            return Redirect("/home/Welcome");
           }

           List<string> cr = new List<string>();
                cr.Add(email);
                cr.Add(password);
              try{
    var options = new JsonSerializerOptions{ IncludeFields=true};
    var projectJson = JsonSerializer.Serialize<List<string>>(cr,options);
    string fileName=@"G:\.NetPractice\Day8\login\email.json";

    System.IO.File.WriteAllText(fileName,projectJson);

// string jsonString= File.ReadAllText(fileName);
// List<operations> jsonProjects = JsonSerializer.Deserialize<List<operations>>(jsonString);
//     Console.WriteLine("\n Json: Deserializing data from json file\n\n");
//     foreach(operations project in jsonProjects)
//     {
//          Console.WriteLine($"{project.pid} : {project.StartDate}");  
//     // Console.WriteLine("${project.pid};
//     // ${project.StarDate}:{project.EndDate}:{project.ptitle}:{project.pdesc}`);
//     }
}
catch(Exception exp)
{

}
finally{}
        return View();
    }
    
    public IActionResult Welcome(){
         Console.WriteLine("Invoking Home Controller Welcome  method. ");
       
        return View();
    }

    public IActionResult Register(){
        return View();
    }

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}
