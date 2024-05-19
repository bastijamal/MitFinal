using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SondanaSon.DAL;
using SondanaSon.Models;


namespace SondanaSon.Areas.Manage.Controllers
{
    [Area("Manage")]

    public class ClientsController : Controller
    {
        //Important
        private readonly AppDbContext _context;
        private readonly IWebHostEnvironment _environment;


        public ClientsController(AppDbContext context,IWebHostEnvironment environment)
        {
            _context = context;
            _environment = environment;
        }
       

        public IActionResult Index()
        {
            var clients = _context.clients.ToList();
            return View(clients);
        }


        public IActionResult Create()
        {
            return View();
        }


        [HttpPost]
        public IActionResult Create(Clients homevm)
        {
            if (!ModelState.IsValid)
            {
                return View();
            }

            if (homevm.ImgFile.ContentType.Contains("image/")){

                ModelState.AddModelError("ImgFile", "Error!");
                return View();
            }

            string path = _environment.WebRootPath + @"\upload\clients\";
            string filename = Guid.NewGuid() + homevm.ImgFile.FileName;


            using (FileStream filestream = new FileStream(path + filename, FileMode.Create))
            {
                homevm.ImgFile.CopyTo(filestream);
            }

             Clients client = new Clients()
            {
                Name = homevm.Name,
                Description=homevm.Description,
                Position = homevm.Position,
                //ImgFile =filename,
                ///burda errorum var duzeldecem
                ///

            };

            _context.clients.Add(homevm);
            _context.SaveChanges();


            return RedirectToAction("Index");

        }



    }
}

