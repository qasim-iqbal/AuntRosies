using System;
using System.Collections.Generic;
using System.Text;
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
                FontSize = 18,
                HorizontalOptions = LayoutOptions.Center,
                VerticalOptions = LayoutOptions.Center,
                
            };
            Button btnDirections = new Button
            {
                Text = "Directions",
                VerticalOptions = LayoutOptions.Center,
                HorizontalOptions = LayoutOptions.Center,
 
                FontSize = 14
            };
            Label lblEventDay = new Label
            {
                VerticalOptions = LayoutOptions.Start,
                HorizontalOptions = LayoutOptions.End,
                FontSize = 12
            };
            Label lblEventTime = new Label
            {
                HorizontalOptions = LayoutOptions.Center,
                VerticalOptions = LayoutOptions.Center,
                FontSize = 14
            };

            // Defining the Grid Layout 4 rows 2 columns
            Grid grdEventCell = new Grid
            {
                RowDefinitions =
                {
                    new RowDefinition {Height = new GridLength(10,GridUnitType.Auto)},
                    new RowDefinition {Height = new GridLength(20,GridUnitType.Auto)},
                    new RowDefinition {Height = new GridLength(10,GridUnitType.Auto)},
                    new RowDefinition {Height = new GridLength(15,GridUnitType.Auto)},

                },
                ColumnDefinitions =
                {
                    //new ColumnDefinition { Width = new GridLength(3,GridUnitType.Star)},
                    new ColumnDefinition { Width = new GridLength(1,GridUnitType.Auto)}
                },

                ColumnSpacing = 5,
                RowSpacing = 5,
                Padding = 5

            };

            // (c,r) format for showing row and column number placement
            grdEventCell.Children.Add(lblEventDay, 0, 0);  // top right
            grdEventCell.Children.Add(lblEventName, 0, 1); 
            grdEventCell.Children.Add(lblEventTime, 0, 2);
            grdEventCell.Children.Add(btnDirections, 0, 3);

            lblEventName.SetBinding(Label.TextProperty, new Binding("EventName"));

            // TODO: do some calculations to get Event Day
            lblEventDay.SetBinding(Label.TextProperty, new Binding("EventStartDate",BindingMode.Default,null,null, "Event on : {0:ddd, dd MMM yyy}"));


            lblEventTime.SetBinding(Label.TextProperty, new Binding("EventTime",BindingMode.Default,null,null,"Event from : {0}"));
      

            StackLayout stlEventCell = new StackLayout
            {
                //Children = { grdEventCell },
                Children = {lblEventDay,lblEventName,lblEventTime,btnDirections},
                Padding = 5
            };
            Frame frmCell = new Frame
            {
                CornerRadius = 4,
                HasShadow = true,
                Content = stlEventCell,
                Margin = 5,
            
            };

            View = frmCell;
        }

 
    }
}
