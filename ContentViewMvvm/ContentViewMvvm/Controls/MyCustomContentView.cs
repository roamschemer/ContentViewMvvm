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
                                        ((MyCustomContentView)bindable).NowName = newValue;
                                    },
                                    defaultBindingMode: BindingMode.TwoWay); //初期バインディング方向

        public static readonly BindableProperty CommandTriggerProperty =
            BindableProperty.Create(nameof(CommandTrigger),
                                    typeof(int),
                                    typeof(MyCustomContentView),
                                    0,
                                    propertyChanged: (bindable, oldValue, newValue) =>
                                    {
                                        ((MyCustomContentView)bindable).CommandTrigger = newValue;
                                    },
                                    defaultBindingMode: BindingMode.TwoWay);

        public object NowName
        {
            get => GetValue(NowNameProperty);
            set => SetValue(NowNameProperty, value);
        }

        public object CommandTrigger
        {
            get => GetValue(CommandTriggerProperty);
            set => SetValue(CommandTriggerProperty, value); //←ここに親から来てくれない
        }
    }
}
