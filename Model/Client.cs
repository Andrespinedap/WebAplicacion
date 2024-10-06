﻿namespace WebAplicacion.Model
{
    // se creo la tabla client con sus respectivos campos
    public class Client
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public string Address { get; set; }

       public Comentari_Client Comentari { get; set; }
        public Cities Cities { get; set; }
       
    }
}
