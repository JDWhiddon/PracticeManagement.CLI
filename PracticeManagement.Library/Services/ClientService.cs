using PracticeManagement.CLI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PracticeManagement.Library.Services
{
    public class ClientService
    {
        private static ClientService? instance;
        private static object _lock = new object();

        public static ClientService Current
        {
            get
            {
                lock(_lock)
                {
                    if (instance == null)
                    {
                        instance = new ClientService(); 
                    }
                }
                return instance;
            }
        }

        private List<Client> listOfClients;

        private ClientService()
        {
            listOfClients = new List<Client> {
                new Client {Id = 1, Name = "John"},
                new Client {Id = 2, Name = "Doe"},
                new Client {Id = 3, Name = "Ron"}
            };
        }

        public List<Client> ListOfClients { 
            get {
                return listOfClients;
            } 
        }

        public List<Client> Search(string query) => ListOfClients.Where(s => s.Name.ToUpper().Contains(query.ToUpper())).ToList();
        public Client? Get(int id) => listOfClients.FirstOrDefault(e => e.Id == id);

        public void AddOrUpdate(Client? client)
        {
            if (client.Id == 0)
            {
                //add
                client.Id = LastId + 1;
                listOfClients.Add(client);
            }
        }

        private int LastId { 
            get
            {
                return ListOfClients.Any() ? ListOfClients.Select(c => c.Id).Max() : 1;
            } 
        }


        public void Delete(int id)
        {
            var studentToRemove = Get(id);
            if (studentToRemove != null)
            {
                listOfClients.Remove(studentToRemove);
            }
        }
        public void Read() => listOfClients.ForEach(Console.WriteLine);
    }
}
