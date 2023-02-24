using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Reflection;

namespace Repository
{
   public class GenericRepository<T>
   {

        public Object getFieldValue<V>(V field, String property)
        {
            Object obj = (Object)field;
            PropertyInfo propertyInfo = obj.GetType().GetProperty(property);
            Object itemValue = propertyInfo.GetValue(obj, null);

            return itemValue;
        }

        public void SetFieldValue<V>(V field, String property, int id)
        {
            Object obj = (Object)field;
            PropertyInfo propertyInfo = obj.GetType().GetProperty(property);
            propertyInfo.SetValue(obj, id, null);
        }

        public String readJsonFromPath(String path)
        {
            TextReader textReader = new StreamReader(path);
            String json = textReader.ReadToEnd();
            textReader.Close();

            return json;
        }

        public void writeJsonToPath(String path, String json)
        {
            File.Create(path).Close();
            TextWriter textWriter = new StreamWriter(path);
            textWriter.Write(json);
            textWriter.Close();
        }



      public T Create(T entity)
      {
            String filePath = @"..\..\Tables\" + typeof(T).Name + ".txt";
            if (File.Exists(filePath))
            {
                String json = readJsonFromPath(filePath);
                List<T> entities = JsonConvert.DeserializeObject<List<T>>(json);
                SetFieldValue(entity, "Id", (int)getFieldValue(entities[entities.Count-1],"Id") + 1);
                entities.Add(entity);
                json = JsonConvert.SerializeObject(entities);
                writeJsonToPath(filePath, json);
            }
            else
            {
                List<T> entities = new List<T>();
                SetFieldValue(entity, "Id", 0);
                entities.Add(entity);
                File.Create(filePath).Close();
                String json = JsonConvert.SerializeObject(entities.ToArray());
                writeJsonToPath(filePath, json);
            }

            return entity;
         //throw new NotImplementedException();
      }
      
        public T GetById(int id)
        {
            String filePath = @"..\..\Tables\" + typeof(T).Name + ".txt";
            if (File.Exists(filePath))
            {
                String json = readJsonFromPath(filePath);
                List<T> entities = JsonConvert.DeserializeObject<List<T>>(json);
                for(int i=0; i<entities.Count; i++)
                    if (id.Equals(getFieldValue(entities[i],"Id")))
                        return entities[i];
            }
            return default(T);
            
            //throw new NotImplementedException();
        }

        public T GetByFieldName(String field, Object value)
        {
            //da li se moze saznati tip koji sadrzi kolona?
            throw new NotImplementedException();
        }
      
        public void Delete(int id)
        {
            String filePath = @"..\..\Tables\" + typeof(T).Name + ".txt";
            if (File.Exists(filePath))
            {
                String json = readJsonFromPath(filePath);
                List<T> entities = JsonConvert.DeserializeObject<List<T>>(json);
                Boolean emptyFile = false;
                for (int i = 0; i < entities.Count; i++)
                    if (id.Equals(getFieldValue(entities[i], "Id")))
                    {
                        if (getFieldValue(entities[i], "Id").Equals(0))
                            emptyFile = true;
                        entities.RemoveAt(i);
                    }
                if (emptyFile)
                    File.Delete(filePath);
                else
                {
                    json = JsonConvert.SerializeObject(entities.ToArray());
                    writeJsonToPath(filePath, json);
                }
            }

            //throw new NotImplementedException();
        }
      
        public T Update(T entity)
        {
            String filePath = @"..\..\Tables\" + typeof(T).Name + ".txt";
            if (File.Exists(filePath))
            {
                String json = readJsonFromPath(filePath);
                List<T> entities = JsonConvert.DeserializeObject<List<T>>(json);
                for(int i=0; i<entities.Count; i++)
                    if (getFieldValue(entity, "Id").Equals(getFieldValue(entities[i], "Id")))
                    {
                        entities.RemoveAt(i);
                        entities.Insert(i, entity);
                    }
                json = JsonConvert.SerializeObject(entities.ToArray());
                writeJsonToPath(filePath, json);
            }

            return default(T);
            //throw new NotImplementedException();
        }
      
        public List<T> GetAll()
        {
            String filePath = @"..\..\Tables\" + typeof(T).Name + ".txt";
            if (File.Exists(filePath))
            {
                String json = readJsonFromPath(filePath);
                List<T> entities = JsonConvert.DeserializeObject<List<T>>(json);
                return entities;
            }

            return default(List<T>);
            //throw new NotImplementedException();
        }
   
   }
}