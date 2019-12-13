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
        public ReactiveCommand RundomCommand { get; private set; } = new ReactiveCommand();
        public ReactiveProperty<string> Name { get; set; }

        public MyControlViewModel(VtuberRandom vtuberRandom)
        {
            this.Model = vtuberRandom;

            //Model→ViewModelの接続
            Name = Model.ObserveProperty(x => x.Name)
                        .Where(x => x != null)
                        .Select(x => x.Contains("九条") ? $"{x}様" : x)
                        .ToReactiveProperty<string>()
                        .AddTo(this.Disposable);

            //Commandの実行
            RundomCommand.Subscribe(_ => Model.RundomNameSet());

        }
        public void Dispose() => this.Disposable.Dispose();
    }
}
