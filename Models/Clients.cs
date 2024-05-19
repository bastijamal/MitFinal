using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SondanaSon.Models
{
    public class Clients
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string Position { get; set; } 
        public string? PhotoUrl { get; set; }

        [NotMapped]
        public IFormFile ImgFile { get; set; }


    }
}


