using Xamarin.Forms;

namespace ContentViewMvvm.Controls
{
    public class MyCustomContentView : ContentView
    {
        public static readonly BindableProperty NowNameProperty =
            BindableProperty.Create(nameof(NowName), //名前
                                    typeof(string),　//型
                                    typeof(MyCustomContentView), //自クラス
                                    string.Empty,    //初期値
                                    propertyChanged: (bindable, oldValue, newValue) => //変更があったことを感知するイベントハンドラ
                                    {
                                        ((MyCustomContentView)bindable).NowName = (string)newValue;
                                    },
                                    defaultBindingMode: BindingMode.TwoWay); //初期バインディング方向

        public static readonly BindableProperty CommandTriggerProperty =
            BindableProperty.Create(nameof(CommandTrigger),
                                    typeof(int),
                                    typeof(MyCustomContentView),
                                    0,
                                    propertyChanged: (bindable, oldValue, newValue) =>
                                    {
                                        ((MyCustomContentView)bindable).CommandTrigger = (int)newValue;
                                    },
                                    defaultBindingMode: BindingMode.TwoWay);
        public static readonly BindableProperty ValueProperty =
    BindableProperty.Create(nameof(Value), typeof(double), typeof(MyCustomContentView), 0.0,
        propertyChanged: (bindable, oldValue, newValue) =>
            ((MyCustomContentView)bindable).Value = (double)newValue,
        defaultBindingMode: BindingMode.TwoWay
    );

        public double Value
        {
            get { return (double)GetValue(ValueProperty); }
            set
            {
                SetValue(ValueProperty, value);
            }
        }
        public string NowName
        {
            get => (string)GetValue(NowNameProperty);
            set => SetValue(NowNameProperty, value);
        }

        public int CommandTrigger
        {
            get => (int)GetValue(CommandTriggerProperty);
            set => SetValue(CommandTriggerProperty, value);
        }
    }
}
