using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace StockMarket
{
    public class Investor
    {
        public Investor(string fullName, string emailAddress, decimal moneyToInvest, string brokerName)
        {
            this.FullName = fullName;
            this.EmailAddress = emailAddress;
            this.MoneyToInvest = moneyToInvest;
            this.BrokerName = brokerName;
            this.Portfolio = new List<Stock>();
        }
        public List<Stock> Portfolio { get; set; }
        public string FullName { get; set; }
        public string EmailAddress { get; set; }
        public decimal MoneyToInvest { get; set; }
        public string BrokerName { get; set; }
        public int Count => this.Portfolio.Count;

        public void BuyStock(Stock stock)
        {
            if (stock.MarketCapitalization <= 10_000 &&
                this.MoneyToInvest < stock.MarketCapitalization)
            {
                return;
            }

            this.MoneyToInvest -= stock.MarketCapitalization;
            this.Portfolio.Add(stock);
        }

        public string SellStock(string companyName, decimal sellPrice)
        {
            Stock currStock = this.Portfolio.FirstOrDefault(s => s.CompanyName == companyName);

            if (currStock == null)
            {
                return $"{companyName} does not exist.";
            }

            if (sellPrice < currStock.PricePerShare)
            {
                return $"Cannot sell {companyName}.";
            }

            this.MoneyToInvest += sellPrice;
            this.Portfolio.Remove(currStock);

            return $"{companyName} was sold.";
        }

        public Stock FindStock(string companyName)
        {
            return this.Portfolio.FirstOrDefault(s => s.CompanyName == companyName);
        }

        public Stock FindBiggestCompany()
        {
            return this.Portfolio.OrderByDescending(s => s.MarketCapitalization).FirstOrDefault();
        }

        public string InvestorInformation()
        {
            var sb = new StringBuilder();
            sb.AppendLine($"The investor {this.FullName} with a broker {this.BrokerName} has stocks:");
            foreach (var stock in this.Portfolio)
            {
                sb.AppendLine(stock.ToString());
            }
            return sb.ToString().TrimEnd();
        }
    }
}