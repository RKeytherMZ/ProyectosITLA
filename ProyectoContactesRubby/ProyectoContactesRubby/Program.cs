Console.WriteLine("Bienvenido a mi lista de Contactes");

// Lista e información de contactos
bool runing = true;
List<int> ids = new List<int>();
Dictionary<int, string> names = new Dictionary<int, string>();
Dictionary<int, string> lastnames = new Dictionary<int, string>();
Dictionary<int, string> addresses = new Dictionary<int, string>();
Dictionary<int, string> telephones = new Dictionary<int, string>();
Dictionary<int, string> emails = new Dictionary<int, string>();
Dictionary<int, int> ages = new Dictionary<int, int>();
Dictionary<int, bool> bestFriends = new Dictionary<int, bool>();

while (runing)
{
    Console.WriteLine(@"1. Agregar Contacto     2. Ver Contactos    3. Buscar Contactos     4. Modificar Contacto   5. Eliminar Contacto    6. Salir");
    Console.WriteLine("Digite el número de la opción deseada");

    int typeOption = Convert.ToInt32(Console.ReadLine());

    switch (typeOption)
    {
        case 1:
            AddContact(ids, names, lastnames, addresses, telephones, emails, ages, bestFriends);
            break;

        case 2:
            Console.WriteLine($"Nombre          Apellido        Dirección       Teléfono      Email       Edad      Es Mejor Amigo?");
            Console.WriteLine($"_________________________________________________________________________________________________");
            foreach (var id in ids)
            {
                string isBestFriendStr = bestFriends[id] ? "Si" : "No";
                Console.WriteLine($"{names[id]}    {lastnames[id]}    {addresses[id]}    {telephones[id]}    {emails[id]}    {ages[id]}    {isBestFriendStr}");
            }
            break;

        case 3:
            Console.WriteLine("Ingrese el ID del contacto que desea buscar:");
            if (int.TryParse(Console.ReadLine(), out int idIndicado))
            {
                SearchContact(idIndicado, names, lastnames, telephones, addresses, ages, bestFriends);
            }
            else
            {
                Console.WriteLine("ID inválido.");
            }
            break;

        case 4:
            Console.WriteLine("Ingrese el ID del contacto que desea modificar:");
            int idModify = Convert.ToInt32(Console.ReadLine());

            if (names.ContainsKey(idModify))
            {
                ModifyContact(idModify, names, lastnames, addresses, telephones, emails, ages, bestFriends);
            }
            else
            {
                Console.WriteLine("El contacto no existe.");
            }
            break;

        case 5:
            Console.WriteLine("Digite el ID del contacto que desea eliminar: ");
            int idEliminate = Convert.ToInt32(Console.ReadLine());

            if (names.ContainsKey(idEliminate))
            {
                EliminateContact(idEliminate,ids, names, lastnames, addresses, telephones, emails, ages, bestFriends);
            }
            else
            {
                Console.WriteLine("El contacto no existe.");
            }
            break;

        case 6:
            runing = false;
            break;

        default:
            Console.WriteLine("Opción no válida.");
            break;
    }
}

// Función para agregar un contacto
static void AddContact(List<int> ids, Dictionary<int, string> names, Dictionary<int, string> lastnames, Dictionary<int, string> addresses, Dictionary<int, string> telephones, Dictionary<int, string> emails, Dictionary<int, int> ages, Dictionary<int, bool> bestFriends)
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

    Console.WriteLine("Es mejor amigo? (1. Si / 2. No):");
    bool isBestFriend = Convert.ToInt32(Console.ReadLine()) == 1;

    var id = ids.Count + 1;
    ids.Add(id);
    names[id] = name;
    lastnames[id] = lastname;
    addresses[id] = address;
    telephones[id] = phone;
    emails[id] = email;
    ages[id] = age;
    bestFriends[id] = isBestFriend;
}

