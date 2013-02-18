# -*- coding: UTF-8 -*-
import clr
clr.AddReference("System.Data");
clr.AddReference("Feng.Data");
import System;
import Feng;


def walk(folder):
  for file in System.IO.Directory.GetFiles(folder, '*.py'):
    yield file
  for folder in System.IO.Directory.GetDirectories(folder):
    for file in walk(folder): yield file
  
folder = System.IO.Path.GetDirectoryName(__file__) + "\\PythonScript\\";


all_files = list(walk(folder))

for i in all_files:
    fileName = System.IO.Path.GetFileName(i);
    sr = System.IO.StreamReader(i);
    content = sr.ReadToEnd();
    sr.Close();
    sql = "DELETE AD_Resource WHERE ResourceName = '" + fileName + "' AND ResourceType = 1";
    print(sql);
    Feng.Data.DbHelper.Instance.ExecuteNonQuery(sql);
    sql = "INSERT INTO AD_Resource \
        ([Name],[Version],[ResourceType],[ResourceName],[Content],[ContentType],[IsActive],[ClientId],[OrgId],[CreatedBy],[Created]) \
        VALUES (" + "@name" + \
           ",1, 1, @fileName, @content," + \
           "'System.String', " + \
           "'True', 0, 0, 'system', GETDATE())";
    print(sql);
    cmd = System.Data.SqlClient.SqlCommand(sql);
    cmd.Parameters.AddWithValue("@name", "Python_" + fileName);
    cmd.Parameters.AddWithValue("@fileName", fileName);
    cmd.Parameters.AddWithValue("@content", content);
    Feng.Data.DbHelper.Instance.ExecuteNonQuery(cmd);
