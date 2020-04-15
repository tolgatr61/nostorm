using OpenNos.Domain;
using System.Collections.Generic;

namespace OpenNos.GameObject.Helpers
{
    public class ItemHelper
    {
        #region Properties

        public static readonly byte[] RareRate = new byte[] { 0, 0, 0, 0, 0, 0, 50, 50 };

        public static readonly byte[] BuyCraftRareRate = new byte[] { 100, 100, 63, 48, 35, 24, 14, 6 };

        public static readonly byte[] RarifyRate = new byte[] { 0, 0, 0, 0, 0, 0, 0, 0, 20, 50, 50 };

        public static readonly byte[] SpUpFailRate = new byte[] { 1, 2, 3, 4, 5, 6, 6, 7, 8, 9, 10, 11, 12, 13, 14 };

        public static readonly byte[] SpDestroyRate = new byte[] { 0, 0, 0, 0, 0, 0, 0, 0, 1, 2, 3, 4, 5, 6, 7 };

        public static readonly byte[] ItemUpgradeFixRate = new byte[] { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 };


        public static readonly byte[] ItemUpgradeFailRate = new byte[] { 0, 0, 0, 0, 2, 4, 6, 8, 9, 10};

        public static readonly byte[] R8ItemUpgradeFixRate = new byte[] { 5, 5, 6, 7, 8, 9, 10, 10, 10, 10,0 };

        public static readonly byte[] R8ItemUpgradeFailRate = new byte[] { 5, 5, 5, 6, 7, 8, 9, 10, 10, 10 };

        #endregion

        #region Singleton

        private static PassiveSkillHelper _instance;

        public static PassiveSkillHelper Instance => _instance ?? (_instance = new PassiveSkillHelper());

        #endregion
    }
}