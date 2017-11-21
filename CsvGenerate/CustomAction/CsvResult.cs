using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.Mvc;
using CsvGenerate.Models;

namespace CsvGenerate.CustomAction
{
    public class CsvResult : ActionResult
    {
        public object Content { get; set; }
        public Encoding ContentEncoding { get; set; }
        public string Name { get; set; }


        public CsvResult(Object obj)
        {
            this.Content = obj;
        }

        public override void ExecuteResult(ControllerContext context)
        {
            Type type = Content.GetType();
            List <Person> list = new List<Person>();
            StringBuilder sb = new StringBuilder();

            if (type.Equals(typeof(List<Person>)))
            {                
                list = (List<Person>)Content;
                foreach (var person in list)
                {
                    sb.AppendFormat(
                        "{0},{1},{2},{3},{4}", person.Name, person.LastName, person.DateOfBirth, person.Color, Environment.NewLine);
                }
            }
            
            HttpResponseBase response = context.HttpContext.Response;

            if (context == null)
                throw new ArgumentNullException("Context not found");

            var fileName = DateTime.Now.ToString("dd_MM_yyyy")+ "_CSVFile";

            if (ContentEncoding != null)
                response.ContentEncoding = ContentEncoding;

            if (!String.IsNullOrEmpty(Name))
                fileName = Name.Contains('.') ? Name : Name + ".csv";

            response.ContentType = "text/csv";
            response.AddHeader("content-disposition", String.Format("attachment;filename=\"{0}.csv\"", fileName));

            if (sb != null)
                response.Write(sb);
        }
    }
}