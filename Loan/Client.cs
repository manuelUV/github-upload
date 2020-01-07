using System;
using System.Collections.Generic;
using System.Linq;

namespace Loan
{
    public class Client
    {        
        public string Name { get; set; }
        public string LastName { get; set; }
        public string Street { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        private List<ClientLoan> clientLoans;
        public IReadOnlyCollection<ClientLoan> ClientLoans => clientLoans.AsReadOnly();
        private List<Debit> debits;
        public IReadOnlyCollection<Debit> Debits => debits.AsReadOnly();

        public Client()
        {}

        public Client(string name, string lastName, string street, string city,
            string state, List<ClientLoan> clientLoans, List<Debit> debits)
        {
            Name = name;
            LastName = lastName;
            Street = street;
            City = city;
            State = state;
            this.clientLoans = clientLoans;
            this.debits = debits;
        }

        public void AddLoan(ClientLoan loan)
        {
            if (loan == null)
            {
                throw new Exception("Valor nulo");                
            }
            clientLoans.Add(loan);
        }

        public void PayLoan(string folio, decimal amount)
        {
            if (!clientLoans.Any(l => l.Folio == folio))
            {
                throw new Exception("No se encontro ningun prestamo con el folio ingresado");
            }

            clientLoans.FirstOrDefault(l => l.Folio == folio).DescountCurrentAmount(amount);            
        }

        public decimal GetCurrentAmount(string folio)
        {
            if (!clientLoans.Any(l => l.Folio == folio))
            {
                throw new Exception("No se encontro ningun prestamo con el folio ingresado");
            }

            return clientLoans.FirstOrDefault(l => l.Folio == folio).CurrentAmount;
        }
    }
}