using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using MyMvcApp.Models;

namespace MyMvcApp.Controllers;

public class UserController : Controller
{   
    private static List<User> Users = new List<User>();

    // Making the form for user
    [HttpGet]
    public IActionResult Create()
    {
        return View();
    }

    // Handles the form submission
    [HttpPost]
    public IActionResult Create(User user) {
    if (!ModelState.IsValid)
        return View(user);

    Users.Add(user);

    return RedirectToAction("Success", new
    {
        firstName = user.FirstName,
        lastName = user.LastName
    });
    }

    public IActionResult Success(string firstName, string lastName)
    {
    var user = new User
    {
        FirstName = firstName,
        LastName = lastName
    };

    return View(user);
    }
}

