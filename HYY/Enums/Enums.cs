using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace HYY.Enums
{
    public class Enums
    {
        public enum Role
        {
            Admin,
            Doctor
        }

        public enum Status
        {
            Created,
            Assigned
        }

        public enum Priority
        {
            Low,
            Normal,
            High
        }
    }
}