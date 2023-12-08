using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Lab5Web.Controllers;

public class LabsController : Controller
{
    [Authorize]
    public IActionResult Lab1()
    {
        return View();
    }

    [Authorize]
    [HttpPost]
    public string Lab1(string inputFile,string outputFile) => Lab5ClassLibrary.Lab1.Execute(inputFile, outputFile);
        

    [Authorize]
    public IActionResult Lab2()
    {
        return View();
    }

    [Authorize]
    [HttpPost]
    public string Lab2(string inputFile, string outputFile) => Lab5ClassLibrary.Lab2.Execute(inputFile, outputFile);


    [Authorize]
    public IActionResult Lab3()
    {
        return View();
    }

    [Authorize]
    [HttpPost]
    public string Lab3(string inputFile, string outputFile) => Lab5ClassLibrary.Lab3.Execute(inputFile, outputFile);

}