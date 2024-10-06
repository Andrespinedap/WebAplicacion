﻿namespace WebAplicacion.Model
{
    public class Vehicle
    {
        public int Id { get; set; }
        public int Client_Id { get; set; }
        public int Brand { get; set; }
        public int Model { get; set; }
        public int Year { get; set; }
        public string Plate { get; set; }
        public Order Order { get; set; }
        public Cities Cities { get; set; }
        public Maintenance_History Maintenance_History { get; set; }
       
    }

    }

