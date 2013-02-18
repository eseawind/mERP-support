# -*- coding: UTF-8 -*-
import clr
clr.AddReference("System.Data");
clr.AddReference("Feng.Data");
import System;
import Feng;


def walk(folder, extention):
  for file in System.IO.Directory.GetFiles(folder, extention):
    yield file
  for folder in System.IO.Directory.GetDirectories(folder):
    for file in walk(folder, extention): yield file
  
folder = System.IO.Path.GetDirectoryName(__file__) + "\\Hd.Report\\";


all_files_report = list(walk(folder, '*.rpt'))
all_files_dataset = list(walk(folder, '*.xsd'))

def upload(all_files, prefix, resourceType):
  for i in all_files:
    fileName = System.IO.Path.GetFileName(i);
    sr = System.IO.FileStream(i, System.IO.FileMode.Open);
    byte = System.Array.CreateInstance(System.Byte, int(sr.Length));
    sr.Read(byte, 0, sr.Length); 
    content = System.Convert.ToBase64String(byte);
    sr.Close();
    
    sql = "DELETE AD_Resource WHERE ResourceName = '" + fileName + "' AND ResourceType = " + str(resourceType);
    print(sql);
    Feng.Data.DbHelper.Instance.ExecuteNonQuery(sql);
    sql = "INSERT INTO AD_Resource \
      ([Name],[Version],[ResourceType],[ResourceName],[Content],[ContentType],[IsActive],[ClientId],[OrgId],[CreatedBy],[Created]) \
      VALUES (" + "@name" + \
      ",1, @resourcetype, @fileName, @content," + \
      "'System.String', " + \
      "'True', 0, 0, 'system', GETDATE())";
    print(sql);
    cmd = System.Data.SqlClient.SqlCommand(sql);
    cmd.Parameters.AddWithValue("@name", prefix + fileName);
    cmd.Parameters.AddWithValue("@resourcetype", resourceType);
    cmd.Parameters.AddWithValue("@fileName", fileName);
    cmd.Parameters.AddWithValue("@content", content);
    Feng.Data.DbHelper.Instance.ExecuteNonQuery(cmd);

upload(all_files_report, "Report_", 2);
upload(all_files_dataset, "Dataset_", 3);

