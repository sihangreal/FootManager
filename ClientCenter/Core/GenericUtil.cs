using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;

namespace ClientCenter.Core
{
    public class GenericUtil
    {
        /// <summary>
        /// 比较两个List改变的集合
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="listT1">有变动的</param>
        /// <param name="listT2">原始</param>
        /// <returns></returns>
        public static List<T> GetChanges<T>(List<T> listT1, List<T> listT2)
        {
            List<T> listT3 = new List<T>();
            foreach (T t1 in listT1)
            {
                foreach (T t2 in listT2)
                {
                    if (ObjectEquel(t1, t2))
                        listT3.Add(t1);
                }
            }
            return listT1.Except(listT3).ToList();
        }

        /// <summary>
        /// 比较两个对象的所有值是否完全一样
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="obj1"></param>
        /// <param name="obj2"></param>
        /// <returns></returns>
        public static bool ObjectEquel<T>(T obj1, T obj2)
        {
            Type type = typeof(T);
            PropertyInfo[] pinfos = type.GetProperties();
            bool IsMatch = true;
            for (int i = 0; i < pinfos.Length; i++)
            {
                object value1 = pinfos[i].GetValue(obj1);
                object value2 = pinfos[i].GetValue(obj2);
                value1 = value1 == null ? DBNull.Value : value1;
                value2 = value2 == null ? DBNull.Value : value2;
                if (!value1.Equals(value2))
                {
                    IsMatch = false;
                    break;
                }
            }
            return IsMatch;
        }

        /// <summary>
        /// List<T> 深拷贝
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="listT"></param>
        /// <returns></returns>
        public static List<T> Clone<T>(List<T> listT)
        {
            List<T> listT2 = new List<T>();
            foreach (T t1 in listT)
            {
                listT2.Add(Clone(t1));
            }
            return listT2;
        }

        public static T Clone<T>(T RealObject)
        {
            using (Stream objectStream = new MemoryStream())
            {
                //利用 System.Runtime.Serialization序列化与反序列化完成引用对象的复制
                IFormatter formatter = new BinaryFormatter();
                formatter.Serialize(objectStream, RealObject);
                objectStream.Seek(0, SeekOrigin.Begin);
                return (T)formatter.Deserialize(objectStream);
            }
        }
    }
}
