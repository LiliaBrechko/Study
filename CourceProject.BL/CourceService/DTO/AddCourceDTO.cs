﻿using CourseProject.DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CourseProject.BL.CourceService.DTO
{
    public class AddCourceDTO
    {
        public string Name { get; set; } = string.Empty;
        public int TeacherId { get; set; }       
        
    }
}
