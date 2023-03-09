using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Xml.Serialization;

namespace Movie43.Repositories
{
    public class XMLRepository<T> : IRepository<T>
    {
        #region Поля
        private string _nameFile = "XMLFilmsLibrary.xml";
        private readonly string _fullPath;
        #endregion

        #region Конструктор
        public XMLRepository()
        {
            _fullPath = @$"{Environment.CurrentDirectory}\{_nameFile}";

            if (!File.Exists(_fullPath))
            {
                FileStream stream = File.Create(_fullPath);
                stream.Dispose();
            }
        }
        #endregion

        #region Публичные методы
        public bool Add(T item)
        {
            try
            {
                XmlSerializer xmlSerializer = new(typeof(T));
                List<T> itemsFromXml;

                using (FileStream stream = new(_fullPath, FileMode.Open, FileAccess.ReadWrite))
                {
                    itemsFromXml = (List<T>)xmlSerializer.Deserialize(stream);

                    if (itemsFromXml == null) itemsFromXml = new();

                    itemsFromXml.Add(item);

                    xmlSerializer.Serialize(stream, itemsFromXml);
                }
                return true;
            }
            catch (Exception ex)
            {
                Debug.WriteLine($"Класс: {nameof(XMLRepository<T>)}; Метод: {nameof(Add)}; Сообщение: {ex.Message}");
            }
            return false;
        }

        public bool AddRange(IEnumerable<T> items)
        {
            try
            {
                XmlSerializer xmlSerializer = new(typeof(T));
                List<T> itemsFromXml;

                using (FileStream stream = new(_fullPath, FileMode.Open, FileAccess.ReadWrite))
                {
                    itemsFromXml = (List<T>)xmlSerializer.Deserialize(stream);

                    if (itemsFromXml == null) itemsFromXml = new();

                    itemsFromXml.AddRange(items);

                    xmlSerializer.Serialize(stream, itemsFromXml);
                }
                return true;
            }
            catch (Exception ex)
            {
                Debug.WriteLine($"Класс: {nameof(XMLRepository<T>)}; Метод: {nameof(AddRange)}; Сообщение: {ex.Message}");
            }
            return false;
        }

        public bool Delete(T item)
        {
            try
            {
                XmlSerializer xmlSerializer = new(typeof(T));
                List<T> itemsFromXml;

                using (FileStream stream = new(_fullPath, FileMode.Open, FileAccess.ReadWrite))
                {
                    itemsFromXml = (List<T>)xmlSerializer.Deserialize(stream);

                    if (itemsFromXml == null) itemsFromXml = new();

                    itemsFromXml.Remove(item);

                    xmlSerializer.Serialize(stream, itemsFromXml);
                }
                return true;
            }
            catch (Exception ex)
            {
                Debug.WriteLine($"Класс: {nameof(XMLRepository<T>)}; Метод: {nameof(Delete)}; Сообщение: {ex.Message}");
            }
            return false;
        }

        public bool DeleteRange(IEnumerable<T> items)
        {
            try
            {
                XmlSerializer xmlSerializer = new(typeof(T));
                List<T> itemsFromXml;

                using (FileStream stream = new(_fullPath, FileMode.Open, FileAccess.ReadWrite))
                {
                    itemsFromXml = (List<T>)xmlSerializer.Deserialize(stream);

                    if (itemsFromXml == null) itemsFromXml = new();

                    int index = itemsFromXml.IndexOf(items.ToArray()[0]);

                    if (index >= 0)
                    {
                        itemsFromXml.RemoveRange(index, items.Count());

                        xmlSerializer.Serialize(stream, itemsFromXml);
                    }
                }
                return true;
            }
            catch (Exception ex)
            {
                Debug.WriteLine($"Класс: {nameof(XMLRepository<T>)}; Метод: {nameof(DeleteRange)}; Сообщение: {ex.Message}");
            }
            return false;
        }

        public IEnumerable<T> GetItems(Predicate<T> predicate)
        {
            List<T> itemsFromXml = new();
            try
            {
                XmlSerializer xmlSerializer = new(typeof(T));

                using (FileStream stream = new(_fullPath, FileMode.Open, FileAccess.ReadWrite))
                {
                    itemsFromXml = (List<T>)xmlSerializer.Deserialize(stream);

                    if (itemsFromXml == null) itemsFromXml = new();

                    return itemsFromXml.Where(e => predicate(e)).ToList();
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine($"Класс: {nameof(XMLRepository<T>)}; Метод: {nameof(GetItems)}; Сообщение: {ex.Message}");
            }
            return itemsFromXml;
        }

        public bool Update(T item)
        {
            try
            {
                XmlSerializer xmlSerializer = new(typeof(T));
                List<T> itemsFromXml;

                using (FileStream stream = new(_fullPath, FileMode.Open, FileAccess.ReadWrite))
                {
                    itemsFromXml = (List<T>)xmlSerializer.Deserialize(stream);

                    if (itemsFromXml == null) itemsFromXml = new();

                    int index = itemsFromXml.IndexOf(item);

                    if (index >= 0)
                    {
                        itemsFromXml[index] = item;

                        xmlSerializer.Serialize(stream, itemsFromXml);
                    }
                }
                return true;
            }
            catch (Exception ex)
            {
                Debug.WriteLine($"Класс: {nameof(XMLRepository<T>)}; Метод: {nameof(Update)}; Сообщение: {ex.Message}");
            }
            return false;
        }

        public bool UpdateRange(IEnumerable<T> items)
        {
            try
            {
                XmlSerializer xmlSerializer = new(typeof(T));
                List<T> itemsFromXml;

                using (FileStream stream = new(_fullPath, FileMode.Open, FileAccess.ReadWrite))
                {
                    itemsFromXml = (List<T>)xmlSerializer.Deserialize(stream);

                    if (itemsFromXml == null) itemsFromXml = new();

                    foreach (T item in items)
                    {
                        int index = itemsFromXml.IndexOf(item);

                        if (index >= 0)
                        {
                            itemsFromXml[index] = item;

                            xmlSerializer.Serialize(stream, itemsFromXml);
                        }
                    }
                }
                return true;
            }
            catch (Exception ex)
            {
                Debug.WriteLine($"Класс: {nameof(XMLRepository<T>)}; Метод: {nameof(UpdateRange)}; Сообщение: {ex.Message}");
            }
            return false;
        }
        #endregion
    }
}
