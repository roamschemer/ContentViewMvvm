using Prism.Mvvm;
using System;
using System.Collections.Generic;
using System.Text;

namespace ContentViewMvvm.Models
{
    public class SeedData : BindableBase
    {
        public int Seed
        {
            get => seed;
            set => SetProperty(ref seed, value);
        }
        private int seed;

        /// <summary>
        /// 被らない値を獲得する
        /// </summary>
        public void SeedSet()
        {
            Seed = Environment.TickCount;
        }
    }
}
