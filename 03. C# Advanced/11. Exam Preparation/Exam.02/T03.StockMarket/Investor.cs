using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace StockMarket
{
    public class Investor
    {
        private List<Stock> portfolio;
        public Investor(string fullName, string emailAddress, decimal moneyToInvest, string brokerName)
        {
            this.FullName = fullName;
            this.EmailAddress = emailAddress;
            this.MoneyToInvest = moneyToInvest;
            this.BrokerName = brokerName;
            this.portfolio = new List<Stock>();
        }
        public string FullName { get; set; }
        public string EmailAddress { get; set; }
        public decimal MoneyToInvest { get; set; }
        public string BrokerName { get; set; }
        public int Count => this.portfolio.Count;

        public void BuyStock(Stock stock)
        {
            if (stock.MarketCapitalization > 10_000 &&
                this.MoneyToInvest >= stock.PricePerShare)
            {
                this.MoneyToInvest -= stock.PricePerShare;
                this.portfolio.Add(stock);
            }

        }

        public string SellStock(string companyName, decimal sellPrice)
        {
            Stock currStock = this.portfolio.FirstOrDefault(s => s.CompanyName == companyName);

            if (currStock == null)
            {
                return $"{companyName} does not exist.";
            }

            if (sellPrice < currStock.PricePerShare)
            {
                return $"Cannot sell {companyName}.";
            }

            this.MoneyToInvest += sellPrice;
            this.portfolio.Remove(currStock);

            return $"{companyName} was sold.";
        }

        public Stock FindStock(string companyName)
        {
            return this.portfolio.FirstOrDefault(s => s.CompanyName == companyName);
        }

        public Stock FindBiggestCompany()
        {
            return this.portfolio.OrderByDescending(s => s.MarketCapitalization).FirstOrDefault();
        }

        public string InvestorInformation()
        {
            var sb = new StringBuilder();
            sb.AppendLine($"The investor {this.FullName} with a broker {this.BrokerName} has stocks:");
            foreach (var stock in this.portfolio)
            {
                sb.AppendLine(stock.ToString());
            }
            return sb.ToString().TrimEnd();
        }
    }
}