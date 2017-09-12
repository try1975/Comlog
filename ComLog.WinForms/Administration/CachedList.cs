using System;
using System.Collections.Generic;
using System.Linq;

namespace ComLog.WinForms.Administration
{
    public class CachedList<T> where T : class
    {
        private List<T> _list;                
        private readonly Func<List<T>> _loadListExp;
        private readonly object _sync = new object();

        public CachedList(Func<List<T>> loadListExp)
        {            
            _loadListExp = loadListExp;
        }

        public T GetItem(Func<T, bool> exp)
        {
            lock (_sync)
            {
                if (exp == null) return null;
                var item = Items.FirstOrDefault(exp);
                if (item != null) return item;
                InvalidateList();
                return Items.FirstOrDefault(exp);
            }
        }

        public void InvalidateList()
        {
            _list = null;
        }

        public List<T> Items
        {
            get
            {
                lock (_sync)
                {
                    if (_list == null && _loadListExp != null)
                    {
                        _list = _loadListExp();
                    }
                    return _list;
                }
            }
        }
        
    }
}
