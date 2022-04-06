using System.ComponentModel.DataAnnotations;

namespace graigsList_server_cSharp.Models
{

    public class Car
    {

        public int Id { get; set; }


        public string? Make { get; set; }

        public string? Name { get; set; }

        public int? Year { get; set; }


    }



}
