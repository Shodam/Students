using System;
using System.Collections.Generic;
using System.Net.Http;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MySql.Data.MySqlClient;
using WebApplication.Models;

namespace WebApplication.Controllers
{
    [Route("account")]
    public class AccountController : Controller
    {
        [Route("")]
        [Route("index")]
        [Route("~/")]
        public IActionResult Index()
        {
            return View();
        }

        [Route("login")]
        [HttpPost]
        public IActionResult Login(string username, string password)
        {
            if (username != null && password != null)
            {
                try
                {
                    using var con = new MySqlConnection("server=localhost;port=3306;database=studentdatabase;user=shodam;password=Evelash4482519");
                    con.Open();
                    string command = $"SELECT Username, Password FROM admin WHERE Username=\"{username}\" AND Password= AES_ENCRYPT(\"{password}\",\"secret\")";
                    var cmd = new MySqlCommand(command, con);
                    using var reader = cmd.ExecuteReader();
                    while (reader.Read())
                    {
                       username = reader["Username"].ToString();
                       password = reader["Password"].ToString();
                       
                       if (username != null && password != null) 
                       { 
                           HttpContext.Session.SetString("username", username); 
                           return View("Success");
                       }
                    }

                    ViewBag.error = "Invalid Account";
                    return View("Index");

                }
                catch (Exception e)
                {
                    Console.WriteLine(e);
                    ViewBag.error = "FATAL ERROR Contact Admin";
                    return View("Index");
                }
            }
            
            return View("Index");
        }

        [Route("CreateAccount")]
        public IActionResult CreateAccount(string username, string firstname, string lastname, string password)
        {
            if (username != null && password != null && firstname != null && lastname != null)
            {
                try
                {
                    using var con = new MySqlConnection(
                        "server=localhost;port=3306;database=studentdatabase;user=shodam;password=Evelash4482519");
                    con.Open();
                    string command = $"INSERT INTO admin VALUES (\"{username}\", \"{firstname}\", \"{lastname}\", AES_ENCRYPT(\"{password}\",\"secret\"));";
                    var cmd = new MySqlCommand(command, con);
                    using var reader = cmd.ExecuteReader();
                    while (reader.Read())
                    {
                        username = reader["Username"].ToString();
                        
                    }
                    HttpContext.Session.SetString("username", username);
                    return View("Index");
                }
                catch (Exception e)
                {
                    Console.WriteLine(e);
                    ViewBag.error = $"{e}";
                    return View("CreateAccount");
                }
            }

            return View("CreateAccount");
        }

        [Route("logout")]
        [HttpGet]
        public IActionResult Logout()
        {
            HttpContext.Session.Remove("username");
            return View("Index");
        }
    }
}