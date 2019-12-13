using ContentViewMvvm.Models;
using Prism.Mvvm;
using Reactive.Bindings;
using Reactive.Bindings.Extensions;
using System;

namespace ContentViewMvvm.ViewModels
{
    public class MyControlViewModel : BindableBase
    {
        public VtuberRandom Model { get; }
        public ReactiveCommand RundomCommand { get; private set; } = new ReactiveCommand();
        public ReactiveProperty<string> Name { get; set; }

        public MyControlViewModel(VtuberRandom vtuberRandom)
        {
            this.Model = vtuberRandom;

            Name = Model.ObserveProperty(x => x.Name).ToReactiveProperty<string>();
            RundomCommand.Subscribe(_ => Model.RundomNameSet());
        }
    }
}
