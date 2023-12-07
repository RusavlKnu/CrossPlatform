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
    public void Lab1(string input_file,string output_file) => Lab5ClassLibrary.Lab1.Execute(input_file, output_file);
        

    [Authorize]
    public IActionResult Lab2()
    {
        return View();
    }

    [Authorize]
    [HttpPost]
    public void Lab2(string input_file, string output_file) => Lab5ClassLibrary.Lab2.Execute(input_file, output_file);


    [Authorize]
    public IActionResult Lab3()
    {
        return View();
    }

    [Authorize]
    [HttpPost]
    public void Lab3(string input_file, string output_file) => Lab5ClassLibrary.Lab3.Execute(input_file, output_file);

}