// Función para buscar un contacto
static void SearchContact(int idIndicado, Dictionary<int, string> names, Dictionary<int, string> lastnames, Dictionary<int, string> telephones, Dictionary<int, string> addresses, Dictionary<int, int> ages, Dictionary<int, bool> bestFriends)
{
    if (!names.ContainsKey(idIndicado))
    {
        Console.WriteLine("El contacto no existe.");
        return;
    }

    string nombre = names[idIndicado];
    string apellido = lastnames[idIndicado];
    string telefono = telephones[idIndicado];
    string direccion = addresses[idIndicado];
    int edad = ages[idIndicado];
    string isBestFriendStr = bestFriends[idIndicado] ? "Si" : "No";

    Console.WriteLine("\nInformación del Contacto:");
    Console.WriteLine($"ID: {idIndicado}");
    Console.WriteLine($"Nombre: {nombre}");
    Console.WriteLine($"Apellido: {apellido}");
    Console.WriteLine($"Teléfono: {telefono}");
    Console.WriteLine($"Edad: {edad}");
    Console.WriteLine($"Dirección: {direccion}");
    Console.WriteLine($"Es Mejor Amigo: {isBestFriendStr}");
}

//Funcion para Modificar Contacto
static void ModifyContact(int id, Dictionary<int, string> names, Dictionary<int, string> lastnames, Dictionary<int, string> addresses, Dictionary<int, string> telephones, Dictionary<int, string> emails, Dictionary<int, int> ages, Dictionary<int, bool> bestFriends)
{
    Console.WriteLine($"Modificando el contacto: {names[id]} {lastnames[id]}");

    Console.WriteLine("Digite el nuevo nombre (o presione Enter para mantener el actual):");
    string newName = Console.ReadLine();
    if (!string.IsNullOrWhiteSpace(newName)) names[id] = newName;

    Console.WriteLine("Digite el nuevo apellido (o presione Enter para mantener el actual):");
    string newLastname = Console.ReadLine();
    if (!string.IsNullOrWhiteSpace(newLastname)) lastnames[id] = newLastname;

    Console.WriteLine("Digite la nueva dirección (o presione Enter para mantener la actual):");
    string newAddress = Console.ReadLine();
    if (!string.IsNullOrWhiteSpace(newAddress)) addresses[id] = newAddress;

    Console.WriteLine("Digite el nuevo teléfono (o presione Enter para mantener el actual):");
    string newPhone = Console.ReadLine();
    if (!string.IsNullOrWhiteSpace(newPhone)) telephones[id] = newPhone;

    Console.WriteLine("Digite el nuevo email (o presione Enter para mantener el actual):");
    string newEmail = Console.ReadLine();
    if (!string.IsNullOrWhiteSpace(newEmail)) emails[id] = newEmail;

    Console.WriteLine("Digite la nueva edad (o presione Enter para mantener la actual):");
    string newAge = Console.ReadLine();
    if (!string.IsNullOrWhiteSpace(newAge) && int.TryParse(newAge, out int age)) ages[id] = age;

    Console.WriteLine("Es mejor amigo? (1. Si / 2. No / Enter para mantener el actual):");
    string newBestFriend = Console.ReadLine();
    if (newBestFriend == "1") bestFriends[id] = true;
    if (newBestFriend == "2") bestFriends[id] = false;

    Console.WriteLine("Contacto modificado con éxito.");
}

//Funcion para eliminar contacto
static void EliminateContact(int idEliminate, List<int> ids, Dictionary<int, string> names, Dictionary<int, string> lastnames, Dictionary<int, string> addresses, Dictionary<int, string> telephones, Dictionary<int, string> emails, Dictionary<int, int> ages, Dictionary<int, bool> bestFriends)
{
    Console.WriteLine("Esta seguro de que desea eliminar este contacto? 1.Si , 2.No");
    int SafeDelite = Convert.ToInt32(Console.ReadLine());
    if (SafeDelite == 1)
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







