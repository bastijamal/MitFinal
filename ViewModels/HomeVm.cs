using System;
using System.ComponentModel.DataAnnotations.Schema;
using SondanaSon.Models;

namespace SondanaSon.ViewModels
{
	public class HomeVm
	{
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string Position { get; set; }

        [NotMapped]
        public IFormFile ImgFile { get; set; }

        public List<Clients> clients { get; set; }

    }
}

