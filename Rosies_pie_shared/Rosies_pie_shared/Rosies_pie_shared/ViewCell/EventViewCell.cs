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
            Label lbProductName = new Label
            {
                TextColor = Color.Black,
                FontSize = 18,
                HorizontalOptions = LayoutOptions.Start,
                VerticalOptions = LayoutOptions.Center,
                TranslationX = 35
            };

            

            lbProductName.SetBinding(Label.TextProperty, new Binding("EventName"));

            StackLayout stlProductCellLayout = new StackLayout
            {
                Children = { lbProductName },
                Orientation = StackOrientation.Horizontal

            };

            View = stlProductCellLayout;
        }
    }
}
