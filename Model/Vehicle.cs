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
        public Dates Cities { get; set; }
        public Maintenance_History MaintenanceHistory { get; set; }

    }

    }

