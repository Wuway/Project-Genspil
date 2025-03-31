using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project_Genspil
{
    class Request
    {
        private string nameRequest;
        private string emailRequest;
        private string phoneRequest;
        private string titleRequest;
        private string versionRequest;
        private char conditionRequest;
        public string Name
        {
            get { return nameRequest; }
            set { nameRequest = value; }
        }
        public string Email
        {
            get { return emailRequest; }
            set { emailRequest = value; }
        }
        public string Phone
        {
            get { return phoneRequest; }
            set { phoneRequest = value; }
        }
        public string Title
        {
            get { return titleRequest; }
            set { titleRequest = value; }
        }
        public string Version
        {
            get { return versionRequest; }
            set { versionRequest = value; }
        }
        public char Condition
        {
            get { return conditionRequest; }
            set { conditionRequest = value; }
        }

        public static List<Request> requests = new List<Request>();
        public static void InitializedPredefinedRequests()
        {
            //tilføjer foruddefinerede forespørgsler
            requests.Add(new Request { nameRequest = "Morten Jensen", emailRequest = "morten.jensen@gmail.com", phoneRequest = "22419866", titleRequest = "Uno", versionRequest = "udviddet", conditionRequest = 'B' });
            requests.Add(new Request { nameRequest = "Anne Hansen", emailRequest = "annehansen88@gmail.com", phoneRequest = "61582274", titleRequest = "Partners", versionRequest = "standard", conditionRequest = 'A' });
        }
        public Request() { }
        public Request(string nameRequest, string emailRequest, string phoneRequest, string titleRequest, string versionRequest, char conditionRequest)
        {
            Name = nameRequest;
            Email = emailRequest;
            Phone = phoneRequest;
            Title = titleRequest;
            Version = versionRequest;
            Condition = conditionRequest;
        }
        public bool AddRequest(List<Request> listRequests)
        {
            Console.Clear();
            Console.WriteLine("Du har valgt at oprette en forespørgsel. Indtast følgende oplysninger:\n-----------------------------------------------------------------------");
            Console.WriteLine("Indtast kundens navn og efternavn: ");
            string nameRequest = Console.ReadLine();
            Console.WriteLine("Din e-mail: ");
            string emailRequest = Console.ReadLine();
            Console.WriteLine("Dit telefonnummer: ");
            string phoneRequest = Console.ReadLine();
            Console.WriteLine("Spillets navn: ");
            string titleRequest = Console.ReadLine();
            Console.WriteLine("Udgave: ");
            string versionRequest = Console.ReadLine();
            Console.WriteLine("Indtast ønsket stand, som minimum - (nyt (A), god men brugt (B), slidt (C) og reperation (D): ");
            char conditionRequest = char.Parse(Console.ReadLine());
            Console.WriteLine("Vil du gemme forespørgslen ? (Ja / Nej)\n");
            string saveRequest = Console.ReadLine();
            string upperSaveRequest = saveRequest.ToUpper();

            if (upperSaveRequest == "JA")
            {
                Console.Clear();
                Request newRequest = new Request(nameRequest, emailRequest, phoneRequest, titleRequest, versionRequest, conditionRequest);
                requests.Add(newRequest);
                Console.WriteLine($"Navn: {nameRequest} \nEmail: {emailRequest}\nTlfnr. {phoneRequest}\nSpil: {titleRequest}\nUdgave: {versionRequest}\nØnsket stand (som minimum): {conditionRequest}\n");
                Console.WriteLine("Forespørgslen er gemt. Indtast vilkårlig tast for at blive sendt til hovedmenuen.\n");
                Console.ReadLine();
            }
            else
            {
                Console.Clear();
                Console.WriteLine("Forespørgslen er annulleret. Indtast vilkårlig tast for at blive sendt til hovedmenuen.\n");
                Console.ReadLine();
            }
            return false; // Return false to break the loop in Program.cs
        }
        public static List<Request> GetRequests()
        {
            return requests; 
        }
    }
}