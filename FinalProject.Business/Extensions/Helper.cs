﻿using FinalProject.Business.Exceptions;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinalProject.Business.Extensions;

public static class Helper
{
    public static string SaveFile(string rootPath, string folder, IFormFile file)
    {
        if( file.ContentType != "image/png" &&  file.ContentType != "image/jpeg")
        {
            throw new ImageContentTypeException("File format is incorrect!");
        }
        if(file.Length> 2097152)
        {
            throw new ImageSizeException("File size cannot from 2mb!");
        }

        string fileName= Guid.NewGuid().ToString() + Path.GetExtension(file.FileName);

        string path = rootPath + $@"\{folder}\" + fileName;

        using (FileStream fileStream = new FileStream(path, FileMode.Create))
        {
            file.CopyTo(fileStream);
        }

        return fileName;
    }

    public static void DeleteFile(string rootPath,string folder, string fileName)
    {
        string path = rootPath + $@"\{folder}\" + fileName;

        if (!File.Exists(path))
            throw new Exceptions.FileNotFoundException("File not found!");

        File.Delete(path);
    }
}
