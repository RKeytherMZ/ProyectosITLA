using System;
using System.Collections.Generic;

class Contactes
{
    public List<int> ids;
    public Dictionary<int, string> names;
    public Dictionary<int, string> lastnames;
    public Dictionary<int, string> addresses;
    public Dictionary<int, string> telephones;
    public Dictionary<int, string> emails;
    public Dictionary<int, int> ages;
    public Dictionary<int, bool> bestFriends;

    public Contactes()
    {
        ids = new List<int>();
        names = new Dictionary<int, string>();
        lastnames = new Dictionary<int, string>();
        addresses = new Dictionary<int, string>();
        telephones = new Dictionary<int, string>();
        emails = new Dictionary<int, string>();
        ages = new Dictionary<int, int>();
        bestFriends = new Dictionary<int, bool>();
    }

    public void AddContact()
    {
        Console.WriteLine("Digite el nombre de la persona:");
        string name = Console.ReadLine();

        Console.WriteLine("Digite el apellido de la persona:");
        string lastname = Console.ReadLine();

        Console.WriteLine("Digite la dirección:");
        string address = Console.ReadLine();

        Console.WriteLine("Digite el teléfono de la persona:");
        string phone = Console.ReadLine();

        Console.WriteLine("Digite el email de la persona:");
        string email = Console.ReadLine();

        Console.WriteLine("Digite la edad de la persona en números:");
        int age = Convert.ToInt32(Console.ReadLine());

        Console.WriteLine("Es mejor amigo? (1. Sí / 2. No):");
        bool isBestFriend = Convert.ToInt32(Console.ReadLine()) == 1;

        int id = ids.Count + 1;
        ids.Add(id);
        names[id] = name;
        lastnames[id] = lastname;
        addresses[id] = address;
        telephones[id] = phone;
        emails[id] = email;
        ages[id] = age;
        bestFriends[id] = isBestFriend;

        Console.WriteLine("Contacto agregado exitosamente.");
    }

    public void SearchContact(int idIndicado)
    {
        if (!names.ContainsKey(idIndicado))
        {
            Console.WriteLine("El contacto no existe.");
            return;
        }

        Console.WriteLine("\nInformación del Contacto:");
        Console.WriteLine($"ID: {idIndicado}");
        Console.WriteLine($"Nombre: {names[idIndicado]}");
        Console.WriteLine($"Apellido: {lastnames[idIndicado]}");
        Console.WriteLine($"Teléfono: {telephones[idIndicado]}");
        Console.WriteLine($"Edad: {ages[idIndicado]}");
        Console.WriteLine($"Dirección: {addresses[idIndicado]}");
        Console.WriteLine($"Es Mejor Amigo: {(bestFriends[idIndicado] ? "Sí" : "No")}");
    }

    public void ModifyContact(int id)
    {
        if (!names.ContainsKey(id))
        {
            Console.WriteLine("El contacto no existe.");
            return;
        }

        Console.WriteLine($"Modificando el contacto: {names[id]} {lastnames[id]}");

        Console.WriteLine("Nuevo nombre (Enter para mantener el actual):");
        string newName = Console.ReadLine();
        if (!string.IsNullOrWhiteSpace(newName)) names[id] = newName;

        Console.WriteLine("Nuevo apellido:");
        string newLastname = Console.ReadLine();
        if (!string.IsNullOrWhiteSpace(newLastname)) lastnames[id] = newLastname;

        Console.WriteLine("Nueva dirección:");
        string newAddress = Console.ReadLine();
        if (!string.IsNullOrWhiteSpace(newAddress)) addresses[id] = newAddress;

        Console.WriteLine("Nuevo teléfono:");
        string newPhone = Console.ReadLine();
        if (!string.IsNullOrWhiteSpace(newPhone)) telephones[id] = newPhone;

        Console.WriteLine("Nuevo email:");
        string newEmail = Console.ReadLine();
        if (!string.IsNullOrWhiteSpace(newEmail)) emails[id] = newEmail;

        Console.WriteLine("Nueva edad:");
        string newAge = Console.ReadLine();
        if (int.TryParse(newAge, out int age)) ages[id] = age;

        Console.WriteLine("Es mejor amigo? (1. Sí / 2. No / Enter para mantener):");
        string newBestFriend = Console.ReadLine();
        if (newBestFriend == "1") bestFriends[id] = true;
        if (newBestFriend == "2") bestFriends[id] = false;

        Console.WriteLine("Contacto modificado con éxito.");
    }

