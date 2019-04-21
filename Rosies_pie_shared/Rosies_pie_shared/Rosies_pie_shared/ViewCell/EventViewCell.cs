 
using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Input;
using Xamarin.Forms;
 

namespace Rosies_pie_shared
{
    public class EventViewCell : ViewCell
    {

 

        public EventViewCell()
        {


        // Product name
        Label lblEventName = new Label
            {
                TextColor = Color.Black,
                FontSize = 20,
                HorizontalOptions = LayoutOptions.Center,
                VerticalOptions = LayoutOptions.Center,
                HorizontalTextAlignment = TextAlignment.Center
                
            };

            Label lblAddress = new Label();
            lblAddress.SetBinding(Label.TextProperty, new Binding("Address"));
            
           // var binding = new Binding("Address");

            var bindingAddrss = "1696 Bloor Street";
            Button btnDirections = new Button
            {
                VerticalOptions = LayoutOptions.Center,
                HorizontalOptions = LayoutOptions.Center,
                Image = "baseline_directions_white_36.png",
                BackgroundColor = Color.Transparent,
                Command = new Command <string>(SetDirections),
                CommandParameter = bindingAddrss



            };
   

            Label lblEventDay = new Label
            {
 
                HorizontalOptions = LayoutOptions.Center,
                VerticalOptions = LayoutOptions.Center,
                FontSize = 16
            };
            Label lblEventTime = new Label
            {
                HorizontalOptions = LayoutOptions.Center,
                VerticalOptions = LayoutOptions.Center,
                FontSize = 16
            };

            lblEventName.SetBinding(Label.TextProperty, new Binding("EventName"));

            // TODO: do some calculations to get Event Day
            lblEventDay.SetBinding(Label.TextProperty, new Binding("EventStartDate",BindingMode.Default,null,null, " {0:ddd, dd MMM yyy}"));


            lblEventTime.SetBinding(Label.TextProperty, new Binding("EventTime",BindingMode.Default,null,null,"{0}"));


    

            StackLayout stlRight = new StackLayout
            {
                Children = { btnDirections },
                HorizontalOptions = LayoutOptions.EndAndExpand
            };

            StackLayout stlEventCell = new StackLayout
            {
                Children = {lblEventName, lblEventDay,lblEventTime },
                Padding = 5
            };
            StackLayout stlMain = new StackLayout
            {
                Orientation = StackOrientation.Horizontal,
                Children = {stlEventCell, stlRight}
            };
            Frame frmCell = new Frame
            {
                CornerRadius = 4,
                HasShadow = true,
                Content = stlMain,
                Margin = 5,
            
            };

            View = frmCell;

        }
         async void SetDirections(string toAddress)
        {
            try
            {

                string Address = "https://www.google.com/maps/dir/'your location'/" + toAddress + "";

                Device.OpenUri(new Uri(Address));
                

            }

            catch (Exception)
            {

                await App.Current.MainPage.DisplayAlert("Error", "Check Internet connection", "Ok");
            }
        }
 
    }
}
