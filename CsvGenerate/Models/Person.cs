using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CsvGenerate.Models
{
    public class Person
    {
        [DisplayName("Imię")]
        [Required]
        public string Name { get; set; }

        [DisplayName("Nazwisko")]
        [Required]
        public string LastName { get; set; }

        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}",
                       ApplyFormatInEditMode = true)]
        [DisplayName("Data urodzenia")]
        public DateTime DateOfBirth { get; set; }


        [DisplayName("Kolor")]
        public string Color { get; set; }

        public SelectList ColorItems { get; set; }
        public static List<Person> PersonList = new List<Person>();

        public Person()
        {
            this.DateOfBirth = DateTime.Today;
            ColorItems = new SelectList(new[] { "Czerwony", "Zielony", "Niebieski" });
            Color = "---";
        }

    }
}