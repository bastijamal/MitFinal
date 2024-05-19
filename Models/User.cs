using System;
using Microsoft.AspNetCore.Identity;

namespace SondanaSon.Models
{
	public class User:IdentityUser
	{
		public string Name { get; set; }
		public string Surname { get; set; }

        //diger deyerlere ehtiyyac yoxdur(email,password) onlari IdentityDbContext ozu bize verir

    }
}

