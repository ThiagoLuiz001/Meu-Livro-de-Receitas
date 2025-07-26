using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1.Entities
{
    public class Person
    {
        public string Name { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
        public string Cpf { get; set; } = string.Empty;

        public Person(string name, string email, string cpf)
        {
            Name = name;
            Email = email;
            Cpf = cpf;
        }

        public Person()
        {
        }

        public string Check()
        {
            string Errors = string.Empty;
            if (string.IsNullOrEmpty(Name))
                Errors += "Nome não pode ser vazio\n";
            if (string.IsNullOrEmpty(Email))
                Errors += "Email não pode ser vazio\n";
            if (string.IsNullOrEmpty(Cpf))
                Errors += "Cpf não pode ser vazio\n";

            return Errors;
        }
    }
}
