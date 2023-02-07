using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace RiderApp
{
    //remove to class library
    public class Order
    {
        public int Id { get; set; }
        public DateTime StartTime { get; set; }
        public string StartLocation { get; set; }
        public string EndLocation { get; set; }
        public DateTime EndTime { get; set; }
        public TimeSpan Duration { get { return EndTime - StartTime; } }

        public double Distance { get; set; }
        //km
        public int Price { get; set; }
        public int Rating { get; set; }
        public string Feedback { get; set; }
    }

    public class Rider
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public string PasswordHash { get; set; }
        //RegistartionDate
    }

    public class Totals
    {
        private readonly List<Order> orders;

        public Totals(List<Order> orders)
        {
            if (orders == null)
                throw new InvalidOperationException("Orders list can not be null");

            this.orders = orders;
        }
        public double TotalDist { get { return orders.Sum(o => o.Distance); } }
        public int TotalOrders { get { return orders.Count; } }
        public int TotalPrice { get { return orders.Sum(o => o.Price); } }
    }

    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class OrderHistoryPage : ContentPage
    {
        private readonly List<Order> orders;
        private readonly Rider rider;
        public OrderHistoryPage()
        {
            InitializeComponent();
            rider = new Rider() { Name = "Олена", Surname = "Березоруцька", Email = "av.golberg@gmail.com", Phone = "38 (098) 000-55-80" };
            orders = new List<Order>() { new Order() { StartLocation = "Дерібасівська, 14", EndLocation = "Генерала Бочарова, 98", StartTime = new DateTime(2022, 12, 21, 13, 30, 0), EndTime = new DateTime(2022, 12, 21, 14, 30, 0), Price = 200, Distance = 14 }, new Order() { StartLocation = "Генерала Бочарова, 98", EndLocation = "Пушкінська, 2", StartTime = new DateTime(2022, 10, 12, 10, 12, 0), EndTime = new DateTime(2022, 10, 12, 11, 15, 0), Price = 220, Distance = 14.2 } }; // request to server to get all riders` orders

            ordersListView.ItemsSource = orders;
            phoneLabel.Text = rider.Phone;

            var firstOrderDate = orders.Min(o => o.StartTime);
            var monthsCount = Math.Abs((DateTime.Now.Month - firstOrderDate.Month) + 12 * (DateTime.Now.Year - firstOrderDate.Year));
            for (int i = monthsCount; i > 0; i--)
            {
                monthsPicker.Items.Add(firstOrderDate.AddMonths(i).ToString("MMMM, yyyy", CultureInfo.CreateSpecificCulture("uk-ua")));
            }
            monthsPicker.Items.Add(firstOrderDate.ToString("MMMM, yyyy", CultureInfo.CreateSpecificCulture("uk-ua")));
            monthsPicker.Items.Add("усі");

            SetTotals(orders);
        }
        private async void DisableHistoryTapped(object sender, EventArgs e)
        {
            //request to server
            await DisplayAlert("Успішна операція", "Історію поїздок відключено!", "Ок");
        }
        private void monthsPicker_SelectedIndexChanged(object sender, EventArgs e)
        {
            if((sender as Picker).SelectedItem != null)
                placeholder.TextColor = Color.White;

            List<Order> ordersPerMonth;

            if (monthsPicker.SelectedItem.ToString().Equals("усі"))
                ordersPerMonth = orders;
            else ordersPerMonth = orders.Where(o => o.StartTime.ToString("MMMM, yyyy", CultureInfo.CreateSpecificCulture("uk-ua")).Equals(monthsPicker.SelectedItem.ToString())).ToList();

            SetTotals(ordersPerMonth);
        }
        private void SetTotals(List<Order> orders)
        {
            var totals = new Totals(orders);
            ordersListView.ItemsSource = orders;
            var textDeclension = DeclensionGenerator.Generate(totals.TotalOrders, "замовлення", "замовлення", "замовлень");
            totalOrdersLabel.Text = $"{totals.TotalOrders} {textDeclension} за номером";
            totalLabel.BindingContext = totals;
        }

        private void CloseTapped(object sender, EventArgs e)
        {
            FlyoutPage menu = (FlyoutPage)Application.Current.MainPage;
            menu.IsPresented = true;
            menu.Detail = App.mainNavigationPage;
        }
    }
}