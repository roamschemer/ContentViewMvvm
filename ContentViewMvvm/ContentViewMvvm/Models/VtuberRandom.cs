using Prism.Mvvm;
using System;
using System.Collections.Generic;

namespace ContentViewMvvm.Models
{
    public class VtuberRandom : BindableBase
    {
        public string Name
        {
            get => name;
            set => SetProperty(ref name, value);
        }
        private string name;

        private readonly List<string> nameList;

        public VtuberRandom()
        {
            nameList = new List<string>()
            {
                "九条林檎","九条棗","九条杏子","九条茘枝",
                "雨ヶ崎笑虹","都三代らみょん","三田そにあ","縁うか","ひなわんこ",
                "巻乃もなか","幸糖ミュウミュウ","青咲ローズ","泡沫調",
                "白乃クロミ","碧惺スキア","紫吹ふうか","菜花なな",
                "結目ユイ","水瀬しあ"
            };
        }

        /// <summary>
        /// ランダムでnameListの名前のうちの一つをNameプロパティにSetする
        /// </summary>
        public void RundomNameSet()
        {
            int seed = Environment.TickCount;
            Random rnd = new System.Random(seed);
            var no = rnd.Next(0, nameList.Count);
            Name = nameList[no];
        }
    }
}
