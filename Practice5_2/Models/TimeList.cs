using Practice5_2.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;



public class TimesList
{
    private List<TimeItem> items;

    public TimesList()
    {
        items = new List<TimeItem>();
    }

    public void Add(TimeItem item)
    {
        items.Add(item);
    }

    public void Save(string filename)
    {
        FileStream stream = null;
        try
        {
            stream = new FileStream(filename, FileMode.Create, FileAccess.Write);
            BinaryFormatter formatter = new BinaryFormatter();
            formatter.Serialize(stream, items);
        }
        catch (Exception ex)
        {
            throw new Exception("Ошибка сохранения файла. " , ex);
        }
        finally
        {
            if (stream != null)
                stream.Close();
        }
    }

    public void Load(string filename)
    {
        FileStream stream = null;
        try
        {
            stream = new FileStream(filename, FileMode.Open, FileAccess.Read);
            BinaryFormatter formatter = new BinaryFormatter();
            items = (List<TimeItem>)formatter.Deserialize(stream);
        }
        catch (Exception ex)
        {
            throw new Exception("Error while loading from file.", ex);
        }
        finally
        {
            if (stream != null)
                stream.Close();
        }
    }
}