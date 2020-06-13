using App.CardTools.Controls;
using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;

namespace App.CardTools.Extention
{
    public static class LayoutExtention
    {
        public static Grid SetLoad(this View content, StackLayoutLoad load)
        {
            return new Grid
            {
                VerticalOptions = LayoutOptions.FillAndExpand,
                Children =
                {
                    content,
                    load
                }
            };
        }

        public static ScrollView SetOnScrollView(this View content)
        {
            return new ScrollView
            {
                HorizontalOptions = LayoutOptions.FillAndExpand,
                VerticalOptions = LayoutOptions.FillAndExpand,
                Content = content
            };
        }
    }

    public class StackLayoutLoad : StackLayout
    {
        public StackLayoutLoad()
        {
            BackgroundColor = Color.FromHex("#000000").SetTransparence(0.8);
            IsVisible = false;
            HorizontalOptions = LayoutOptions.FillAndExpand;
            VerticalOptions = LayoutOptions.FillAndExpand;
            Children.Add(new CustomActivityIndicator());
        }
    }
}
