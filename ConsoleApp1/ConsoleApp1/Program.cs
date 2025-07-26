
using ConsoleApp1.Entities;

Console.WriteLine("Hello, World!");


bool init = true;

Console.WriteLine("Bem vindo a um sistema imaginario:");
while (init != false)
{
    Person person = new Person();
    Console.Write("Digite o Nome: ");
    person.Name = Console.ReadLine();
    Console.Write("\nDigite o email: ");
    person.Email = Console.ReadLine();
    Console.Write("\nDigite o CPF: ");
    person.Cpf = Console.ReadLine();
    var error = person.Check();
    if (error != null)
    {
        Console.WriteLine(error);
    }
    else
    {
        Console.WriteLine("Cadastro realizado com sucesso");
        break;
    }
}

