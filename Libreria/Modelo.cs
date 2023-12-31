﻿using System;
using System.Configuration;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using System.Xml.Serialization;
using System.Text.Json;
using System.IO;

namespace Libreria
{
    public class Modelo
    {
        private string saveRoute;
        public Library library;
        public Modelo() {
            initSettings();
            library = loadData();
        }
        public void registerClient(string nombre)
        {
            
        }
        public void registerBook()
        {

        }
        public void registerVolume(int codLibro)
        {

        }
        public bool registerLoan(int codLibro, int codCliente)
        {
            return library.lendVolume(codLibro, codCliente);
        }
        public bool returnVolume(int codLoan)
        {
            return library.returnVolume(codLoan);
        }
        public void saveData()
        {
            XmlSerializer serializer = new XmlSerializer(typeof(Library));
            using (FileStream fs = new FileStream(saveRoute, FileMode.Create))
            {
                serializer.Serialize(fs, library);
            }
        }
        private Library loadData()
        {
            XmlSerializer serializer = new XmlSerializer(typeof(Library));
            try
            {
                using (FileStream fs = new FileStream(saveRoute, FileMode.Open))
                {
                    Library library = (Library)serializer.Deserialize(fs);
                    return library;
                }
            }
            catch (Exception ex)
            {
                return new Library();
            }
        }
        public void initSettings()
        {
            Constants constants = readConstants("config.json");
            saveRoute = constants.saveRoute;
        }
        public Constants readConstants(string path)
        {
            string json = File.ReadAllText(path);
            return JsonSerializer.Deserialize<Constants>(json);
        }
        public class Constants
        {
            public string saveRoute { get; set; }
        }
    }
}
