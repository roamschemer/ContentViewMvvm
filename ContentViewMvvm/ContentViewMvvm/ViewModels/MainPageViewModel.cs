using ContentViewMvvm.Models;
using Prism.Commands;
using Prism.Mvvm;
using Prism.Navigation;
using Reactive.Bindings;
using Reactive.Bindings.Extensions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reactive.Disposables;
using System.Text;

namespace ContentViewMvvm.ViewModels
{
    public class MainPageViewModel : ViewModelBase, IDisposable
    {
        private readonly SeedData SeedModel = new SeedData();

        private CompositeDisposable Disposable { get; } = new CompositeDisposable();
        public ReactiveProperty<int> AllButtonTrigger { get; set; } //未達
        public ReactiveCommand AllButtonCommand { get; private set; } = new ReactiveCommand();

        public MainPageViewModel(INavigationService navigationService)
            : base(navigationService)
        {
            //Modelとの接続(未達
            AllButtonTrigger = SeedModel.ObserveProperty(x => x.Seed)
                                        .ToReactiveProperty<int>()
                                        .AddTo(this.Disposable);
            //Commandの実行
            AllButtonCommand.Subscribe(_ => SeedModel.SeedSet());
        }

        public void Dispose() => this.Disposable.Dispose();
    }
}