    public void EliminateContact(int idEliminate)
    {
        if (!names.ContainsKey(idEliminate))
        {
            Console.WriteLine("El contacto no existe.");
            return;
        }

        Console.WriteLine("¿Está seguro de que desea eliminar este contacto? (1. Sí / 2. No)");
        int confirm = Convert.ToInt32(Console.ReadLine());

        if (confirm == 1)
        {
            ids.Remove(idEliminate);
            names.Remove(idEliminate);
            lastnames.Remove(idEliminate);
            addresses.Remove(idEliminate);
            telephones.Remove(idEliminate);
            emails.Remove(idEliminate);
            ages.Remove(idEliminate);
            bestFriends.Remove(idEliminate);

            Console.WriteLine("Contacto eliminado correctamente.");
        }
        else
        {
            Console.WriteLine("Eliminación cancelada.");
        }
    }

    public void ShowContacts()
    {
        Console.WriteLine($"_________________________________________________________________________________________________");
        Console.WriteLine($"ID  | Nombre   | Apellido  | Dirección  | Teléfono  | Email  | Edad | Mejor Amigo");
        Console.WriteLine($"_________________________________________________________________________________________________");

        foreach (var id in ids)
        {
            string isBestFriendStr = bestFriends[id] ? "Sí" : "No";
            Console.WriteLine($"{id}  | {names[id]}  | {lastnames[id]}  | {addresses[id]}  | {telephones[id]}  | {emails[id]}  | {ages[id]}  | {isBestFriendStr}");
        }
    }
}

class Program
{
    static void Main()
    {
        Contactes agenda = new Contactes();
        bool running = true;

        while (running)
        {
            Console.WriteLine(@"1. Agregar Contacto  
2. Ver Contactos  
3. Buscar Contacto  
4. Modificar Contacto  
5. Eliminar Contacto  
6. Salir");

            Console.WriteLine("Digite el número de la opción deseada:");

            try
            {
                int option = Convert.ToInt32(Console.ReadLine());

                switch (option)
                {
                    case 1:
                        agenda.AddContact();
                        break;
                    case 2:
                        agenda.ShowContacts();
                        break;
                    case 3:
                        Console.WriteLine("Ingrese el ID del contacto que desea buscar:");
                        if (int.TryParse(Console.ReadLine(), out int idSearch))
                        {
                            agenda.SearchContact(idSearch);
                        }
                        else
                        {
                            Console.WriteLine("ID inválido.");
                        }
                        break;
                    case 4:
                        Console.WriteLine("Ingrese el ID del contacto que desea modificar:");
                        if (int.TryParse(Console.ReadLine(), out int idModify))
                        {
                            agenda.ModifyContact(idModify);
                        }
                        else
                        {
                            Console.WriteLine("ID inválido.");
                        }
                        break;
                    case 5:
                        Console.WriteLine("Ingrese el ID del contacto que desea eliminar:");
                        if (int.TryParse(Console.ReadLine(), out int idEliminate))
                        {
                            agenda.EliminateContact(idEliminate);
                        }
                        else
                        {
                            Console.WriteLine("ID inválido.");
                        }
                        break;
                    case 6:
                        running = false;
                        break;
                    default:
                        Console.WriteLine("Opción no válida.");
                        break;
                }
            }
            catch (FormatException)
            {
                Console.WriteLine("Error: Debe ingresar un número válido.");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Ocurrió un error inesperado: {ex.Message}");
            }
        }
    }
}






