﻿using System;
using System.ComponentModel.DataAnnotations.Schema;


public class BaseEntity
{
    //ID
    public DateTime DateCreated { get; set; }
    //public string UserCreated { get; set; }
    public DateTime DateModified { get; set; }
    //public string UserModified { get; set; }
}