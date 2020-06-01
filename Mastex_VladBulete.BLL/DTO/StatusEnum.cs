using System;
using System.Collections.Generic;
using System.Text;

namespace Mastex_BuleteVlad.BLL.DTO
{
    public class StatusEnum
    {

        public StatusEnum(string value) { Value = value; }

        public string Value { get; set; }

        public static StatusEnum Created { get { return new StatusEnum("Created"); } }
        public static StatusEnum Researching { get { return new StatusEnum("Researching"); } }
        public static StatusEnum InProgress { get { return new StatusEnum("InProgress"); } }
        public static StatusEnum Done { get { return new StatusEnum("Done"); } }



        //public static StatusEnum Error { get { return new StatusEnum("Error"); } }
    }
}
