using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Reflection;
using System.Windows;

namespace Database
{
    public partial class MainWindow
        : Window
    {
        public class StreamEnumerable<T>
            : IEnumerable<T>
        {
            private StreamReader _stream;
            private object _current=null;
            public StreamEnumerable(StreamReader stream)
            {
                _stream = stream;
            }
            public bool MoveNext()
            {
                if (!_stream.EndOfStream)
                {
                    _current = Load<object>(_stream);
                    return true;
                }
                return false;
            }
            public object Current()
            {
                return _current;
            }
            public IEnumerator<T> GetEnumerator()
            {
                while (MoveNext())
                {
                     yield return (T)_current;
                }

            }

            IEnumerator IEnumerable.GetEnumerator()
            {
                return GetEnumerator();
            }


            public T Load<T>(StreamReader sr) where T : new()
            {
                T ob = default(T);
                Type tob = null;
                PropertyInfo property = null;
                while (!sr.EndOfStream)
                {
                    var ln = sr.ReadLine();
                    if (ln == "[[]]") return ob;
                    else if (ln.StartsWith("[["))
                    {
                        tob = Type.GetType(ln.Trim('[', ']'));
                        if (typeof(T).IsAssignableFrom(tob))
                            ob = (T)Activator.CreateInstance(tob);
                    }
                    else if (ln.StartsWith("[") && ob != null)
                        property = tob.GetProperty(ln.Trim('[', ']'));
                    else if (ob != null && property != null)
                        property.SetValue(ob, Convert.ChangeType(ln, property.PropertyType));
                }
                return default(T);
            }
        }




    }

}