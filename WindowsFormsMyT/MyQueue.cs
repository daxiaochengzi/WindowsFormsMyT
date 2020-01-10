using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace WindowsFormsMyT
{
   public class MyQueue : IEnumerable<string>
    {
        List<string> _List;
        UsingLock<object> _Lock;
        public MyQueue(IEnumerable<string> strings)
        {
            _List = new List<string>(strings);
            _Lock = new UsingLock<object>();
        }

        /// <summary> 获取第一个元素.并且从集合中删除
        /// </summary>
        public string LootFirst()
        {
            using (_Lock.Write())
            {
                if (_List.Count == 0)
                {
                    _Lock.Enabled = false;
                    return null;
                }
                var s = _List[0];
                _List.RemoveAt(0);
                return s;
            }
        }

        public int Count { get { return _List.Count; } }

        /// <summary> 枚举当前集合的元素
        /// </summary>
        public IEnumerator<string> GetEnumerator()
        {
            using (_Lock.Read())
            {
                foreach (var item in _List)
                {
                    yield return item;
                }
            }
        }

        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
}
