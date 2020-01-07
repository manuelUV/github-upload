using System;
using System.Collections.Generic;

namespace Loan
{
    class Program
    {
        static void Main(string[] args)
        {
            var juanito = new Client("Juanito", "Garcia", "Calle dos",
                "Tepic", "Nayarit", new List<ClientLoan>(), new List<Debit>());

            Console.WriteLine("Se registro a un cliente llamado: {0}", juanito.Name);
            var loan = new ClientLoan();
            Console.WriteLine("Se creo un prestamo con el folio: {0}", loan.Folio);
            loan.SetInitialAmount(10000);
            Console.WriteLine("El prestamo será de: {0}", loan.Amount);
            loan.SetCount(5);
            Console.WriteLine("Y tendra un plazo de {0} pagos", loan.Count);
            loan.SetInitialDate("2019/09/30");
            Console.WriteLine("La fecha inicial del prestamo es {0}",loan.InitialDate);
            juanito.AddLoan(loan);
            Console.WriteLine("Se la ha otorgado el prestamo a Juanito");
            juanito.PayLoan(loan.Folio, 2000);
            loan.SetDayOfPay("2019/10/30");
            Console.WriteLine("Se a abonado a cuenta fecha: {0}",loan.DayOfPay);
            Console.WriteLine("Queda {0} por pagar", juanito.GetCurrentAmount(loan.Folio));
            juanito.PayLoan(loan.Folio, 2000);
            loan.SetDayOfPay("2019/11/30");
            Console.WriteLine("Se a abonado a cuenta fecha: {0}", loan.DayOfPay);
            Console.WriteLine("Queda {0} por pagar", juanito.GetCurrentAmount(loan.Folio));
            loan.SetDayOfPay("2019/12/30");
            juanito.PayLoan(loan.Folio, 0);
            Console.WriteLine("Queda {0} por pagar", juanito.GetCurrentAmount(loan.Folio));
            Console.WriteLine("Tiene {0} Strikes", loan.Strike);
            loan.SetDayOfPay("2020/01/30");
            juanito.PayLoan(loan.Folio, 0);
            Console.WriteLine("Queda {0} por pagar", juanito.GetCurrentAmount(loan.Folio));
            Console.WriteLine("Tiene {0} Strikes", loan.Strike);
            loan.SetDayOfPay("2020/02/29");
            juanito.PayLoan(loan.Folio, 0);
            Console.WriteLine("Queda {0} por pagar", juanito.GetCurrentAmount(loan.Folio));
            Console.WriteLine("Tiene {0} Strikes", loan.Strike);
            Console.ReadLine();
        }
    }
}
