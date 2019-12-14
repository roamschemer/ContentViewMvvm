using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;

namespace ContentViewMvvm.Controls
{
    public class MyCustomContentView : ContentView
    {
        public static readonly BindableProperty NowNameProperty =
            BindableProperty.Create("NowName",
                                    typeof(string),
                                    typeof(MyCustomContentView),
                                    string.Empty,
                                    propertyChanged: (bindable, oldValue, newValue) =>
                                    {
                                        ((MyCustomContentView)bindable).NowName = newValue;
                                    },
                                    defaultBindingMode: BindingMode.TwoWay);
        public object NowName
        {
            get => GetValue(NowNameProperty);
            set => SetValue(NowNameProperty, value);
        }
    }
}
