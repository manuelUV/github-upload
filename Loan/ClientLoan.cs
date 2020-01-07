using System;

namespace Loan
{
    public class ClientLoan
    {
        //Folio unico por cada prestamo
        public string Folio { get; private set; }
        // Esta es la cantidad inicial con la que se dio el prestamo
        public decimal Amount { get; private set; }
        /* 
        Esta es la cantidad actual que se va descontando
        conforme se paga el prestamo
        */ 
        public decimal CurrentAmount { get; private set; }
        /*
        El plazo de los pagos
         */
        public int Count { get; private set; }

        /*
        La fecha en que se dio el prestamo
         */
        public DateTime InitialDate { get; private set; }

        //Fecha en que se realiza el ultimo abono
        public DateTime DayOfPay { get; private set; }

        //strikes si no paga el cliente 3 y se cancela los nuevos prestamos
        public int Strike { get; private set; }

        
        internal void SetInitialDate(string date)
        {
            InitialDate = Convert.ToDateTime(date);
        }

        /*
        La fecha en que se debe de dar el último pago
         */
        public DateTime FinalDate { get; private set; }

        public ClientLoan() 
        {
            Folio = Guid.NewGuid().ToString();
            Strike = 0;
        }

        public ClientLoan(decimal amount, decimal currentAmount, int count, 
            DateTime initialDate, DateTime finalDate,int strike)
        {
            Amount = amount;
            CurrentAmount = currentAmount;
            Count = count;
            InitialDate = initialDate;
            FinalDate = finalDate;
            Strike = strike;
        }

        public void SetInitialAmount(decimal amount)
        {
            if (amount <= 0)
            {
                throw new Exception("Ingrese un valor mayor a 0");                
            }
            if (amount > 50000)
            {
                throw new Exception("No se permiten valores mayor a 50000");
            }
            Amount = amount;
            CurrentAmount = amount;
        }

        public void DescountCurrentAmount(decimal amount)
        {
            if (amount < 0)
            {
                throw new Exception("Valor debe ser mayor a 0");
            }
            var payValue = (Amount / Count);

            if (payValue != amount && Strike<3)
            {
                                
                if (amount == 0 )
                {
                    Strike += 1;
                }
               // throw new Exception("El valor ingresado no corresponde al pago mensual");
            }

            CurrentAmount -= amount;
        }

        public void SetCount(int count)
        {
            if (count <= 0)
            {
                throw new Exception("El número de pagos deber ser mayor a 0");
            }
            Count = count;
        }
        public void SetDayOfPay(string date)
        {
            
            DayOfPay = Convert.ToDateTime(date);
        }
    }
}