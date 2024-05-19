using System;
using System.ComponentModel.DataAnnotations;

namespace SondanaSon.ViewModels.Account

{
	public class RegisterVm
	{
        public string Name { get; set; }

        public string Surname { get; set; }

        public string UserName { get; set; }

        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }

        [DataType(DataType.Password),Compare(nameof(ConfirmPassword))]
        //pasword tipi eleyrik yazanda gorunmur ulduz gorunur,compare=edir
        public string Password { get; set; }

        [DataType(DataType.Password)]
        public string ConfirmPassword { get; set; }

    }
}

