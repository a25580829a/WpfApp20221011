using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Effects;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace WpfApp1
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        List<Drink> drinks = new List<Drink>();
        public MainWindow()
        {
            InitializeComponent();

            AddNewDrink(drinks);

            DisplayDrink(drinks);
        }

        private void DisplayDrink(List<Drink> myDrink)
        {
            foreach (Drink d in myDrink)
            {
                StackPanel sp = new StackPanel();
                CheckBox cb = new CheckBox();
                TextBox tb = new TextBox();
                Slider sl = new Slider();
                Label la = new Label();
                Binding mybinding = new Binding("Value");

                sp.Orientation = Orientation.Horizontal;
                //cb.Content = d.Name + d.Size + d.Price;
                cb.Content = $"{d.Name} {d.Size} {d.Price}";
                cb.Width = 200;
                cb.Height = 40;
                cb.Margin = new Thickness(5);

                //tb.Width = 50;
                //tb.Height = 20;
                sl.Value = 0;
                sl.Width = 100;
                sl.Maximum = 30;
                sl.Minimum = 0;
                sl.TickFrequency = 1;
                sl.IsSnapToTickEnabled = true;
                sl.ValueChanged += sl_Value_Changed;

                mybinding.Source = sl;


                la.Width = 100;
                la.SetBinding(ContentProperty, mybinding);

                sp.Children.Add(cb);
                //sp.Children.Add(tb);
                sp.Children.Add(sl);
                sp.Children.Add(la);

                stackpanel_DrinkMenu.Children.Add(sp);
            }
        }

        private void sl_Value_Changed(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            Slider targetslider = sender as Slider;
            label.Content = targetslider.Value.ToString();

        }

        private void AddNewDrink(List<Drink> mydrinks)
        {
            mydrinks.Add(new Drink() { Name = "咖啡", Size = "大杯", Price = 60 });
            mydrinks.Add(new Drink() { Name = "咖啡", Size = "小杯", Price = 50 });
            mydrinks.Add(new Drink() { Name = "紅茶", Size = "大杯", Price = 30 });
            mydrinks.Add(new Drink() { Name = "紅茶", Size = "小杯", Price = 20 });
            mydrinks.Add(new Drink() { Name = "綠茶", Size = "大杯", Price = 30 });
            mydrinks.Add(new Drink() { Name = "綠茶", Size = "小杯", Price = 20 });
        }


    }
}
