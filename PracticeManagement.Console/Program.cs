using System.ComponentModel.Design;
using System.Data.SqlTypes;
using PracticeManagement.CLI.Models;

namespace PracticeManagement.CLI
{
    internal class Program
    {
        static void Main(string[] args)
        {

            var Clients = new List<Client>();
            var Projects = new List<Project>();

            while (true)
            {
                Console.WriteLine("C. Edit Clients");
                Console.WriteLine("P. Edit Projects");
                Console.WriteLine("Q. Quit");

                var choice = Console.ReadLine() ?? string.Empty;
                if (choice.Equals("C", StringComparison.InvariantCultureIgnoreCase))
                {
                    ClientMenu(Clients);
                }
                else if (choice.Equals("P", StringComparison.InvariantCultureIgnoreCase))
                {
                    ProjectMenu(Projects, Clients);
                }
                else if (choice.Equals("Q", StringComparison.InvariantCultureIgnoreCase))
                {
                    break;
                }
                else
                {
                    Console.WriteLine("Invalid character entered.");
                }


            }


        }

        static void ClientMenu(List<Client> Clients)
        {
            while (true)
            {
                Console.WriteLine("C. Create a Client");
                Console.WriteLine("R. Read a Client");
                Console.WriteLine("U. Update a Client");
                Console.WriteLine("D. Delete a Client");
                Console.WriteLine("Q. Quit");

                var choice = Console.ReadLine() ?? string.Empty;


                if (choice.Equals("C", StringComparison.InvariantCultureIgnoreCase))
                {
                    //Create
                    Console.WriteLine("Id: ");
                    var Id = int.Parse(Console.ReadLine() ?? "0");

                    Console.WriteLine("Name: ");
                    var name = Console.ReadLine();

                    Console.WriteLine("Open Date: ");
                    var openDate = DateTime.Parse(Console.ReadLine() ?? DateTime.Today.ToString());

                    Console.WriteLine("Notes: ");
                    var Notes = Console.ReadLine() ?? string.Empty;



                    Clients.Add(
                        new Client
                        {
                            Id = Id,
                            Name = name ?? "John Doe",
                            OpenDate = openDate,
                            Notes = Notes
                        });
                    Console.WriteLine("Client added.");

                }
                else if (choice.Equals("R", StringComparison.InvariantCultureIgnoreCase))
                {
                    //Read
                    Clients.ForEach(Console.WriteLine);
                }
                else if (choice.Equals("U", StringComparison.InvariantCultureIgnoreCase))
                {
                    //Update
                    Console.WriteLine("Which client should be updated?");
                    Clients.ForEach(Console.WriteLine);
                    var updateChoice = int.Parse(Console.ReadLine() ?? "0");

                    var clientToUpdate = Clients.FirstOrDefault(s => s.Id == updateChoice);
                    if (clientToUpdate != null)
                    {
                        Console.WriteLine("What is the client's updated name?");
                        clientToUpdate.Name = Console.ReadLine() ?? "John Doe";

                        Console.WriteLine("What is the client's closed date?");
                        clientToUpdate.ClosedDate = DateTime.Parse(Console.ReadLine() ?? DateTime.Today.ToString());

                        Console.WriteLine("What is the client's updated notes?");
                        clientToUpdate.Notes = Console.ReadLine() ?? string.Empty;

                    }

                }
                else if (choice.Equals("D", StringComparison.InvariantCultureIgnoreCase))
                {
                    //Delete
                    Console.WriteLine("Which client should be deleted?");
                    Clients.ForEach(Console.WriteLine);
                    var deleteChoice = int.Parse(Console.ReadLine() ?? "0");

                    var clientToRemove = Clients.FirstOrDefault(s => s.Id == deleteChoice);
                    if (clientToRemove != null)
                    {
                        Clients.Remove(clientToRemove);
                    }
                }
                else if (choice.Equals("Q", StringComparison.InvariantCultureIgnoreCase))
                {
                    break;
                }
                else
                {
                    Console.WriteLine("Invalid character entered.");
                }
            }
        }

        static void ProjectMenu(List<Project> Projects, List<Client> Clients)
        {
            while (true)
            {
                Console.WriteLine("C. Create a Project");
                Console.WriteLine("R. Read a Project");
                Console.WriteLine("U. Update a Project");
                Console.WriteLine("D. Delete a Project");
                Console.WriteLine("Q. Quit");

                var choice = Console.ReadLine() ?? string.Empty;


                if (choice.Equals("C", StringComparison.InvariantCultureIgnoreCase))
                {
                    //Create
                    Console.WriteLine("Id: ");
                    var Id = int.Parse(Console.ReadLine() ?? "0");

                    Console.WriteLine("Open Date: ");
                    var openDate = DateTime.Parse(Console.ReadLine() ?? DateTime.Today.ToString());

                    Console.WriteLine("Short Name: ");
                    var shortName = Console.ReadLine();

                    Console.WriteLine("Long Name: ");
                    var LongName = Console.ReadLine();

                    Console.WriteLine("Client ID of linked client: ");
                    var clientChoice = int.Parse(Console.ReadLine() ?? "0");
                    var clientID = Clients.FirstOrDefault(s => s.Id == clientChoice);
                    if (clientID == null)
                    {
                        clientChoice = 0;
                    } else
                    {
                        clientChoice = clientID.Id;
                    }
                    
                    Projects.Add(
                        new Project
                        {
                            Id = Id,
                            OpenDate = openDate,
                            ShortName = shortName ?? "PX",
                            LongName = LongName ?? "Project x",      
                            ClientId = clientChoice
                        });
                    Console.WriteLine("Project added.");

                }
                else if (choice.Equals("R", StringComparison.InvariantCultureIgnoreCase))
                {
                    //Read
                    Projects.ForEach(Console.WriteLine);
                }
                else if (choice.Equals("U", StringComparison.InvariantCultureIgnoreCase))
                {
                    //Update
                    Console.WriteLine("Which project should be updated?");
                    Projects.ForEach(Console.WriteLine);
                    var updateChoice = int.Parse(Console.ReadLine() ?? "0");
                    var projectToUpdate = Projects.FirstOrDefault(s => s.Id == updateChoice);
                    if (projectToUpdate != null)
                    {
                        Console.WriteLine("What is the project's updated client ID?");
                        var clientChoice = int.Parse(Console.ReadLine() ?? "0");
                        var clientID = Clients.FirstOrDefault(s => s.Id == clientChoice);
                        if (clientID != null)
                        {
                            projectToUpdate.ClientId = clientID.Id;
                        }
                    }

                }
                else if (choice.Equals("D", StringComparison.InvariantCultureIgnoreCase))
                {
                    //Delete
                    Console.WriteLine("Which project should be deleted?");
                    Projects.ForEach(Console.WriteLine);
                    var deleteChoice = int.Parse(Console.ReadLine() ?? "0");

                    var projectToRemove = Projects.FirstOrDefault(s => s.Id == deleteChoice);
                    if (projectToRemove != null)
                    {
                        Projects.Remove(projectToRemove);
                    }
                }
                else if (choice.Equals("Q", StringComparison.InvariantCultureIgnoreCase))
                {
                    break;
                }
                else
                {
                    Console.WriteLine("Invalid character entered.");
                }
            }
        }
    }
}
