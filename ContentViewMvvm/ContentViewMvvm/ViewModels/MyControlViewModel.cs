using ContentViewMvvm.Models;
using Prism.Mvvm;
using Reactive.Bindings;
using Reactive.Bindings.Extensions;
using System;
using System.Reactive.Disposables;
using System.Reactive.Linq;

namespace ContentViewMvvm.ViewModels
{
    public class MyControlViewModel : BindableBase, IDisposable
    {
        private CompositeDisposable Disposable { get; } = new CompositeDisposable();
        public VtuberRandom Model { get; }
        public ReactiveProperty<string> Name { get; set; }
        public ReactiveCommand RundomCommand { get; private set; } = new ReactiveCommand();

        public MyControlViewModel(VtuberRandom vtuberRandom)
        {
            this.Model = vtuberRandom;

            //Modelとの接続
            Name = Model.ObserveProperty(x => x.Name)                   //ModelのNameプロパティと接続します。
                        .Where(x => x != null)                          //Name != null じゃないとなにもしません。
                        .Select(x => x.Contains("九条") ? $"{x}様" : x) //Nameに"九条"が含まれる場合は様を付加。それ以外はそのまま
                        .ToReactiveProperty<string>()                   //ViewModel←Modelの単方向接続です
                        .AddTo(this.Disposable);                        //解放用に纏めておきます

            //Commandの実行
            RundomCommand.Subscribe(_ => Model.RundomNameSet());

        }
        public void Dispose() => this.Disposable.Dispose();
    }
}
