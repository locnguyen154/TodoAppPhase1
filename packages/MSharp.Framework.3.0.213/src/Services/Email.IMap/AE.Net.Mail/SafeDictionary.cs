﻿using System.Collections.Generic;

namespace AE.Net.Mail
{
    public class SafeDictionary<KT, VT> : Dictionary<KT, VT>
    {
        public SafeDictionary() { }
        public SafeDictionary(IEqualityComparer<KT> comparer) : base(comparer) { }

        public virtual new VT this[KT key]
        {
            get
            {
                return this.Get(key);
            }
            set
            {
                this.Set(key, value);
            }
        }
    }
}