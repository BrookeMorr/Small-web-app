using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using MyMvcApp.Models;

// Added so it saves user to JSON file
using System.Text.Json;
using System.IO;

namespace MyMvcApp.Controllers;

public class UserController : Controller
{   

    // Making the form for user
    [HttpGet]
    public IActionResult Create()
    {
        return View();
    }

    // Handles the form submission
    [HttpPost]
    public IActionResult Create(User user)
    {
    if (!ModelState.IsValid)
        return View(user);

    var filePath = Path.Combine(AppContext.BaseDirectory, "users.json");

    List<User> users = new List<User>();

    if (System.IO.File.Exists(filePath))
    {
        var existingData = System.IO.File.ReadAllText(filePath);

        if (!string.IsNullOrWhiteSpace(existingData))
        {
            users = JsonSerializer.Deserialize<List<User>>(existingData) ?? new List<User>();
        }
    }

    users.Add(user);

    var json = JsonSerializer.Serialize(users, new JsonSerializerOptions
    {
        WriteIndented = true
    });

    System.IO.File.WriteAllText(filePath, json);

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

