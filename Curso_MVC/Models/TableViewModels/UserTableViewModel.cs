﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Curso_MVC.Models.TableViewModels
{
    public class UserTableViewModel
    {
        public int Id { get; set; }
        public string Email { get; set; }
        public int? Edad { get; set; }
        public string Password { get; set; }
    }
}