using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using MyMvcApp.Models;

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
        // No datebase, so no persistence currently
        return RedirectToAction("Success", user);
    }

    public IActionResult Success(User user)
    {
        return View(user);
    }
}

